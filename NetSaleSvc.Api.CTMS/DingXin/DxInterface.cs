using NetSaleSvc.Api.CTMS.Models;
using NetSaleSvc.Entity.Enum;
using NetSaleSvc.Entity.Models;
using NetSaleSvc.Util;
using System;
using NetSaleSvc.Api.CTMS.DingXin.Models;
using NetSaleSvc.Service;
using System.Collections.Generic;
using System.Linq;

namespace NetSaleSvc.Api.CTMS.DingXin
{
    public class DxInterface : ICTMSInterface
    {
        #region private fields
        private ScreenInfoService _screenInfoService;
        private SeatInfoService _seatInfoService;
        private FilmInfoService _filmInfoService;
        private SessionInfoService _sessionInfoService;
        private CinemaService _cinemaService;
        #endregion

        #region ctor
        public DxInterface()
        {
            _screenInfoService = new ScreenInfoService();
            _seatInfoService = new SeatInfoService();
            _filmInfoService = new FilmInfoService();
            _sessionInfoService = new SessionInfoService();
            _cinemaService = new CinemaService();
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

            #region 鼎新影院Id为空的话先获取
            if (!userCinema.DingXinId.HasValue)
            {
                if (!QueryDingXinId(userCinema))
                {
                    reply.GetDingXinCinemaNotValidReply();
                    return reply;
                }
            }
            #endregion

            SortedDictionary<string, string> paramDic = new SortedDictionary<string, string>
            {
                { "format", "json" },
                { "cid", userCinema.DingXinId.ToString() },
                { "pid", userCinema.RealUserName }
            };

            string queryCinemaHallsResult = HttpHelper.VisitUrl(createVisitUrl(userCinema.Url,
                "/cinema/halls/", userCinema.RealPassword, FormatParam(paramDic)));

            DxQueryCinemaHallsReply dxReply = queryCinemaHallsResult.JsonDeserialize<DxQueryCinemaHallsReply>();

            if (dxReply.res.status == 1)
            {
                //更新影院信息
                CinemaEntity cinema = _cinemaService.GetCinemaByCinemaCode(userCinema.CinemaCode);
                cinema.ScreenCount = dxReply.res.data.Count;
                _cinemaService.Update(cinema);
                //更新影厅信息
                var oldScreens = _screenInfoService.GetScreenListByCinemaCode(userCinema.CinemaCode);

                var newScreens = dxReply.res.data.Select(
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
            reply.ErrorCode = dxReply.res.errorCode;
            reply.ErrorMessage = dxReply.res.errorMessage;

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

            #region 鼎新影院Id为空的话先获取
            if (!userCinema.DingXinId.HasValue)
            {
                if (!QueryDingXinId(userCinema))
                {
                    reply.GetDingXinCinemaNotValidReply();
                    return reply;
                }
            }
            #endregion

            SortedDictionary<string, string> paramDic = new SortedDictionary<string, string>
            {
                { "format", "json" },
                { "cid", userCinema.DingXinId.ToString() },
                { "pid", userCinema.RealUserName },
                { "hall_id", screen.SCode }
            };

            string queryHallSeatsResult = HttpHelper.VisitUrl(createVisitUrl(userCinema.Url,
                "/cinema/hall-seats/", userCinema.RealPassword, FormatParam(paramDic)));

            DxQueryHallSeatsReply dxReply = queryHallSeatsResult.JsonDeserialize<DxQueryHallSeatsReply>();

            if (dxReply.res.status == 1)
            {
                var oldSeats = _seatInfoService.GetScreenSeats(userCinema.CinemaCode, screen.SCode).NotNull();

                var newSeats = dxReply.res.data.Where(x => x.row != "0" && x.column != "0")    //排除走廊或过道
                    .Select(x => x.MapToEntity(
                        oldSeats.Where(y => y.SeatCode == x.cineSeatId).SingleOrDefault()
                            ?? new ScreenSeatInfoEntity
                            {
                                CinemaCode = userCinema.CinemaCode,
                                ScreenCode = screen.SCode,
                                LoveFlag = LoveFlagEnum.Normal.GetDescription()
                            })).ToList();
                //鼎新的loveseats用于标识情侣座，此处暂存入GroupCode，下面特殊处理
                var seatByGroup = newSeats.Where(x => !string.IsNullOrEmpty(x.GroupCode)).GroupBy(x => x.GroupCode);
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
                _seatInfoService.BulkMerge(newSeats, userCinema.CinemaCode, screen.SCode);

                reply.Status = StatusEnum.Success;
            }
            else
            {
                reply.Status = StatusEnum.Failure;
            }
            reply.ErrorCode = dxReply.res.errorCode;
            reply.ErrorMessage = dxReply.res.errorMessage;

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

            //鼎新没有获取影片接口，从排期中获取
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

            #region 鼎新影院Id为空的话先获取
            if (!userCinema.DingXinId.HasValue)
            {
                if (!QueryDingXinId(userCinema))
                {
                    reply.GetDingXinCinemaNotValidReply();
                    return reply;
                }
            }
            #endregion

            //将开始时间减1天以便能获取到当前早上6点之前的场次
            var start = StartDate.AddDays(-1);
            //将结束时间加上1天以便符合鼎新接口规范
            var end = EndDate.AddDays(1);

            SortedDictionary<string, string> paramDic = new SortedDictionary<string, string>
            {
                { "format", "json" },
                { "cid", userCinema.DingXinId.ToString() },
                { "pid", userCinema.RealUserName },
                { "start", start.ToFormatDateString() },
                { "end", end.ToFormatDateString() }
            };

            string queryCinemaPlaysResult = HttpHelper.VisitUrl(createVisitUrl(userCinema.Url,
                "/cinema/plays/", userCinema.RealPassword, FormatParam(paramDic)));

            DxQueryCinemaPlaysReply dxReply = queryCinemaPlaysResult.JsonDeserialize<DxQueryCinemaPlaysReply>();

            if (dxReply.res.status == 1)
            {
                var oldSessions = _sessionInfoService.GetSessions(userCinema.CinemaCode, userCinema.UserId, StartDate, EndDate);

                var newSessions = dxReply.res.data
                    .Select(x => x.MapToEntity(
                        oldSessions.Where(y => y.SCode == x.id).SingleOrDefault()
                            ?? new SessionInfoEntity
                            {
                                CCode = userCinema.CinemaCode,
                                SCode = x.id,
                                UserID = userCinema.UserId
                            })).Where(x => x.StartTime > StartDate && x.StartTime < EndDate.AddDays(1)).ToList();

                //插入或更新最新放映计划
                _sessionInfoService.BulkMerge(newSessions, userCinema.CinemaCode, StartDate, EndDate);

                reply.Status = StatusEnum.Success;
            }
            else
            {
                reply.Status = StatusEnum.Failure;
            }
            reply.ErrorCode = dxReply.res.errorCode;
            reply.ErrorMessage = dxReply.res.errorMessage;

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

            var session = _sessionInfoService.GetSessionInfo(userCinema.CinemaCode, SessionCode, userCinema.UserId);

            SortedDictionary<string, string> paramDic = new SortedDictionary<string, string>
            {
                { "format", "json" },
                { "cid", userCinema.DingXinId.ToString() },
                { "pid", userCinema.RealUserName },
                { "play_id", SessionCode },
                { "play_update_time", session?.DingXinUpdateTime ?? string.Empty }
            };

            string querySeatStatusResult = HttpHelper.VisitUrl(createVisitUrl(userCinema.Url,
                "/play/seat-status/", userCinema.RealPassword, FormatParam(paramDic)));

            DxQuerySeatStatusReply dxReply = querySeatStatusResult.JsonDeserialize<DxQuerySeatStatusReply>();

            if (dxReply.res.status == 1)
            {
                var sessionSeats = dxReply.res.data
                    //去除过道或走廊
                    .Where(x => x.rowValue != "0" && x.columnValue != "0")
                    .Select(x => new SessionSeatEntity
                    {
                        SeatCode = x.cineSeatId,
                        RowNum = x.rowValue,
                        ColumnNum = x.columnValue,
                        Status = getSessionSeatStatus(x.seatStatus)
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
            reply.ErrorCode = dxReply.res.errorCode;
            reply.ErrorMessage = dxReply.res.errorMessage;

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

            var session = _sessionInfoService.GetSessionInfo(userCinema.CinemaCode, order.orderBaseInfo.SessionCode, userCinema.UserId);
            SortedDictionary<string, string> paramDic = new SortedDictionary<string, string>
            {
                { "format", "json" },
                { "cid", userCinema.DingXinId.ToString() },
                { "pid", userCinema.RealUserName },
                { "play_id", order.orderBaseInfo.SessionCode },
                { "seat_id", string.Join(",", order.orderSeatDetails.Select(x => x.SeatCode)) },
                { "play_update_time", session?.DingXinUpdateTime ?? string.Empty }
            };

            string lockSeatResult = HttpHelper.VisitUrl(createVisitUrl(userCinema.Url,
                "/seat/lock/", userCinema.RealPassword, FormatParam(paramDic)));

            DxLockSeatReply dxReply = lockSeatResult.JsonDeserialize<DxLockSeatReply>();

            if (dxReply.res.status == 1)
            {
                //鼎新订单号由自己生成
                order.orderBaseInfo.LockOrderCode = DateTime.Now.ToString("yyyyMMddHHmmssfff" + RandomHelper.CreatePwd(3));
                order.orderBaseInfo.AutoUnlockDatetime = DateTime.Now.AddMinutes(10);    //鼎新没有自动解锁时间返回，此处默认锁定10分钟
                order.orderBaseInfo.SerialNum = dxReply.res.data.lockFlag;
                order.orderBaseInfo.LockTime = DateTime.Now;
                order.orderBaseInfo.OrderStatus = OrderStatusEnum.Locked;

                reply.Status = StatusEnum.Success;
            }
            else
            {
                order.orderBaseInfo.OrderStatus = OrderStatusEnum.LockFail;
                order.orderBaseInfo.ErrorMessage = dxReply.res.errorMessage;

                reply.Status = StatusEnum.Failure;
            }
            reply.ErrorCode = dxReply.res.errorCode;
            reply.ErrorMessage = dxReply.res.errorMessage;

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

            SortedDictionary<string, string> paramDic = new SortedDictionary<string, string>
            {
                { "format", "json" },
                { "cid", userCinema.DingXinId.ToString() },
                { "pid", userCinema.RealUserName },
                { "play_id", order.orderBaseInfo.SessionCode },
                { "seat_id", string.Join(",", order.orderSeatDetails.Select(x => x.SeatCode)) },
                { "lock_flag", order.orderBaseInfo.SerialNum }
            };

            string unlockSeatResult = HttpHelper.VisitUrl(createVisitUrl(userCinema.Url,
                "/seat/unlock/", userCinema.RealPassword, FormatParam(paramDic)));

            DxUnlockSeatReply dxReply = unlockSeatResult.JsonDeserialize<DxUnlockSeatReply>();

            if (dxReply.res.status == 1)
            {
                if (dxReply.res.data.unlock)
                {
                    order.orderBaseInfo.OrderStatus = OrderStatusEnum.Released;
                    reply.Status = StatusEnum.Success;
                }
                else
                {
                    reply.Status = StatusEnum.Failure;
                }
            }
            else
            {
                order.orderBaseInfo.OrderStatus = OrderStatusEnum.ReleaseFail;
                order.orderBaseInfo.ErrorMessage = dxReply.res.errorMessage;

                reply.Status = StatusEnum.Failure;
            }
            reply.ErrorCode = dxReply.res.errorCode;
            reply.ErrorMessage = dxReply.res.errorMessage;

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

            var session = _sessionInfoService.GetSessionInfo(userCinema.CinemaCode, order.orderBaseInfo.SessionCode, userCinema.UserId);
            SortedDictionary<string, string> paramDic = new SortedDictionary<string, string>
            {
                { "format", "json" },
                { "cid", userCinema.DingXinId.ToString() },
                { "pid", userCinema.RealUserName },
                { "play_id", order.orderBaseInfo.SessionCode },
                { "seat", string.Join(",", order.orderSeatDetails.Select(x =>
                    string.Join("-", new string[]
                        {
                            x.SeatCode,
                            x.Fee.ToString("0.##"),
                            x.Price.ToString("0.##")
                        })))
                },
                { "lock_flag", order.orderBaseInfo.SerialNum },
                { "play_update_time", session?.DingXinUpdateTime ?? string.Empty },
                { "partner_buy_ticket_id", order.orderBaseInfo.LockOrderCode },
                { "mobile", order.orderBaseInfo.MobilePhone },
            };

            string lockBuyResult = HttpHelper.VisitUrl(createVisitUrl(userCinema.Url,
                "/seat/lock-buy/", userCinema.RealPassword, FormatParam(paramDic)));

            DxLockBuyReply dxReply = lockBuyResult.JsonDeserialize<DxLockBuyReply>();

            if (dxReply.res.status == 1)
            {
                //提交订单号默认为锁座订单号
                order.orderBaseInfo.SubmitOrderCode = order.orderBaseInfo.LockOrderCode;
                order.orderBaseInfo.PrintNo = dxReply.res.data.ticketFlag1;
                order.orderBaseInfo.VerifyCode = dxReply.res.data.ticketFlag2;
                order.orderSeatDetails.ForEach(x =>
                {
                    var newSeat = dxReply.res.data.sellInfo.Where(y => y.seatId == x.SeatCode).SingleOrDefault();
                    if (newSeat != null)
                    {
                        x.FilmTicketCode = newSeat.sellId;
                    }
                });
                order.orderBaseInfo.OrderStatus = OrderStatusEnum.Complete;
                order.orderBaseInfo.SubmitTime = DateTime.Now;
                reply.Status = StatusEnum.Success;
            }
            else
            {
                order.orderBaseInfo.OrderStatus = OrderStatusEnum.SubmitFail;
                order.orderBaseInfo.ErrorMessage = dxReply.res.errorMessage;

                reply.Status = StatusEnum.Failure;
            }
            reply.ErrorCode = dxReply.res.errorCode;
            reply.ErrorMessage = dxReply.res.errorMessage;

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

            var queryTicketReply = QueryTicket(userCinema, order);

            reply.Status = queryTicketReply.Status;
            reply.ErrorCode = queryTicketReply.ErrorCode;
            reply.ErrorMessage = queryTicketReply.ErrorMessage;

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

            SortedDictionary<string, string> paramDic = new SortedDictionary<string, string>
            {
                { "format", "json" },
                { "cid", userCinema.DingXinId.ToString() },
                { "pid", userCinema.RealUserName },
                { "ticket_flag1", order.orderBaseInfo.PrintNo },
                { "ticket_flag2", order.orderBaseInfo.VerifyCode },
                { "partner_refund_ticket_id", order.orderBaseInfo.SubmitOrderCode }
            };

            string ticketRefundResult = HttpHelper.VisitUrl(createVisitUrl(userCinema.Url,
                "/ticket/refund/", userCinema.RealPassword, FormatParam(paramDic)));

            DxTicketRefundReply dxReply = ticketRefundResult.JsonDeserialize<DxTicketRefundReply>();

            if (dxReply.res.status == 1)
            {
                order.orderBaseInfo.OrderStatus = OrderStatusEnum.Refund;
                order.orderBaseInfo.RefundTime = DateTime.Now;

                reply.Status = StatusEnum.Success;
            }
            else
            {
                reply.Status = StatusEnum.Failure;
            }
            reply.ErrorCode = dxReply.res.errorCode;
            reply.ErrorMessage = dxReply.res.errorMessage;

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

            var queryTicketReply = QueryTicket(userCinema, order);

            reply.Status = queryTicketReply.Status;
            reply.ErrorCode = queryTicketReply.ErrorCode;
            reply.ErrorMessage = queryTicketReply.ErrorMessage;

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

            SortedDictionary<string, string> paramDic = new SortedDictionary<string, string>
            {
                { "format", "json" },
                { "cid", userCinema.DingXinId.ToString() },
                { "pid", userCinema.RealUserName },
                { "ticket_flag1", order.orderBaseInfo.PrintNo },
                { "ticket_flag2", order.orderBaseInfo.VerifyCode }
            };

            string ticketInfoResult = HttpHelper.VisitUrl(createVisitUrl(userCinema.Url,
                "/ticket/info/", userCinema.RealPassword, FormatParam(paramDic)));

            DxQueryTicketInfoReply dxReply = ticketInfoResult.JsonDeserialize<DxQueryTicketInfoReply>();

            if (dxReply.res.status == 1)
            {
                if (dxReply.res.data.ticketInfo != null && dxReply.res.data.ticketInfo.Count > 0)
                {
                    order.orderSeatDetails.ForEach(x =>
                    {
                        var ticket = dxReply.res.data.ticketInfo.Where(y => y.no == x.FilmTicketCode).SingleOrDefault();
                        if (ticket != null)
                        {
                            x.TicketInfoCode = ticket.qrCode;
                            byte printFlag = 0;
                            if (byte.TryParse(ticket.printed, out printFlag))
                            {
                                x.PrintFlag = printFlag;
                            }
                        }
                    });

                    var firstTicket = dxReply.res.data.ticketInfo.First();
                    order.orderBaseInfo.PrintStatus = firstTicket.printed == "1" ? YesOrNoEnum.Yes : YesOrNoEnum.No;
                    if (order.orderBaseInfo.PrintStatus == YesOrNoEnum.Yes)
                    {
                        order.orderBaseInfo.PrintTime = DateTime.Parse(firstTicket.printTime);
                    }

                    //退票状态
                    if (firstTicket.ticketStatus == 3)
                    {
                        order.orderBaseInfo.OrderStatus = OrderStatusEnum.Refund;
                        order.orderBaseInfo.RefundTime = DateTime.Now;
                    }
                }

                reply.Status = StatusEnum.Success;
            }
            else
            {
                reply.Status = StatusEnum.Failure;
            }
            reply.ErrorCode = dxReply.res.errorCode;
            reply.ErrorMessage = dxReply.res.errorMessage;

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

            SortedDictionary<string, string> paramDic = new SortedDictionary<string, string>
            {
                { "format", "json" },
                { "cid", userCinema.DingXinId.ToString() },
                { "pid", userCinema.RealUserName },
                { "ticket_flag1", order.orderBaseInfo.PrintNo },
                { "ticket_flag2", order.orderBaseInfo.VerifyCode }
            };

            string ticketPrintResult = HttpHelper.VisitUrl(createVisitUrl(userCinema.Url,
                "/ticket/print/", userCinema.RealPassword, FormatParam(paramDic)));

            DxTicketPrintReply dxReply = ticketPrintResult.JsonDeserialize<DxTicketPrintReply>();

            if (dxReply.res.status == 1)
            {
                order.orderBaseInfo.PrintStatus = YesOrNoEnum.Yes;
                order.orderBaseInfo.PrintTime = DateTime.Now;

                reply.Status = StatusEnum.Success;
            }
            else
            {
                reply.Status = StatusEnum.Failure;
            }
            reply.ErrorCode = dxReply.res.errorCode;
            reply.ErrorMessage = dxReply.res.errorMessage;

            return reply;
        }
        #endregion

        #region private method
        /// <summary>
        /// 获取鼎新影院Id
        /// </summary>
        /// <param name="userCinema"></param>
        /// <returns></returns>
        private bool QueryDingXinId(UserCinemaViewEntity userCinema)
        {
            SortedDictionary<string, string> queryPartnerCinemasParams = new SortedDictionary<string, string>
            {
                { "format", "json" },
                { "pid", userCinema.RealUserName }
            };

            string queryPartnerCinemasResult = HttpHelper.VisitUrl(createVisitUrl(userCinema.Url, "/partner/cinemas/",
                userCinema.RealPassword, FormatParam(queryPartnerCinemasParams)));

            DxQueryPartnerCinemasReply queryPartnerCinemasReply = queryPartnerCinemasResult.JsonDeserialize<DxQueryPartnerCinemasReply>();

            if (queryPartnerCinemasReply.res.status == 1)
            {
                var dxCinema = queryPartnerCinemasReply.res.data.NotNull()
                    .Where(x => x.cinemaNumber == userCinema.CinemaCode).SingleOrDefault();
                if (dxCinema != null)
                {
                    CinemaEntity cinema = _cinemaService.GetCinemaByCinemaCode(userCinema.CinemaCode);
                    cinema.Name = dxCinema.cinemaName;
                    cinema.DingXinId = dxCinema.cinemaId;
                    _cinemaService.Update(cinema);

                    userCinema.DingXinId = dxCinema.cinemaId;

                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 参数格式化
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        private static string FormatParam(SortedDictionary<string, string> param)
        {
            string queryParams = "";
            foreach (var key in param.Keys)
            {
                string value = param[key];
                if (value != null)
                    queryParams += key + "=" + value.ToString() + "&";

            }
            if (queryParams.Length > 0)
                queryParams = queryParams.Substring(0, queryParams.Length - 1); //remove last '&'
            return queryParams;
        }

        /// <summary>
        /// 生成鼎新请求Url
        /// </summary>
        /// <param name="url"></param>
        /// <param name="path"></param>
        /// <param name="authCode"></param>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        private string createVisitUrl(string url, string path, string authCode, string queryParams)
        {
            string sign = createSign(authCode, queryParams);
            return url.TrimEnd('/') + path + "?" + queryParams + "&_sig=" + sign;
        }

        /// <summary>
        /// 生成鼎新签名参数
        /// </summary>
        /// <param name="pKeyInfo"></param>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        private string createSign(string pKeyInfo, string queryParams)
        {
            return MD5Helper.MD5Encrypt(MD5Helper.MD5Encrypt(pKeyInfo + queryParams).ToLower() + pKeyInfo).ToLower();
        }

        /// <summary>
        /// 鼎新排期座位状态转换
        /// </summary>
        /// <param name="seatState"></param>
        /// <returns></returns>
        private SessionSeatStatusEnum getSessionSeatStatus(string seatState)
        {
            switch (seatState)
            {
                case "repair":
                    return SessionSeatStatusEnum.Unavailable;
                case "ok":
                    return SessionSeatStatusEnum.Available;
                case "selled":
                    return SessionSeatStatusEnum.Sold;
                case "booked":
                    return SessionSeatStatusEnum.Booked;
                case "locked":
                    return SessionSeatStatusEnum.Locked;
                default:
                    return SessionSeatStatusEnum.Unavailable;
            }
        }
        #endregion
    }
}
