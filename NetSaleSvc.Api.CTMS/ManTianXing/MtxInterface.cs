﻿using NetSaleSvc.Api.CTMS.ManTianXing.Models;
using NetSaleSvc.Api.CTMS.Models;
using NetSaleSvc.Api.CTMS.MtxService;
using NetSaleSvc.Api.CTMS.Util;
using NetSaleSvc.Entity.Enum;
using NetSaleSvc.Entity.Models;
using NetSaleSvc.Service;
using NetSaleSvc.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace NetSaleSvc.Api.CTMS.ManTianXing
{
    public class MtxInterface : ICTMSInterface
    {
        #region private fileds
        private ticketapi mtxService;
        private CinemaService _cinemaService;
        private ScreenInfoService _screenInfoService;
        private SeatInfoService _seatInfoService;
        private FilmInfoService _filmInfoService;
        private SessionInfoService _sessionInfoService;
        #endregion

        private const string TokenId = "1829";
        private const string Token = "abcdef";

        #region ctor
        public MtxInterface(string Url)
        {
            mtxService = new ticketapi();
            if (!string.IsNullOrEmpty(Url))
            {
                mtxService.Url = Url;
            }

            _screenInfoService = new ScreenInfoService();
            _seatInfoService = new SeatInfoService();
            _filmInfoService = new FilmInfoService();
            _sessionInfoService = new SessionInfoService();
            _cinemaService = new CinemaService();
        }
        #endregion

        /// <summary>
        /// 查询影院基本信息
        /// </summary>
        /// <param name="cinema"></param>
        /// <returns></returns>
        [CheckForNullArgumentsAspect]
        public CTMSQueryCinemaReply QueryCinema(UserCinemaViewEntity userCinema)
        {
            CTMSQueryCinemaReply reply = new CTMSQueryCinemaReply();

            string getHallResult = mtxService.GetHall(userCinema.RealUserName, userCinema.CinemaCode, TokenId,
                GenerateVerifyInfo(userCinema.RealUserName, userCinema.CinemaCode, TokenId, Token, userCinema.RealPassword));

            mtxGetHallResult mtxReply = getHallResult.Deserialize<mtxGetHallResult>();

            if (mtxReply.ResultCode == "0")
            {
                //更新影厅信息
                var oldScreens = _screenInfoService.GetScreenListByCinemaCode(userCinema.CinemaCode);

                var newScreens = mtxReply.Halls.Hall.Select(
                    x => x.MapToEntity(
                        oldScreens.Where(y => y.SCode == x.HallNo).SingleOrDefault()
                            ?? new ScreenInfoEntity { CCode = userCinema.CinemaCode })).ToList();

                //插入或更新最新影厅信息
                _screenInfoService.BulkMerge(newScreens, oldScreens);

                reply.Status = StatusEnum.Success;
            }
            else
            {
                reply.Status = StatusEnum.Failure;
            }
            reply.ErrorCode = mtxReply.ResultCode;

            return reply;
        }

        /// <summary>
        /// 查询影厅座位信息
        /// </summary>
        /// <param name="userCinema"></param>
        /// <param name="screen"></param>
        /// <returns></returns>
        [CheckForNullArgumentsAspect]
        public CTMSQuerySeatReply QuerySeat(UserCinemaViewEntity userCinema, ScreenInfoEntity screen)
        {
            CTMSQuerySeatReply reply = new CTMSQuerySeatReply();

            string getHallAllSeatResult = mtxService.GetHallAllSeat(userCinema.RealUserName, userCinema.CinemaCode,
                screen.SCode,
                GenerateVerifyInfo(userCinema.RealUserName, userCinema.CinemaCode, screen.SCode, userCinema.RealPassword));

            mtxGetHallAllSeatResult mtxReply = JsonConvert.DeserializeObject<mtxGetHallAllSeatResult>(getHallAllSeatResult);

            if (mtxReply.ResultCode == "0")
            {
                var oldSeats = _seatInfoService.GetScreenSeats(userCinema.CinemaCode, screen.SCode).NotNull();

                var newSeats = mtxReply.hallSeats.Select(
                    x => x.MapToEntity(
                        oldSeats.Where(y => y.SeatCode == x.SeatNo).SingleOrDefault()
                            ?? new ScreenSeatInfoEntity
                            {
                                CinemaCode = userCinema.CinemaCode,
                                ScreenCode = screen.SCode,
                                LoveFlag = LoveFlagEnum.Normal.GetDescription()
                            })).ToList();


                //插入或更新最新座位
                _seatInfoService.BulkMerge(newSeats, oldSeats);

                reply.Status = StatusEnum.Success;
            }
            else
            {
                reply.Status = StatusEnum.Failure;
            }
            reply.ErrorCode = mtxReply.ResultCode;

            return reply;
        }

        /// <summary>
        /// 查询影片信息
        /// </summary>
        /// <param name="userCinema"></param>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        [CheckForNullArgumentsAspect]
        public CTMSQueryFilmReply QueryFilm(UserCinemaViewEntity userCinema, DateTime StartDate, DateTime EndDate)
        {
            CTMSQueryFilmReply reply = new CTMSQueryFilmReply();

            //满天星没有获取影片接口，从排期中获取
            QuerySession(userCinema, StartDate, EndDate);

            var sessions = _sessionInfoService.GetSessions(userCinema.CinemaCode, userCinema.UserId, StartDate, EndDate);

            var allfilmList = sessions.Distinct(x => x.FilmCode)
                .Select(x => new FilmInfoEntity
                {
                    FilmCode = x.FilmCode,
                    FilmName = x.FilmName,
                    Version = x.Dimensional,
                    Duration = x.Duration.GetValueOrDefault(0).ToString(),
                }).ToList();

            var existedFilms = _filmInfoService.GetFilmInfosByCodes(allfilmList.Select(x => x.FilmCode)).ToList();

            existedFilms.AddRange(allfilmList.Except(existedFilms));

            //过滤名称相同但编码不同的影片
            var distinctFilmList = new List<FilmInfoEntity>();
            var filmGroups = existedFilms.GroupBy(x => x.FilmName);
            foreach (var filmGroup in filmGroups)
            {
                if (filmGroup.Count() > 1)
                {
                    //优先选择信息比较全的
                    var selectFilm = filmGroup.Where(x => x.PublishDate != null
                    || !string.IsNullOrEmpty(x.Publisher) || !string.IsNullOrEmpty(x.Producer)
                    || !string.IsNullOrEmpty(x.Director) || !string.IsNullOrEmpty(x.Cast)
                    || !string.IsNullOrEmpty(x.Introduction)).FirstOrDefault() ?? filmGroup.First();

                    distinctFilmList.Add(selectFilm);
                }
                else if (filmGroup.Count() > 0)
                {
                    distinctFilmList.Add(filmGroup.First());
                }
            }

            reply.Status = StatusEnum.Success;
            reply.films = distinctFilmList;

            return reply;
        }

        /// <summary>
        /// 查询放映计划信息
        /// </summary>
        /// <param name="userCinema"></param>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        [CheckForNullArgumentsAspect]
        public CTMSQuerySessionReply QuerySession(UserCinemaViewEntity userCinema, DateTime StartDate, DateTime EndDate)
        {
            CTMSQuerySessionReply reply = new CTMSQuerySessionReply();

            //不传日期则获取影院所有排期
            string getCinemaPlanResult = mtxService.GetCinemaPlan(userCinema.RealUserName, userCinema.CinemaCode,
                string.Empty, TokenId,
                GenerateVerifyInfo(userCinema.RealUserName, userCinema.CinemaCode, string.Empty, TokenId, Token, userCinema.RealPassword));

            mtxGetCinemaPlanResult mtxReply = getCinemaPlanResult.Deserialize<mtxGetCinemaPlanResult>();

            if (mtxReply.ResultCode == "0")
            {
                var oldSessions = _sessionInfoService.GetSessions(userCinema.CinemaCode, userCinema.UserId, StartDate, EndDate);

                var newSessions = mtxReply.CinemaPlans.CinemaPlan
                    //只取可用或过场的排期
                    .Where(x => (x.SetClose == 1 || x.SetClose == 2) && (x.UseSign == 0 || x.UseSign == 1))
                    .Select(x => x.MapToEntity(
                        oldSessions.Where(y => y.SCode == x.FeatureAppNo).SingleOrDefault()
                            ?? new SessionInfoEntity
                            {
                                CCode = userCinema.CinemaCode,
                                SCode = x.FeatureAppNo,
                                UserID = userCinema.UserId
                            })).Where(x => x.StartTime > StartDate && x.StartTime < EndDate.AddDays(1)).ToList();

                //插入或更新最新放映计划
                _sessionInfoService.BulkMerge(newSessions, oldSessions);

                reply.Status = StatusEnum.Success;
            }
            else
            {
                reply.Status = StatusEnum.Failure;
            }
            reply.ErrorCode = mtxReply.ResultCode;

            return reply;
        }

        /// <summary>
        /// 查询放映计划座位状态
        /// </summary>
        /// <param name="userCinema"></param>
        /// <param name="SessionCode"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        [CheckForNullArgumentsAspect]
        public CTMSQuerySessionSeatReply QuerySessionSeat(UserCinemaViewEntity userCinema,
            string SessionCode, SessionSeatStatusEnum Status)
        {
            CTMSQuerySessionSeatReply reply = new CTMSQuerySessionSeatReply();

            string getPlanSiteStateResult = mtxService.GetPlanSiteState(userCinema.RealUserName, userCinema.CinemaCode,
                SessionCode, TokenId, GenerateVerifyInfo(userCinema.RealUserName, userCinema.CinemaCode,
                SessionCode, TokenId, Token, userCinema.RealPassword));

            mtxGetPlanSiteStateResult mtxReply = getPlanSiteStateResult.Deserialize<mtxGetPlanSiteStateResult>();

            if (mtxReply.ResultCode == "0")
            {
                var sessionSeats = mtxReply.PlanSiteStates.PlanSiteState.Select(x =>
                    new SessionSeatEntity
                    {
                        SeatCode = x.SeatNo,
                        RowNum = x.SeatRow,
                        ColumnNum = x.SeatCol,
                        Status = getSessionSeatStatus(x.SeatState)
                    });

                if (Status != SessionSeatStatusEnum.All)
                {
                    sessionSeats = sessionSeats.Where(x => x.Status == Status);
                }

                reply.SessionSeats = sessionSeats;
                reply.Status = StatusEnum.Success;
            }
            else
            {
                reply.Status = StatusEnum.Failure;
            }

            reply.ErrorCode = mtxReply.ResultCode;

            return reply;
        }

        /// <summary>
        /// 锁定座位
        /// </summary>
        /// <param name="userCinema"></param>
        /// <param name="QueryXml"></param>
        /// <returns></returns>
        [CheckForNullArgumentsAspect]
        public CTMSLockSeatReply LockSeat(UserCinemaViewEntity userCinema, OrderViewEntity order)
        {
            CTMSLockSeatReply reply = new CTMSLockSeatReply();

            mtxRealCheckSeatStateParameter param = new mtxRealCheckSeatStateParameter
            {
                AppCode = userCinema.RealUserName,
                CinemaId = userCinema.CinemaCode,
                FeatureAppNo = order.orderBaseInfo.SessionCode,
                SerialNum = order.orderBaseInfo.SerialNum = DateTime.Now.ToString("yyyyMMddHHmmssfff" + RandomHelper.CreatePwd(3)),
                SeatInfos = new mtxRealCheckSeatStateParameterSeatInfos
                {
                    SeatInfo = order.orderSeatDetails.Select(x => new mtxRealCheckSeatStateParameterSeatInfo
                    {
                        SeatNo = x.SeatCode,
                        TicketPrice = x.Price,
                        Handlingfee = x.Fee
                    }).ToList()
                },
                PayType = order.orderBaseInfo.PayType,
                RecvMobilePhone = "15700002025",    //不能为空，默认填一个
                TokenID = TokenId,
                VerifyInfo = GenerateVerifyInfo(userCinema.RealUserName, userCinema.CinemaCode,
                    order.orderBaseInfo.SessionCode, order.orderBaseInfo.SerialNum, order.orderBaseInfo.TicketCount.ToString(),
                    order.orderBaseInfo.PayType, "15700002025", TokenId, Token, userCinema.RealPassword)
            };

            string realCheckSeatStateResult = mtxService.LiveRealCheckSeatState(QueryXmlUtil.ToXml(param));

            mtxRealCheckSeatStateResult mtxReply = realCheckSeatStateResult.Deserialize<mtxRealCheckSeatStateResult>();

            if (mtxReply.ResultCode == "0")
            {
                order.orderBaseInfo.LockOrderCode = mtxReply.OrderNo;
                order.orderBaseInfo.AutoUnlockDatetime = DateTime.Now.AddMinutes(10);    //满天星没有自动解锁时间返回，此处默认锁定10分钟
                order.orderBaseInfo.LockTime = DateTime.Now;
                order.orderBaseInfo.OrderStatus = OrderStatusEnum.Locked;
                reply.Status = StatusEnum.Success;
            }
            else
            {
                order.orderBaseInfo.OrderStatus = OrderStatusEnum.LockFail;
                order.orderBaseInfo.ErrorMessage = mtxReply.ResultCode;

                reply.Status = StatusEnum.Failure;
            }

            reply.ErrorCode = mtxReply.ResultCode;

            return reply;
        }

        /// <summary>
        /// 解锁座位
        /// </summary>
        /// <param name="userCinema"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        [CheckForNullArgumentsAspect]
        public CTMSReleaseSeatReply ReleaseSeat(UserCinemaViewEntity userCinema, OrderViewEntity order)
        {
            CTMSReleaseSeatReply reply = new CTMSReleaseSeatReply();

            string unLockOrderCenCinResult = mtxService.UnLockOrderCenCin(userCinema.RealUserName, userCinema.CinemaCode,
                order.orderBaseInfo.LockOrderCode, TokenId,
                GenerateVerifyInfo(userCinema.RealUserName, userCinema.CinemaCode,
                order.orderBaseInfo.LockOrderCode, TokenId, Token, userCinema.RealPassword));

            mtxUnLockOrderCenCinResult mtxReply = unLockOrderCenCinResult.Deserialize<mtxUnLockOrderCenCinResult>();

            if (mtxReply.ResultCode == "0")
            {
                order.orderBaseInfo.OrderStatus = OrderStatusEnum.Released;
                reply.Status = StatusEnum.Success;
            }
            else
            {
                order.orderBaseInfo.OrderStatus = OrderStatusEnum.ReleaseFail;
                order.orderBaseInfo.ErrorMessage = mtxReply.ResultCode;

                reply.Status = StatusEnum.Failure;
            }

            reply.ErrorCode = mtxReply.ResultCode;

            return reply;
        }

        /// <summary>
        /// 提交订单
        /// </summary>
        /// <param name="userCinema"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        [CheckForNullArgumentsAspect]
        public CTMSSubmitOrderReply SubmitOrder(UserCinemaViewEntity userCinema, OrderViewEntity order)
        {
            CTMSSubmitOrderReply reply = new CTMSSubmitOrderReply();

            //TODO

            return reply;
        }

        /// <summary>
        /// 查询出票状态
        /// </summary>
        /// <param name="userCinema"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        [CheckForNullArgumentsAspect]
        public CTMSQueryPrintReply QueryPrint(UserCinemaViewEntity userCinema, OrderViewEntity order)
        {
            CTMSQueryPrintReply reply = new CTMSQueryPrintReply();

            //TODO

            return reply;
        }

        /// <summary>
        /// 退票
        /// </summary>
        /// <param name="userCinema"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        [CheckForNullArgumentsAspect]
        public CTMSRefundTicketReply RefundTicket(UserCinemaViewEntity userCinema, OrderViewEntity order)
        {
            CTMSRefundTicketReply reply = new CTMSRefundTicketReply();

            //TODO

            return reply;
        }

        /// <summary>
        /// 查询订单信息
        /// </summary>
        /// <param name="userCinema"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        [CheckForNullArgumentsAspect]
        public CTMSQueryOrderReply QueryOrder(UserCinemaViewEntity userCinema, OrderViewEntity order)
        {
            CTMSQueryOrderReply reply = new CTMSQueryOrderReply();

            //TODO

            return reply;
        }

        /// <summary>
        /// 查询影票信息
        /// </summary>
        /// <param name="userCinema"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        [CheckForNullArgumentsAspect]
        public CTMSQueryTicketReply QueryTicket(UserCinemaViewEntity userCinema, OrderViewEntity order)
        {
            CTMSQueryTicketReply reply = new CTMSQueryTicketReply();

            //TODO

            return reply;
        }

        /// <summary>
        /// 确认出票
        /// </summary>
        /// <param name="userCinema"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        [CheckForNullArgumentsAspect]
        public CTMSFetchTicketReply FetchTicket(UserCinemaViewEntity userCinema, OrderViewEntity order)
        {
            CTMSFetchTicketReply reply = new CTMSFetchTicketReply();

            //TODO

            return reply;
        }

        #region private method
        /// <summary>
        /// 生成校验信息，数组中参数需要按顺序存放，否则将导致校验信息不正确
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        private string GenerateVerifyInfo(params string[] items)
        {
            string sourceString = string.Join("", items);

            return GetMd5Str(sourceString.ToLower());
        }

        /// <summary>
        /// 满天星生成MD5
        /// </summary>
        /// <param name="ConvertString"></param>
        /// <returns></returns>
        private string GetMd5Str(string ConvertString)
        {
            ConvertString = ConvertString.ToLower();
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            string t2 = BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(ConvertString)), 4, 8);
            t2 = t2.Replace("-", "").ToLower();
            return t2;
        }

        /// <summary>
        /// 满天星排期座位状态转换
        /// </summary>
        /// <param name="seatState"></param>
        /// <returns></returns>
        private SessionSeatStatusEnum getSessionSeatStatus(string seatState)
        {
            switch (seatState)
            {
                case "-1":
                case "4":
                case "9":
                    return SessionSeatStatusEnum.Unavailable;
                case "0":
                    return SessionSeatStatusEnum.Available;
                case "1":
                    return SessionSeatStatusEnum.Sold;
                case "3":
                    return SessionSeatStatusEnum.Booked;
                case "7":
                    return SessionSeatStatusEnum.Locked;
                default:
                    return SessionSeatStatusEnum.Unavailable;
            }
        }
        #endregion
    }
}
