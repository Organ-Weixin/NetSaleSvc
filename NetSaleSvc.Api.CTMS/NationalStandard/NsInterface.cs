using NetSaleSvc.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetSaleSvc.Api.CTMS.NationalStandardService;
using NetSaleSvc.Api.CTMS.NationalStandard.Models;
using NetSaleSvc.Util;
using NetSaleSvc.Entity.Enum;
using NetSaleSvc.Service;
using NetSaleSvc.Api.CTMS.Models;

namespace NetSaleSvc.Api.CTMS.NationalStandard
{
    /// <summary>
    /// 直连接口
    /// </summary>
    public class NsInterface : ICTMSInterface
    {
        #region private fields
        private NsService nsService;
        private ScreenInfoService _screenInfoService;
        private SeatInfoService _seatInfoService;
        private FilmInfoService _filmInfoService;
        private SessionInfoService _sessionInfoService;
        #endregion

        #region ctor
        public NsInterface()
        {
            nsService = new NsService();
            _screenInfoService = new ScreenInfoService();
            _seatInfoService = new SeatInfoService();
            _filmInfoService = new FilmInfoService();
            _sessionInfoService = new SessionInfoService();
        }
        #endregion

        #region public methods
        /// <summary>
        /// 获取影院基础信息
        /// </summary>
        /// <param name="cinema"></param>
        /// <returns></returns>
        [CheckForNullArgumentsAspect]
        public CTMSQueryCinemaReply QueryCinema(UserCinemaViewEntity userCinema)
        {
            CTMSQueryCinemaReply queryCinemaReply = new CTMSQueryCinemaReply();

            string queryCinemaResult = nsService.QueryCinema(userCinema.RealUserName, userCinema.RealPassword,
                userCinema.Url, string.Empty, userCinema.CinemaCode);
            nsOnlineTicketingServiceReply reply = queryCinemaResult.Deserialize<nsOnlineTicketingServiceReply>();

            if (reply.QueryCinemaReply.Status == StatusEnum.Success.GetDescription())
            {
                SaveScreenInfos(userCinema.CinemaCode, reply);
                queryCinemaReply.Status = StatusEnum.Success;
            }
            else
            {
                queryCinemaReply.Status = StatusEnum.Failure;
            }

            queryCinemaReply.ErrorCode = reply.QueryCinemaReply.ErrorCode;
            queryCinemaReply.ErrorMessage = reply.QueryCinemaReply.ErrorMessage;

            return queryCinemaReply;
        }

        /// <summary>
        /// 获取影院基础信息
        /// </summary>
        /// <param name="userCinema"></param>
        /// <param name="screen"></param>
        /// <returns></returns>
        [CheckForNullArgumentsAspect]
        public CTMSQuerySeatReply QuerySeat(UserCinemaViewEntity userCinema, ScreenInfoEntity screen)
        {
            CTMSQuerySeatReply querySeatReply = new CTMSQuerySeatReply();

            string querySeatResult = nsService.QuerySeat(userCinema.RealUserName, userCinema.RealPassword,
                userCinema.Url, string.Empty, userCinema.CinemaCode, screen.SCode);

            nsOnlineTicketingServiceReply reply = querySeatResult.Deserialize<nsOnlineTicketingServiceReply>();

            if (reply.QuerySeatReply.Status == StatusEnum.Success.GetDescription())
            {
                SaveSeatInfos(userCinema.CinemaCode, screen.SCode, reply);
                querySeatReply.Status = StatusEnum.Success;
            }
            else
            {
                querySeatReply.Status = StatusEnum.Failure;
            }

            querySeatReply.ErrorCode = reply.QuerySeatReply.ErrorCode;
            querySeatReply.ErrorMessage = reply.QuerySeatReply.ErrorMessage;

            return querySeatReply;
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
            CTMSQueryFilmReply queryFilmReply = new CTMSQueryFilmReply();

            string queryFilmResult = nsService.QueryFilm(userCinema.RealUserName, userCinema.RealPassword,
                userCinema.Url, string.Empty, StartDate, EndDate);

            nsOnlineTicketingServiceReply reply = queryFilmResult.Deserialize<nsOnlineTicketingServiceReply>();

            if (reply.QueryFilmReply.Status == StatusEnum.Success.GetDescription())
            {
                var FilmCodes = reply.QueryFilmReply.Films.Film.Select(x => x.Code);
                var ExitedFilms = _filmInfoService.GetFilmInfosByCodes(FilmCodes);

                var entities = reply.QueryFilmReply.Films.Film.Select(x => x.MapToEntity(
                    ExitedFilms.Where(y => y.FilmCode == x.Code).SingleOrDefault() ?? new FilmInfoEntity()));

                _filmInfoService.BulkMerge(entities, ExitedFilms);

                queryFilmReply.Status = StatusEnum.Success;
                queryFilmReply.films = entities;
            }
            else
            {
                queryFilmReply.Status = StatusEnum.Failure;
            }

            queryFilmReply.ErrorCode = reply.QueryFilmReply.ErrorCode;
            queryFilmReply.ErrorMessage = reply.QueryFilmReply.ErrorMessage;

            return queryFilmReply;
        }

        /// <summary>
        /// 查询放映计划
        /// </summary>
        /// <param name="userCinema"></param>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        [CheckForNullArgumentsAspect]
        public CTMSQuerySessionReply QuerySession(UserCinemaViewEntity userCinema, DateTime StartDate, DateTime EndDate)
        {
            CTMSQuerySessionReply querySessionReply = new CTMSQuerySessionReply();

            string querySessionResult = nsService.QuerySession(userCinema.RealUserName, userCinema.RealPassword,
                userCinema.Url, string.Empty, userCinema.CinemaCode, StartDate, EndDate);

            nsOnlineTicketingServiceReply reply = querySessionResult.Deserialize<nsOnlineTicketingServiceReply>();

            if (reply.QuerySessionReply.Status == StatusEnum.Success.GetDescription())
            {
                SaveSessions(userCinema, StartDate, EndDate, reply);
                querySessionReply.Status = StatusEnum.Success;
            }
            else
            {
                querySessionReply.Status = StatusEnum.Failure;
            }

            querySessionReply.ErrorCode = reply.QuerySessionReply.ErrorCode;
            querySessionReply.ErrorMessage = reply.QuerySessionReply.ErrorMessage;

            return querySessionReply;
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
            string querySessionSeatResult = nsService.QuerySessionSeat(userCinema.RealUserName, userCinema.RealPassword,
                userCinema.Url, string.Empty, userCinema.CinemaCode, SessionCode, Status.GetDescription());

            nsOnlineTicketingServiceReply reply = querySessionSeatResult.Deserialize<nsOnlineTicketingServiceReply>();

            CTMSQuerySessionSeatReply querySessionSeatReply = new CTMSQuerySessionSeatReply();
            if (reply.QuerySessionSeatReply.Status == StatusEnum.Success.GetDescription())
            {
                querySessionSeatReply.SessionSeats = reply.QuerySessionSeatReply.SessionSeat.Seat.Select(x =>
                    new SessionSeatEntity
                    {
                        SeatCode = x.Code,
                        RowNum = x.RowNum,
                        ColumnNum = x.ColumnNum,
                        Status = x.Status.CastToEnum<SessionSeatStatusEnum>()
                    });

                querySessionSeatReply.Status = StatusEnum.Success;
            }
            else
            {
                querySessionSeatReply.Status = StatusEnum.Failure;
            }

            querySessionSeatReply.ErrorCode = reply.QuerySessionSeatReply.ErrorCode;
            querySessionSeatReply.ErrorMessage = reply.QuerySessionSeatReply.ErrorMessage;

            return querySessionSeatReply;
        }

        /// <summary>
        /// 锁定座位
        /// </summary>
        /// <param name="userCinema"></param>
        /// <param name="QueryXml"></param>
        /// <returns></returns>
        public CTMSLockSeatReply LockSeat(UserCinemaViewEntity userCinema, OrderViewEntity order)
        {
            CTMSLockSeatReply lockSeatReply = new CTMSLockSeatReply();

            string SeatCodes = string.Join("|", order.orderSeatDetails.Select(x => x.SeatCode));
            string lockSeatResult = nsService.LockSeat(userCinema.RealUserName, userCinema.RealPassword,
                userCinema.Url, string.Empty, order.orderBaseInfo.CinemaCode, order.orderBaseInfo.SessionCode, SeatCodes);

            nsOnlineTicketingServiceReply reply = lockSeatResult.Deserialize<nsOnlineTicketingServiceReply>();

            if (reply.LockSeatReply.Status == StatusEnum.Success.GetDescription())
            {
                order.orderBaseInfo.LockOrderCode = reply.LockSeatReply.Order.OrderCode;
                order.orderBaseInfo.AutoUnlockDatetime = reply.LockSeatReply.Order.AutoUnlockDatetime;
                order.orderBaseInfo.LockTime = DateTime.Now;
                order.orderBaseInfo.OrderStatus = OrderStatusEnum.Locked;

                lockSeatReply.Status = StatusEnum.Success;
            }
            else
            {
                order.orderBaseInfo.OrderStatus = OrderStatusEnum.LockFail;
                order.orderBaseInfo.ErrorMessage = reply.LockSeatReply.ErrorMessage;
                lockSeatReply.Status = StatusEnum.Failure;
            }

            lockSeatReply.ErrorCode = reply.LockSeatReply.ErrorCode;
            lockSeatReply.ErrorMessage = reply.LockSeatReply.ErrorMessage;

            return lockSeatReply;
        }

        /// <summary>
        /// 解锁座位
        /// </summary>
        /// <param name="userCinema"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public CTMSReleaseSeatReply ReleaseSeat(UserCinemaViewEntity userCinema, OrderViewEntity order)
        {
            CTMSReleaseSeatReply releaseSeatReply = new CTMSReleaseSeatReply();

            string SeatCodes = string.Join("|", order.orderSeatDetails.Select(x => x.SeatCode));
            string releaseSeatResult = nsService.ReleaseSeat(userCinema.RealUserName, userCinema.RealPassword,
                userCinema.Url, string.Empty, order.orderBaseInfo.CinemaCode, order.orderBaseInfo.SessionCode,
                order.orderBaseInfo.LockOrderCode, SeatCodes);

            nsOnlineTicketingServiceReply reply = releaseSeatResult.Deserialize<nsOnlineTicketingServiceReply>();

            if (reply.ReleaseSeatReply.Status == StatusEnum.Success.GetDescription())
            {
                order.orderBaseInfo.OrderStatus = OrderStatusEnum.Released;
                releaseSeatReply.Status = StatusEnum.Success;
            }
            else
            {
                order.orderBaseInfo.OrderStatus = OrderStatusEnum.ReleaseFail;
                order.orderBaseInfo.ErrorMessage = reply.ReleaseSeatReply.ErrorMessage;
                releaseSeatReply.Status = StatusEnum.Failure;
            }

            releaseSeatReply.ErrorCode = reply.ReleaseSeatReply.ErrorCode;
            releaseSeatReply.ErrorMessage = reply.ReleaseSeatReply.ErrorMessage;

            return releaseSeatReply;
        }

        /// <summary>
        /// 提交订单
        /// </summary>
        /// <param name="userCinema"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public CTMSSubmitOrderReply SubmitOrder(UserCinemaViewEntity userCinema, OrderViewEntity order)
        {
            CTMSSubmitOrderReply submitOrderReply = new CTMSSubmitOrderReply();

            string SeatCodes = string.Join("|", order.orderSeatDetails.Select(x => x.SeatCode));
            string Prices = string.Join("|", order.orderSeatDetails.Select(x => (x.Price + x.Fee)));
            string submitOrderResult = nsService.SubmitOrder(userCinema.RealUserName, userCinema.RealPassword,
                userCinema.Url, string.Empty, userCinema.CinemaCode, order.orderBaseInfo.SessionCode,
                order.orderBaseInfo.LockOrderCode, SeatCodes, Prices);

            nsOnlineTicketingServiceReply reply = submitOrderResult.Deserialize<nsOnlineTicketingServiceReply>();

            if (reply.SubmitOrderReply.Status == StatusEnum.Success.GetDescription())
            {
                order.orderBaseInfo.SubmitOrderCode = reply.SubmitOrderReply.Order.OrderCode;
                order.orderBaseInfo.PrintNo = reply.SubmitOrderReply.Order.PrintNo;
                order.orderBaseInfo.VerifyCode = reply.SubmitOrderReply.Order.VerifyCode;
                order.orderSeatDetails.ForEach(x =>
                {
                    var newSeat = reply.SubmitOrderReply.Order.Seat.Where(y => y.SeatCode == x.SeatCode).SingleOrDefault();
                    x.FilmTicketCode = newSeat.FilmTicketCode;
                });
                order.orderBaseInfo.OrderStatus = OrderStatusEnum.Complete;
                order.orderBaseInfo.SubmitTime = DateTime.Now;
                submitOrderReply.Status = StatusEnum.Success;
            }
            else
            {
                order.orderBaseInfo.OrderStatus = OrderStatusEnum.SubmitFail;
                order.orderBaseInfo.ErrorMessage = reply.SubmitOrderReply.ErrorMessage;
                submitOrderReply.Status = StatusEnum.Failure;
            }

            submitOrderReply.ErrorCode = reply.SubmitOrderReply.ErrorCode;
            submitOrderReply.ErrorMessage = reply.SubmitOrderReply.ErrorMessage;

            return submitOrderReply;
        }

        /// <summary>
        /// 查询出票状态
        /// </summary>
        /// <param name="userCinema"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public CTMSQueryPrintReply QueryPrint(UserCinemaViewEntity userCinema, OrderViewEntity order)
        {
            CTMSQueryPrintReply queryPrintReply = new CTMSQueryPrintReply();

            string queryPrintResult = nsService.QueryPrint(userCinema.RealUserName, userCinema.RealPassword,
                userCinema.Url, string.Empty, userCinema.CinemaCode, order.orderBaseInfo.PrintNo, order.orderBaseInfo.VerifyCode);

            nsOnlineTicketingServiceReply reply = queryPrintResult.Deserialize<nsOnlineTicketingServiceReply>();

            if (reply.QueryPrintReply.Status == StatusEnum.Success.GetDescription())
            {
                order.orderBaseInfo.PrintStatus = reply.QueryPrintReply.Order.Status;
                if (order.orderBaseInfo.PrintStatus == YesOrNoEnum.Yes)
                {
                    order.orderBaseInfo.PrintTime = DateTime.Parse(reply.QueryPrintReply.Order.PrintTime);
                }
                queryPrintReply.Status = StatusEnum.Success;
            }
            else
            {
                queryPrintReply.Status = StatusEnum.Failure;
            }

            queryPrintReply.ErrorCode = reply.QueryPrintReply.ErrorCode;
            queryPrintReply.ErrorMessage = reply.QueryPrintReply.ErrorMessage;

            return queryPrintReply;
        }

        /// <summary>
        /// 退票
        /// </summary>
        /// <param name="userCinema"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public CTMSRefundTicketReply RefundTicket(UserCinemaViewEntity userCinema, OrderViewEntity order)
        {
            CTMSRefundTicketReply refundTicketReply = new CTMSRefundTicketReply();

            string refundTicketResult = nsService.RefundTicket(userCinema.RealUserName, userCinema.RealPassword,
                userCinema.Url, string.Empty, userCinema.CinemaCode, order.orderBaseInfo.PrintNo, order.orderBaseInfo.VerifyCode);

            nsOnlineTicketingServiceReply reply = refundTicketResult.Deserialize<nsOnlineTicketingServiceReply>();

            if (reply.RefundTicketReply.Status == StatusEnum.Success.GetDescription())
            {
                if (reply.RefundTicketReply.Order.Status == YesOrNoEnum.Yes)
                {
                    order.orderBaseInfo.OrderStatus = OrderStatusEnum.Refund;
                    order.orderBaseInfo.RefundTime = DateTime.Parse(reply.RefundTicketReply.Order.RefundTime);
                }
                refundTicketReply.Status = StatusEnum.Success;
            }
            else
            {
                refundTicketReply.Status = StatusEnum.Failure;
            }

            refundTicketReply.ErrorCode = reply.RefundTicketReply.ErrorCode;
            refundTicketReply.ErrorMessage = reply.RefundTicketReply.ErrorMessage;


            return refundTicketReply;
        }

        /// <summary>
        /// 查询订单信息
        /// </summary>
        /// <param name="userCinema"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public CTMSQueryOrderReply QueryOrder(UserCinemaViewEntity userCinema, OrderViewEntity order)
        {
            CTMSQueryOrderReply queryOrderReply = new CTMSQueryOrderReply();

            string queryOrderResult = nsService.QueryOrder(userCinema.RealUserName, userCinema.RealPassword,
                userCinema.Url, string.Empty, userCinema.CinemaCode, order.orderBaseInfo.SubmitOrderCode);

            nsOnlineTicketingServiceReply reply = queryOrderResult.Deserialize<nsOnlineTicketingServiceReply>();

            if (reply.QueryOrderReply.Status == StatusEnum.Success.GetDescription())
            {
                var firstSeat = reply.QueryOrderReply.Order.Seats.Seat.FirstOrDefault() ?? new nsQueryOrderReplySeat();
                if (firstSeat.PrintStatus == YesOrNoEnum.Yes)
                {
                    order.orderBaseInfo.PrintStatus = YesOrNoEnum.Yes;
                    DateTime printTime;
                    if (DateTime.TryParse(firstSeat.PrintTime, out printTime))
                    {
                        order.orderBaseInfo.PrintTime = printTime;
                    }
                    else
                    {
                        order.orderBaseInfo.PrintTime = DateTime.Now;
                    }
                }

                if (firstSeat.RefundStatus == YesOrNoEnum.Yes)
                {
                    order.orderBaseInfo.OrderStatus = OrderStatusEnum.Refund;
                    DateTime refundTime;
                    if (DateTime.TryParse(firstSeat.RefundTime, out refundTime))
                    {
                        order.orderBaseInfo.RefundTime = refundTime;
                    }
                    else
                    {
                        order.orderBaseInfo.RefundTime = DateTime.Now;
                    }
                }
                queryOrderReply.Status = StatusEnum.Success;
            }
            else
            {
                queryOrderReply.Status = StatusEnum.Failure;
            }

            queryOrderReply.ErrorCode = reply.QueryOrderReply.ErrorCode;
            queryOrderReply.ErrorMessage = reply.QueryOrderReply.ErrorMessage;

            return queryOrderReply;
        }
        #endregion

        #region private methods
        /// <summary>
        /// 保存影厅信息
        /// </summary>
        /// <param name="userCinema"></param>
        /// <param name="reply"></param>
        private void SaveScreenInfos(string CinemaCode, nsOnlineTicketingServiceReply reply)
        {
            var oldScreens = _screenInfoService.GetScreenListByCinemaCode(CinemaCode);

            var newScreens = reply.QueryCinemaReply.Cinema.Screen.Select(
                x => x.MapToEntity(
                    oldScreens.Where(y => y.SCode == x.Code).SingleOrDefault()
                        ?? new ScreenInfoEntity { CCode = CinemaCode })).ToList();

            //插入或更新最新影厅信息
            _screenInfoService.BulkMerge(newScreens, oldScreens);
        }

        /// <summary>
        /// 保存影厅座位信息
        /// </summary>
        /// <param name="CinemaCode"></param>
        /// <param name="ScreenCode"></param>
        /// <param name="reply"></param>
        private void SaveSeatInfos(string CinemaCode, string ScreenCode, nsOnlineTicketingServiceReply reply)
        {
            var oldSeats = _seatInfoService.GetScreenSeats(CinemaCode, ScreenCode).NotNull();

            var newSeats = reply.QuerySeatReply.Cinema.Screen.Seat.Select(
                x => x.MapToEntity(
                    oldSeats.Where(y => y.GroupCode == x.GroupCode && y.SeatCode == x.Code).SingleOrDefault()
                        ?? new ScreenSeatInfoEntity
                        {
                            CinemaCode = CinemaCode,
                            ScreenCode = ScreenCode,
                            LoveFlag = "N"
                        })).ToList();

            //插入或更新最新座位
            _seatInfoService.BulkMerge(newSeats, oldSeats);
        }

        /// <summary>
        /// 保存排期
        /// </summary>
        /// <param name="CinemaCode"></param>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="reply"></param>
        private void SaveSessions(UserCinemaViewEntity userCinema, DateTime StartDate, DateTime EndDate, nsOnlineTicketingServiceReply reply)
        {
            var oldSessions = _sessionInfoService.GetSessions(userCinema.CinemaCode, userCinema.UserId, StartDate, EndDate);

            var newSessions = reply.QuerySessionReply.Sessions.Session.Select(
                x => x.MapToEntity(
                    oldSessions.Where(y => y.SCode == x.Code).SingleOrDefault()
                        ?? new SessionInfoEntity
                        {
                            CCode = userCinema.CinemaCode,
                            SCode = x.Code,
                            UserID = userCinema.UserId
                        })).ToList();

            //插入或更新最新放映计划
            _sessionInfoService.BulkMerge(newSessions, oldSessions);
        }
        #endregion
    }
}
