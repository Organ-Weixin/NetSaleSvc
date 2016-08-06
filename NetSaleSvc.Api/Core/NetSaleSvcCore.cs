using NetSaleSvc.Api.Extension;
using NetSaleSvc.Api.Models;
using NetSaleSvc.Api.CTMS;
using NetSaleSvc.Entity.Models;
using NetSaleSvc.Service;
using System;
using System.Linq;
using NetSaleSvc.Util;
using NetSaleSvc.Entity.Enum;
using NetSaleSvc.Api.CTMS.Models;

namespace NetSaleSvc.Api.Core
{
    public class NetSaleSvcCore
    {
        #region private fileds
        private ICTMSInterface _CTMSInterface;
        private UserInfoService _userInfoService;
        private UserCinemaService _userCinemaService;
        private CinemaService _cinemaService;
        private ScreenInfoService _screenInfoService;
        private SeatInfoService _seatInfoService;
        private SessionInfoService _sessionInfoService;
        private OrderService _orderService;
        #endregion

        #region static fileds
        /// <summary>
        ///     lockHelper
        /// </summary>
        private static readonly object LockHelper = new object();

        /// <summary>
        ///     _instance
        /// </summary>
        private static volatile NetSaleSvcCore _instance;
        #endregion

        #region Public Properties
        public static NetSaleSvcCore Instance
        {
            get
            {
                if (_instance != null)
                {
                    return _instance;
                }

                lock (LockHelper)
                {
                    if (_instance == null)
                    {
                        _instance = new NetSaleSvcCore();
                    }
                }

                return _instance;
            }
        }
        #endregion

        #region ctor
        public NetSaleSvcCore()
        {
            _userInfoService = new UserInfoService();
            _userCinemaService = new UserCinemaService();
            _cinemaService = new CinemaService();
            _screenInfoService = new ScreenInfoService();
            _seatInfoService = new SeatInfoService();
            _sessionInfoService = new SessionInfoService();
            _orderService = new OrderService();
        }
        #endregion

        #region public methods
        /// <summary>
        /// 查询可访问的影院列表
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public QueryCinemaListReply QueryCinemaList(string Username, string Password)
        {
            QueryCinemaListReply queryCinemaListReply = new QueryCinemaListReply();

            //校验参数
            if (!queryCinemaListReply.RequestInfoGuard(Username, Password))
            {
                return queryCinemaListReply;
            }
            //获取用户信息
            UserInfoEntity UserInfo = _userInfoService.GetUserInfoByUserCredential(Username, Password);
            if (UserInfo == null)
            {
                queryCinemaListReply.SetUserCredentialInvalidReply();
                return queryCinemaListReply;
            }
            return QueryCinemaList(queryCinemaListReply, UserInfo);
        }

        /// <summary>
        /// 查询影院基础信息
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <param name="CinemaCode"></param>
        /// <returns></returns>
        public QueryCinemaReply QueryCinema(string Username, string Password, string CinemaCode)
        {
            QueryCinemaReply queryCinemaReply = new QueryCinemaReply();
            if (!queryCinemaReply.RequestInfoGuard(Username, Password, CinemaCode))
            {
                return queryCinemaReply;
            }

            //获取用户信息
            UserInfoEntity UserInfo = _userInfoService.GetUserInfoByUserCredential(Username, Password);
            if (UserInfo == null)
            {
                queryCinemaReply.SetUserCredentialInvalidReply();
                return queryCinemaReply;
            }
            //验证影院是否存在且可访问
            var userCinema = _userCinemaService.GetUserCinema(UserInfo.Id, CinemaCode);
            if (userCinema == null)
            {
                queryCinemaReply.SetCinemaInvalidReply();
                return queryCinemaReply;
            }

            return QueryCinema(queryCinemaReply, userCinema);
        }

        /// <summary>
        /// 查询影厅座位信息
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <param name="CinemaCode"></param>
        /// <param name="ScreenCode"></param>
        /// <returns></returns>
        public QuerySeatReply QuerySeat(string Username, string Password, string CinemaCode, string ScreenCode)
        {
            QuerySeatReply querySeatReply = new QuerySeatReply();
            if (!querySeatReply.RequestInfoGuard(Username, Password, CinemaCode, ScreenCode))
            {
                return querySeatReply;
            }

            //获取用户信息
            UserInfoEntity UserInfo = _userInfoService.GetUserInfoByUserCredential(Username, Password);
            if (UserInfo == null)
            {
                querySeatReply.SetUserCredentialInvalidReply();
                return querySeatReply;
            }
            //验证影院是否存在且可访问
            var userCinema = _userCinemaService.GetUserCinema(UserInfo.Id, CinemaCode);
            if (userCinema == null)
            {
                querySeatReply.SetCinemaInvalidReply();
                return querySeatReply;
            }
            //验证影厅是否存在
            var screenInfo = _screenInfoService.GetScreenInfo(CinemaCode, ScreenCode);
            if (screenInfo == null)
            {
                querySeatReply.SetScreenInvalidReply();
                return querySeatReply;
            }

            return QuerySeat(querySeatReply, userCinema, screenInfo);
        }

        /// <summary>
        /// 查询影片信息
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <param name="CinemaCode"></param>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public QueryFilmReply QueryFilm(string Username, string Password, string CinemaCode, string StartDate, string EndDate)
        {
            QueryFilmReply queryFilmReply = new QueryFilmReply();
            if (!queryFilmReply.RequestInfoGuard(Username, Password, CinemaCode, StartDate, EndDate))
            {
                return queryFilmReply;
            }

            //获取用户信息
            UserInfoEntity UserInfo = _userInfoService.GetUserInfoByUserCredential(Username, Password);
            if (UserInfo == null)
            {
                queryFilmReply.SetUserCredentialInvalidReply();
                return queryFilmReply;
            }
            //验证影院是否存在且可访问
            var userCinema = _userCinemaService.GetUserCinema(UserInfo.Id, CinemaCode);
            if (userCinema == null)
            {
                queryFilmReply.SetCinemaInvalidReply();
                return queryFilmReply;
            }
            //验证日期是否正确
            DateTime Start, End;
            if (!DateTime.TryParse(StartDate, out Start))
            {
                queryFilmReply.SetStartDateInvalidReply();
                return queryFilmReply;
            }
            if (!DateTime.TryParse(EndDate, out End))
            {
                queryFilmReply.SetEndDateInvalidReply();
                return queryFilmReply;
            }
            if (Start > End)
            {
                queryFilmReply.SetDateInvalidReply();
                return queryFilmReply;
            }

            return QueryFilm(queryFilmReply, userCinema, Start, End);
        }

        /// <summary>
        /// 查询放映计划信息
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <param name="CinemaCode"></param>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public QuerySessionReply QuerySession(string Username, string Password,
            string CinemaCode, string StartDate, string EndDate)
        {
            QuerySessionReply querySessionReply = new QuerySessionReply();

            if (!querySessionReply.RequestInfoGuard(Username, Password, CinemaCode, StartDate, EndDate))
            {
                return querySessionReply;
            }

            //获取用户信息
            UserInfoEntity UserInfo = _userInfoService.GetUserInfoByUserCredential(Username, Password);
            if (UserInfo == null)
            {
                querySessionReply.SetUserCredentialInvalidReply();
                return querySessionReply;
            }
            //验证影院是否存在且可访问
            var userCinema = _userCinemaService.GetUserCinema(UserInfo.Id, CinemaCode);
            if (userCinema == null)
            {
                querySessionReply.SetCinemaInvalidReply();
                return querySessionReply;
            }
            //验证日期是否正确
            DateTime Start, End;
            if (!DateTime.TryParse(StartDate, out Start))
            {
                querySessionReply.SetStartDateInvalidReply();
                return querySessionReply;
            }
            if (!DateTime.TryParse(EndDate, out End))
            {
                querySessionReply.SetEndDateInvalidReply();
                return querySessionReply;
            }
            if (Start > End)
            {
                querySessionReply.SetDateInvalidReply();
                return querySessionReply;
            }

            return QuerySession(querySessionReply, userCinema, Start, End);
        }

        /// <summary>
        /// 查询放映计划座位售出状态
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <param name="CinemaCode"></param>
        /// <param name="SessionCode"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        public QuerySessionSeatReply QuerySessionSeat(string Username, string Password,
            string CinemaCode, string SessionCode, string Status)
        {
            QuerySessionSeatReply querySessionSeatReply = new QuerySessionSeatReply();
            if (!querySessionSeatReply.RequestInfoGuard(Username, Password, CinemaCode, SessionCode, Status))
            {
                return querySessionSeatReply;
            }

            //获取用户信息
            UserInfoEntity UserInfo = _userInfoService.GetUserInfoByUserCredential(Username, Password);
            if (UserInfo == null)
            {
                querySessionSeatReply.SetUserCredentialInvalidReply();
                return querySessionSeatReply;
            }
            //验证影院是否存在且可访问
            var userCinema = _userCinemaService.GetUserCinema(UserInfo.Id, CinemaCode);
            if (userCinema == null)
            {
                querySessionSeatReply.SetCinemaInvalidReply();
                return querySessionSeatReply;
            }
            //验证排期是否存在
            var sessionInfo = _sessionInfoService.GetSessionInfo(CinemaCode, SessionCode, UserInfo.Id);
            if (sessionInfo == null)
            {
                querySessionSeatReply.SetSessionInvalidReply();
                return querySessionSeatReply;
            }
            //验证座位售出状态
            var StatusEnum = Status.CastToEnum<SessionSeatStatusEnum>();
            if (StatusEnum == default(SessionSeatStatusEnum))
            {
                querySessionSeatReply.SetSessionSeatStatusInvalidReply();
                return querySessionSeatReply;
            }

            return QuerySessionSeat(querySessionSeatReply, userCinema, SessionCode, StatusEnum);
        }

        /// <summary>
        /// 锁座
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <param name="CinemaCode"></param>
        /// <param name="QueryXml"></param>
        /// <returns></returns>
        public LockSeatReply LockSeat(string Username, string Password, string QueryXml)
        {
            LockSeatReply lockSeatReply = new LockSeatReply();

            if (!lockSeatReply.RequestInfoGuard(Username, Password, QueryXml))
            {
                return lockSeatReply;
            }
            //获取用户信息
            UserInfoEntity UserInfo = _userInfoService.GetUserInfoByUserCredential(Username, Password);
            if (UserInfo == null)
            {
                lockSeatReply.SetUserCredentialInvalidReply();
                return lockSeatReply;
            }
            //验证锁座参数
            var QueryXmlObj = QueryXml.Deserialize<LockSeatQueryXml>();
            if (QueryXmlObj == default(LockSeatQueryXml) || QueryXmlObj.Order == null || QueryXmlObj.Order.Seat == null)
            {
                lockSeatReply.SetXmlDeserializeFailReply(nameof(QueryXml));
                return lockSeatReply;
            }
            //验证影院是否存在且可访问
            var userCinema = _userCinemaService.GetUserCinema(UserInfo.Id, QueryXmlObj.CinemaCode);
            if (userCinema == null)
            {
                lockSeatReply.SetCinemaInvalidReply();
                return lockSeatReply;
            }
            //验证排期是否存在
            var sessionInfo = _sessionInfoService.GetSessionInfo(QueryXmlObj.CinemaCode, QueryXmlObj.Order.SessionCode, UserInfo.Id);
            if (sessionInfo == null)
            {
                lockSeatReply.SetSessionInvalidReply();
                return lockSeatReply;
            }
            //验证座位数量
            if (QueryXmlObj.Order.Count != QueryXmlObj.Order.Seat.Count)
            {
                lockSeatReply.SetSeatCountInvalidReply();
                return lockSeatReply;
            }

            //将请求参数转为订单
            OrderViewEntity order = new OrderViewEntity();
            order.MapFrom(userCinema, QueryXmlObj, sessionInfo);

            return LockSeat(lockSeatReply, userCinema, order);
        }

        public ReleaseSeatReply ReleaseSeat(string Username, string Password, string QueryXml)
        {
            ReleaseSeatReply releaseSeatReply = new ReleaseSeatReply();

            if (!releaseSeatReply.RequestInfoGuard(Username, Password, QueryXml))
            {
                return releaseSeatReply;
            }

            //获取用户信息
            UserInfoEntity UserInfo = _userInfoService.GetUserInfoByUserCredential(Username, Password);
            if (UserInfo == null)
            {
                releaseSeatReply.SetUserCredentialInvalidReply();
                return releaseSeatReply;
            }
            //验证锁座参数
            var QueryXmlObj = QueryXml.Deserialize<ReleaseSeatQueryXml>();
            if (QueryXmlObj == default(ReleaseSeatQueryXml) || QueryXmlObj.Order == null || QueryXmlObj.Order.Seat == null)
            {
                releaseSeatReply.SetXmlDeserializeFailReply(nameof(QueryXml));
                return releaseSeatReply;
            }
            //验证影院是否存在且可访问
            var userCinema = _userCinemaService.GetUserCinema(UserInfo.Id, QueryXmlObj.CinemaCode);
            if (userCinema == null)
            {
                releaseSeatReply.SetCinemaInvalidReply();
                return releaseSeatReply;
            }
            //验证座位数量
            if (QueryXmlObj.Order.Count != QueryXmlObj.Order.Seat.Count)
            {
                releaseSeatReply.SetSeatCountInvalidReply();
                return releaseSeatReply;
            }
            //验证订单是否存在
            OrderViewEntity order = null;
            if (!string.IsNullOrEmpty(QueryXmlObj.Order.OrderCode))
            {
                order = _orderService.GetOrderWithLockOrderCode(QueryXmlObj.CinemaCode
                    , QueryXmlObj.Order.OrderCode);
            }
            if (order == null
                || (order.orderBaseInfo.OrderStatus != OrderStatusEnum.Locked 
                && order.orderBaseInfo.OrderStatus != OrderStatusEnum.SubmitFail
                && order.orderBaseInfo.OrderStatus != OrderStatusEnum.ReleaseFail))
            {
                releaseSeatReply.SetOrderNotExistReply();
                return releaseSeatReply;
            }

            return ReleaseSeat(releaseSeatReply, userCinema, order);
        }
        #endregion

        #region private methods
        /// <summary>
        /// 根据用户查询影院
        /// </summary>
        /// <param name="reply"></param>
        /// <param name="UserInfo"></param>
        /// <returns></returns>
        [CheckForNullArgumentsAspect]
        private QueryCinemaListReply QueryCinemaList(QueryCinemaListReply reply, UserInfoEntity UserInfo)
        {
            var cinemaList = _userCinemaService.GetUserCinemasByUserId(UserInfo.Id);

            reply.Cinemas = new QueryCinemaListReplyCinemas();
            if (cinemaList == null || cinemaList.Count == 0)
            {
                reply.Cinemas.CinemaCount = "0";
            }
            else
            {
                reply.Cinemas.CinemaCount = cinemaList.Count.ToString();
                reply.Cinemas.Cinema = cinemaList.Select(x => new QueryCinemaListReplyCinema().MapFrom(x)).ToList();
            }

            reply.SetSuccessReply();
            return reply;
        }

        /// <summary>
        /// 查询影院基本信息
        /// </summary>
        /// <param name="reply"></param>
        /// <param name="UserInfo"></param>
        /// <param name="CinemaCode"></param>
        /// <returns></returns>
        [CheckForNullArgumentsAspect]
        private QueryCinemaReply QueryCinema(QueryCinemaReply reply, UserCinemaViewEntity userCinema)
        {
            _CTMSInterface = CTMSInterfaceFactory.Create(userCinema);

            //从影院票务管理系统更新影院基本信息
            var CTMSReply = _CTMSInterface.QueryCinema(userCinema);

            if (CTMSReply.Status == StatusEnum.Success)
            {
                //获取影院影厅列表
                reply.Cinema = new QueryCinemaReplyCinema();
                reply.Cinema.Code = userCinema.CinemaCode;
                reply.Cinema.Name = userCinema.CinemaName;
                reply.Cinema.Address = userCinema.CinemaAddress;

                var ScreenList = _screenInfoService.GetScreenListByCinemaCode(userCinema.CinemaCode);
                if (ScreenList == null || ScreenList.Count == 0)
                {
                    reply.Cinema.ScreenCount = "0";
                }
                else
                {
                    reply.Cinema.ScreenCount = ScreenList.Count.ToString();
                    reply.Cinema.Screen = ScreenList.Select(x => new QueryCinemaReplyScreen().MapFrom(x)).ToList();
                }

                reply.SetSuccessReply();
            }
            else
            {
                reply.GetErrorFromCTMSReply(CTMSReply);
            }
            return reply;
        }

        /// <summary>
        /// 查询影厅座位信息
        /// </summary>
        /// <param name="reply"></param>
        /// <param name="userCinema"></param>
        /// <param name="screen"></param>
        /// <returns></returns>
        [CheckForNullArgumentsAspect]
        private QuerySeatReply QuerySeat(QuerySeatReply reply, UserCinemaViewEntity userCinema, ScreenInfoEntity screen)
        {
            _CTMSInterface = CTMSInterfaceFactory.Create(userCinema);
            //从影院票务管理系统更新影厅座位信息
            var CTMSReply = _CTMSInterface.QuerySeat(userCinema, screen);

            if (CTMSReply.Status == StatusEnum.Success)
            {
                //获取影厅座位列表
                reply.Cinema = new QuerySeatReplyCinema();
                reply.Cinema.Code = userCinema.CinemaCode;
                reply.Cinema.Screen = new QuerySeatReplyScreen();
                reply.Cinema.Screen.Code = screen.SCode;

                var seatList = _seatInfoService.GetScreenSeats(userCinema.CinemaCode, screen.SCode);

                if (seatList != null && seatList.Count > 0)
                {
                    reply.Cinema.Screen.Seat = seatList.Select(x => new QuerySeatReplySeat().MapFrom(x)).ToList();
                }

                reply.SetSuccessReply();
            }
            else
            {
                reply.GetErrorFromCTMSReply(CTMSReply);
            }
            return reply;
        }

        /// <summary>
        /// 查询影片信息
        /// </summary>
        /// <param name="reply"></param>
        /// <param name="userCinema"></param>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        [CheckForNullArgumentsAspect]
        private QueryFilmReply QueryFilm(QueryFilmReply reply, UserCinemaViewEntity userCinema,
            DateTime StartDate, DateTime EndDate)
        {
            _CTMSInterface = CTMSInterfaceFactory.Create(userCinema);
            //从影院票务管理系统更新影厅座位信息
            var CTMSReply = _CTMSInterface.QueryFilm(userCinema, StartDate, EndDate);

            if (CTMSReply.Status == StatusEnum.Success)
            {
                var FilmEntities = CTMSReply.films.ToList();
                reply.Films = new QueryFilmReplyFilms();
                reply.Films.Count = FilmEntities.Count;
                reply.Films.Film = FilmEntities.Select(x => new QueryFilmReplyFilm().MapFrom(x)).ToList();

                reply.SetSuccessReply();
            }
            else
            {
                reply.GetErrorFromCTMSReply(CTMSReply);
            }

            return reply;
        }

        /// <summary>
        /// 查询放映计划信息
        /// </summary>
        /// <param name="reply"></param>
        /// <param name="userCinema"></param>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        [CheckForNullArgumentsAspect]
        private QuerySessionReply QuerySession(QuerySessionReply reply, UserCinemaViewEntity userCinema,
            DateTime StartDate, DateTime EndDate)
        {
            _CTMSInterface = CTMSInterfaceFactory.Create(userCinema);
            var CTMSReply = _CTMSInterface.QuerySession(userCinema, StartDate, EndDate);

            if (CTMSReply.Status == StatusEnum.Success)
            {
                var sessionList = _sessionInfoService.GetSessionWithUserPrice(userCinema.CinemaCode, userCinema.UserId, StartDate, EndDate);

                reply.Sessions = new QuerySessionReplySessions();
                reply.Sessions.CinemaCode = userCinema.CinemaCode;
                if (sessionList != null && sessionList.Count > 0)
                {
                    reply.Sessions.Session = sessionList.Select(x => new QuerySessionReplySession().MapFrom(x)).ToList();
                }

                reply.SetSuccessReply();
            }
            else
            {
                reply.GetErrorFromCTMSReply(CTMSReply);
            }
            return reply;
        }

        /// <summary>
        /// 查询放映计划座位状态
        /// </summary>
        /// <param name="reply"></param>
        /// <param name="userCinema"></param>
        /// <param name="SessionCode"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        [CheckForNullArgumentsAspect]
        private QuerySessionSeatReply QuerySessionSeat(QuerySessionSeatReply reply, UserCinemaViewEntity userCinema,
            string SessionCode, SessionSeatStatusEnum Status)
        {
            _CTMSInterface = CTMSInterfaceFactory.Create(userCinema);
            var CTMSReply = _CTMSInterface.QuerySessionSeat(userCinema, SessionCode, Status);

            if (CTMSReply.Status == StatusEnum.Success)
            {
                reply.SessionSeat = new QuerySessionSeatReplySessionSeat();
                reply.SessionSeat.CinemaCode = userCinema.CinemaCode;
                reply.SessionSeat.SessionCode = SessionCode;
                reply.SessionSeat.Seat = CTMSReply.SessionSeats.Select(x =>
                    new QuerySessionSeatReplySeat
                    {
                        Code = x.SeatCode,
                        RowNum = x.RowNum,
                        ColumnNum = x.ColumnNum,
                        Status = x.Status.GetDescription()
                    }).ToList();

                reply.SetSuccessReply();
            }
            else
            {
                reply.GetErrorFromCTMSReply(CTMSReply);
            }
            return reply;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userCinema"></param>
        /// <param name="QueryXmlObj"></param>
        /// <returns></returns>
        [CheckForNullArgumentsAspect]
        private LockSeatReply LockSeat(LockSeatReply reply, UserCinemaViewEntity userCinema, OrderViewEntity order)
        {

            _CTMSInterface = CTMSInterfaceFactory.Create(userCinema);
            var CTMSReply = _CTMSInterface.LockSeat(userCinema, order);

            if (CTMSReply.Status == StatusEnum.Success)
            {
                reply.Order = new LockSeatReplyOrder();
                reply.Order.OrderCode = order.orderBaseInfo.LockOrderCode;
                reply.Order.AutoUnlockDatetime = order.orderBaseInfo.AutoUnlockDatetime
                    .GetValueOrDefault(DateTime.Now.AddMinutes(10)).ToFormatStringWithT();
                reply.Order.SessionCode = order.orderBaseInfo.SessionCode;
                reply.Order.Count = order.orderBaseInfo.TicketCount;
                reply.Order.Seat = order.orderSeatDetails.Select(x => new LockSeatReplySeat { SeatCode = x.SeatCode }).ToList();

                reply.SetSuccessReply();
            }
            else
            {
                reply.GetErrorFromCTMSReply(CTMSReply);
            }

            //将订单保存到数据库
            _orderService.Insert(order);

            return reply;
        }

        private ReleaseSeatReply ReleaseSeat(ReleaseSeatReply reply, UserCinemaViewEntity userCinema, OrderViewEntity order)
        {
            _CTMSInterface = CTMSInterfaceFactory.Create(userCinema);
            var CTMSReply = _CTMSInterface.ReleaseSeat(userCinema, order);

            if (CTMSReply.Status == StatusEnum.Success)
            {
                reply.Order = new ReleaseSeatReplyOrder();
                reply.Order.OrderCode = order.orderBaseInfo.LockOrderCode;
                reply.Order.SessionCode = order.orderBaseInfo.SessionCode;
                reply.Order.Count = order.orderBaseInfo.TicketCount;
                reply.Order.Seat = order.orderSeatDetails.Select(x => new ReleaseSeatReplySeat { SeatCode = x.SeatCode }).ToList();

                reply.SetSuccessReply();
            }
            else
            {
                reply.GetErrorFromCTMSReply(CTMSReply);
            }

            //只更新订单信息，不更新订单座位信息
            _orderService.UpdateOrderBaseInfo(order.orderBaseInfo);

            return reply;
        }
        #endregion
    }
}