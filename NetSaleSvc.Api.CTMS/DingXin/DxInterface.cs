using NetSaleSvc.Api.CTMS.Models;
using NetSaleSvc.Entity.Enum;
using NetSaleSvc.Entity.Models;
using NetSaleSvc.Util;
using System;

using NetSaleSvc.Api.CTMS.DingXin.Models;
using NetSaleSvc.Service;
using NetSaleSvc.Api.CTMS.NsFetchTicket;
using System.Collections.Generic;
using System.Linq;

namespace NetSaleSvc.Api.CTMS.DingXin
{
    public class DxInterface : ICTMSInterface
    {
        #region private fields
        private FetchTicketSvc fetchTicketSvc;
        private ScreenInfoService _screenInfoService;
        private SeatInfoService _seatInfoService;
        private FilmInfoService _filmInfoService;
        private SessionInfoService _sessionInfoService;
        private CinemaService _cinemaService;
        private DXCodeIDService _dxCodeIDService;
        #endregion

        #region ctor
        public DxInterface()
        {
            fetchTicketSvc = new FetchTicketSvc();
            _screenInfoService = new ScreenInfoService();
            _seatInfoService = new SeatInfoService();
            _filmInfoService = new FilmInfoService();
            _sessionInfoService = new SessionInfoService();
            _cinemaService = new CinemaService();
            _dxCodeIDService = new DXCodeIDService();
        }
        #endregion

        #region public methods
        /// <summary>
        /// 查询影院基本信息
        /// </summary>
        /// <param name="cinema"></param>
        /// <returns></returns>
        [CheckForNullArgumentsAspect]
        public CTMSQueryCinemaReply QueryCinema(UserCinemaViewEntity userCinema)
        {
            CTMSQueryCinemaReply reply = new CTMSQueryCinemaReply();

            //鼎新请求参数
            SortedDictionary<string, string> paramDic = new SortedDictionary<string, string>();
            paramDic.Add("format", "xml");
            paramDic.Add("cid", GetDXCinemaId(userCinema.CinemaCode));
            paramDic.Add("pid", userCinema.RealUserName);

            string queryCinemaResult = HttpHelper.VisitUrl(createVisitUrl(userCinema.Url,"/cinema/halls/",userCinema.RealPassword, FormatParam(paramDic)));

             DxQueryCinemaReply dxReply = queryCinemaResult.Deserialize<DxQueryCinemaReply>();

            if (dxReply.status == "1")
            {
                //更新影院信息
                CinemaEntity cinema = _cinemaService.GetCinemaByCinemaCode(userCinema.CinemaCode);
                //cinema.Name = dxReply.Cinema.CinemaName;
                //cinema.Address = dxReply.Cinema.Address;
                cinema.ScreenCount = dxReply.data.item.Count;
                _cinemaService.Update(cinema);
                //更新影厅信息
                var oldScreens = _screenInfoService.GetScreenListByCinemaCode(userCinema.CinemaCode);

                var newScreens = dxReply.data.item.Select(
                    x => x.MapToEntity(
                        oldScreens.Where(y => y.SCode == x.id).SingleOrDefault()
                            ?? new ScreenInfoEntity { CCode = userCinema.CinemaCode })).ToList();

                //插入或更新最新影厅信息
                _screenInfoService.BulkMerge(newScreens, oldScreens);

                reply.Status = StatusEnum.Success;

            }
            else
            {
                reply.Status = StatusEnum.Failure;
            }
            reply.ErrorCode = reply.ErrorCode;
            reply.ErrorMessage = reply.ErrorMessage;

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
            //鼎新的请求参数
            SortedDictionary<string, string> paramDic = new SortedDictionary<string, string>();
            paramDic.Add("format", "xml");
            paramDic.Add("cid", GetDXCinemaId(userCinema.CinemaCode));
            paramDic.Add("pid", userCinema.RealUserName);
            paramDic.Add("hall_id", screen.SCode);

            string querySeatResult = HttpHelper.VisitUrl(createVisitUrl(userCinema.Url, "/cinema/hall-seats/", userCinema.RealPassword, FormatParam(paramDic)));
            DxQuerySeatReply dxReply= querySeatResult.Deserialize<DxQuerySeatReply>();
            if (dxReply.status == "1")
            {
                var oldSeats = _seatInfoService.GetScreenSeats(userCinema.CinemaCode, screen.SCode).NotNull();

                var newSeats = dxReply.data.item.Select(
                    x => x.MapToEntity(
                        oldSeats.Where(y => y.SeatCode == x.cineSeatId).SingleOrDefault()
                            ?? new ScreenSeatInfoEntity
                            {
                                CinemaCode = userCinema.CinemaCode,
                                ScreenCode = screen.SCode,
                                LoveFlag = LoveFlagEnum.Normal.GetDescription()
                            })).ToList();
                //鼎新的loveseats用于标识情侣座，需要另外处理
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
                //处理完情侣座后将鼎新座位的所有GroupCode置为0000000000000001
                newSeats.ForEach(x => x.GroupCode = "0000000000000001");

                //插入或更新最新座位
                _seatInfoService.BulkMerge(newSeats, oldSeats);

                reply.Status = StatusEnum.Success;
            }
            else
            {
                reply.Status = StatusEnum.Failure;
            }
            reply.ErrorCode = dxReply.errorCode;
            reply.ErrorMessage = dxReply.errorMessage;

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

            reply.Status = StatusEnum.Failure;
            reply.ErrorCode = "-1";
            reply.ErrorMessage = "在售影片信息查询失败";

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

            //TODO

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

            //TODO

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
        #endregion

        #region private method
        private string GetDXCinemaId(string CinemaCode)
        {
            return _dxCodeIDService.GetDXCodeByCinemaCode(CinemaCode).Id;
        }
        private static string FormatParam(SortedDictionary<string, string> param)
        {
            string url = "";
            foreach (var key in param.Keys)
            {
                string value = param[key];
                if (value != null)
                    url += key + "=" + value.ToString() + "&";

            }
            if (url.Length > 0)
                url = url.Substring(0, url.Length - 1); //remove last '&'
            return url;
        }

        private string createVisitUrl(string middleUrl, string targetUrl,string pKeyInfo, string queryParams)
        {
            string sign = createSign(pKeyInfo,queryParams);
            return middleUrl + targetUrl + "?" + queryParams + "&_sig=" + sign;
        }
        private string createSign(string pKeyInfo,string queryParams)
        {
            return MD5Helper.MD5Encrypt(MD5Helper.MD5Encrypt(pKeyInfo + queryParams).ToLower() + pKeyInfo).ToLower();
        }
        #endregion
    }
}
