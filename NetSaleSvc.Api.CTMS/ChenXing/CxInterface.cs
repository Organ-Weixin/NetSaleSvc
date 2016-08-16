using NetSaleSvc.Api.CTMS.Models;
using NetSaleSvc.Entity.Enum;
using NetSaleSvc.Entity.Models;
using NetSaleSvc.Util;
using System;
using System.Linq;
using NetSaleSvc.Api.CTMS.CxService;
using NetSaleSvc.Api.CTMS.ChenXing.Models;
using NetSaleSvc.Service;
using System.Threading;
using System.Collections.Generic;
using System.Collections;

namespace NetSaleSvc.Api.CTMS.ChenXing
{
    public class CxInterface : ICTMSInterface
    {
        #region private fields
        private TspSoapServiceImplService cxService;
        private CinemaService _cinemaService;
        private ScreenInfoService _screenInfoService;
        private SeatInfoService _seatInfoService;
        private FilmInfoService _filmInfoService;
        private SessionInfoService _sessionInfoService;
        #endregion

        /// <summary>
        /// 默认全部不进行压缩
        /// </summary>
        private const string pCompress = "0";

        #region ctor
        public CxInterface()
        {
            cxService = new TspSoapServiceImplService();
            _cinemaService = new CinemaService();
            _screenInfoService = new ScreenInfoService();
            _seatInfoService = new SeatInfoService();
            _filmInfoService = new FilmInfoService();
            _sessionInfoService = new SessionInfoService();
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

            string queryCinemaResult = cxService.QueryCinemaInfo(userCinema.RealUserName,
                userCinema.CinemaCode, pCompress,
                GenerateVerifyInfo(userCinema.RealUserName, userCinema.CinemaCode, pCompress, userCinema.RealPassword));

            CxQueryCinemaInfoResult cxReply = queryCinemaResult.Deserialize<CxQueryCinemaInfoResult>();

            if (cxReply.ResultCode == "0")
            {
                //更新影院信息
                CinemaEntity cinema = _cinemaService.GetCinemaByCinemaCode(userCinema.CinemaCode);
                cinema.Name = cxReply.Cinema.CinemaName;
                cinema.Address = cxReply.Cinema.Address;
                cinema.ScreenCount = cxReply.Cinema.ScreenCount;
                _cinemaService.Update(cinema);
                //更新影厅信息
                var oldScreens = _screenInfoService.GetScreenListByCinemaCode(userCinema.CinemaCode);

                var newScreens = cxReply.Cinema.Screens.ScreenVO.Select(
                    x => x.MapToEntity(
                        oldScreens.Where(y => y.SCode == x.ScreenCode).SingleOrDefault()
                            ?? new ScreenInfoEntity { CCode = userCinema.CinemaCode })).ToList();

                //插入或更新最新影厅信息
                _screenInfoService.BulkMerge(newScreens, oldScreens);

                reply.Status = StatusEnum.Success;
            }
            else
            {
                reply.Status = StatusEnum.Failure;
            }
            reply.ErrorCode = cxReply.ResultCode;
            reply.ErrorMessage = cxReply.Message;

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

            string querySeatReply = cxService.QuerySeatInfo(userCinema.RealUserName, userCinema.CinemaCode,
                screen.SCode, pCompress,
                GenerateVerifyInfo(userCinema.RealUserName, userCinema.CinemaCode, screen.SCode, pCompress, userCinema.RealPassword));

            CxQuerySeatInfoResult cxReply = querySeatReply.Deserialize<CxQuerySeatInfoResult>();

            if (cxReply.ResultCode == "0")
            {
                var oldSeats = _seatInfoService.GetScreenSeats(userCinema.CinemaCode, screen.SCode).NotNull();

                var newSeats = cxReply.ScreenSites.ScreenSite.Select(
                    x => x.MapToEntity(
                        oldSeats.Where(y => y.SeatCode == x.SeatCode).SingleOrDefault()
                            ?? new ScreenSeatInfoEntity
                            {
                                CinemaCode = userCinema.CinemaCode,
                                ScreenCode = screen.SCode,
                                LoveFlag = LoveFlagEnum.Normal.GetDescription()
                            })).ToList();
                //辰星的GroupCode用于标识情侣座，需要另外处理
                var seatByGroup = newSeats.GroupBy(x => x.GroupCode);
                foreach (var seats in seatByGroup)
                {
                    if (seats.Count() == 2)
                    {
                        var firstSeat = seats.First();
                        var SecondSeat = seats.Last();

                        if (firstSeat.XCoord < SecondSeat.XCoord)
                        {
                            firstSeat.LoveFlag = LoveFlagEnum.LEFT.GetDescription();
                            SecondSeat.LoveFlag = LoveFlagEnum.RIGHT.GetDescription();
                        }
                        else
                        {
                            firstSeat.LoveFlag = LoveFlagEnum.RIGHT.GetDescription();
                            SecondSeat.LoveFlag = LoveFlagEnum.LEFT.GetDescription();
                        }
                    }
                }
                //处理完情侣座后将辰星座位的所有GroupCode置为0000000000000001
                newSeats.ForEach(x => x.GroupCode = "0000000000000001");

                //插入或更新最新座位
                _seatInfoService.BulkMerge(newSeats, oldSeats);

                reply.Status = StatusEnum.Success;
            }
            else
            {
                reply.Status = StatusEnum.Failure;
            }
            reply.ErrorCode = cxReply.ResultCode;
            reply.ErrorMessage = cxReply.Message;

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
            List<CxQueryFilmInfoResultFilmInfoVO> FilmList = new List<CxQueryFilmInfoResultFilmInfoVO>();

            //异步获取每日上映影片信息
            var manualEvents = new List<EventWaitHandle>();
            for (var planDate = StartDate; planDate <= EndDate; planDate = planDate.AddDays(1))
            {
                var mre = new ManualResetEvent(false);
                manualEvents.Add(mre);
                QueryInfoSyncModel model = new QueryInfoSyncModel
                {
                    CurrentDate = planDate,
                    Mre = mre
                };
                ThreadPool.QueueUserWorkItem((o) =>
                {
                    var param = o as QueryInfoSyncModel;
                    string queryFilmResult = cxService.QueryFilmInfo(userCinema.RealUserName, userCinema.CinemaCode,
                        param.CurrentDate.ToString("yyyy-MM-dd"), pCompress,
                        GenerateVerifyInfo(userCinema.RealUserName, userCinema.CinemaCode, param.CurrentDate.ToString("yyyy-MM-dd"), pCompress, userCinema.RealPassword));

                    CxQueryFilmInfoResult cxReply = queryFilmResult.Deserialize<CxQueryFilmInfoResult>();

                    if (cxReply.ResultCode == "0")
                    {
                        lock ((FilmList as ICollection).SyncRoot)
                        {
                            if (cxReply.FilmInfoVOs != null)
                            {
                                FilmList.AddRange(cxReply.FilmInfoVOs.FilmInfoVO.NotNull());
                            }
                        }
                    }

                    param.Mre.Set();
                }, model);
            }
            WaitHandle.WaitAll(manualEvents.ToArray());

            if (FilmList.Count > 0)
            {
                //去除重复
                FilmList = FilmList.Distinct(x => x.FilmCode).ToList();
                var FilmCodes = FilmList.Select(x => x.FilmCode);
                var ExitedFilms = _filmInfoService.GetFilmInfosByCodes(FilmCodes);

                var entities = FilmList.Select(x => x.MapToEntity(
                    ExitedFilms.Where(y => y.FilmCode == x.FilmCode).SingleOrDefault() ?? new FilmInfoEntity()));

                _filmInfoService.BulkMerge(entities, ExitedFilms);

                reply.Status = StatusEnum.Success;
                reply.ErrorCode = "0";
                reply.ErrorMessage = "成功";
                reply.films = entities;
            }
            else
            {
                reply.Status = StatusEnum.Failure;
                reply.ErrorCode = "-1";
                reply.ErrorMessage = "在售影片信息查询失败";
            }
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
            List<CxQueryPlanInfoResultCinemaPlan> SessionList = new List<CxQueryPlanInfoResultCinemaPlan>();

            //异步获取每日排期信息
            var manualEvents = new List<EventWaitHandle>();
            for (var planDate = StartDate; planDate <= EndDate; planDate = planDate.AddDays(1))
            {
                var mre = new ManualResetEvent(false);
                manualEvents.Add(mre);
                QueryInfoSyncModel model = new QueryInfoSyncModel
                {
                    CurrentDate = planDate,
                    Mre = mre
                };
                ThreadPool.QueueUserWorkItem((o) =>
                {
                    var param = o as QueryInfoSyncModel;
                    string querySessionResult = cxService.QueryPlanInfo(userCinema.RealUserName, userCinema.CinemaCode,
                        param.CurrentDate.ToString("yyyy-MM-dd"), pCompress,
                        GenerateVerifyInfo(userCinema.RealUserName, userCinema.CinemaCode, param.CurrentDate.ToString("yyyy-MM-dd"), pCompress, userCinema.RealPassword));

                    CxQueryPlanInfoResult cxReply = querySessionResult.Deserialize<CxQueryPlanInfoResult>();

                    if (cxReply.ResultCode == "0")
                    {
                        lock ((SessionList as ICollection).SyncRoot)
                        {
                            if (cxReply.CinemaPlans != null)
                            {
                                SessionList.AddRange(cxReply.CinemaPlans.CinemaPlan.NotNull());
                            }
                        }
                    }

                    param.Mre.Set();
                }, model);
            }
            WaitHandle.WaitAll(manualEvents.ToArray());

            if (SessionList.Count > 0)
            {
                var oldSessions = _sessionInfoService.GetSessions(userCinema.CinemaCode, userCinema.UserId, StartDate, EndDate);

                var newSessions = SessionList.Select(
                    x => x.MapToEntity(
                        oldSessions.Where(y => y.SCode == x.FeatureAppNo).SingleOrDefault()
                            ?? new SessionInfoEntity
                            {
                                CCode = userCinema.CinemaCode,
                                SCode = x.FeatureAppNo,
                                UserID = userCinema.UserId
                            })).ToList();

                //插入或更新最新放映计划
                _sessionInfoService.BulkMerge(newSessions, oldSessions);

                reply.Status = StatusEnum.Success;
                reply.ErrorCode = "0";
                reply.ErrorMessage = "成功";
            }
            else
            {
                reply.Status = StatusEnum.Failure;
                reply.ErrorCode = "-1";
                reply.ErrorMessage = "放映计划查询失败";
            }

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

            string queryPlanSeatResult = cxService.QueryPlanSeat(userCinema.RealUserName,
                userCinema.CinemaCode, SessionCode, Status.GetDescription(), pCompress,
                GenerateVerifyInfo(userCinema.RealUserName,
                userCinema.CinemaCode, SessionCode, Status.GetDescription(),
                pCompress,userCinema.RealPassword));

            CxQueryPlanSeatResult cxReply = queryPlanSeatResult.Deserialize<CxQueryPlanSeatResult>();

            if (cxReply.ResultCode == "0")
            {
                reply.SessionSeats = cxReply.PlanSiteStates.PlanSiteState.Select(x =>
                    new SessionSeatEntity
                    {
                        SeatCode = x.SeatCode,
                        RowNum = x.RowNum,
                        ColumnNum = x.ColumnNum,
                        Status = x.Status.CastToEnum<SessionSeatStatusEnum>()
                    });

                reply.Status = StatusEnum.Success;
            }
            else
            {
                reply.Status = StatusEnum.Failure;
            }

            reply.ErrorCode = cxReply.ResultCode;
            reply.ErrorMessage = cxReply.Message;

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

            //TODO

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

            //TODO

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

            return MD5Helper.MD5Encrypt(sourceString.ToLower());
        }
        #endregion
    }
}
