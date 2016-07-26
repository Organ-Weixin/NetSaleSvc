﻿using NetSaleSvc.Entity.Models;
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
        public bool QueryCinema(UserCinemaViewEntity userCinema)
        {
            string queryCinemaResult = nsService.QueryCinema(userCinema.RealUserName, userCinema.RealPassword,
                userCinema.Url, string.Empty, userCinema.CinemaCode);
            nsOnlineTicketingServiceReply reply = queryCinemaResult.Deserialize<nsOnlineTicketingServiceReply>();

            if (reply.QueryCinemaReply.Status == StatusEnum.Success.GetDescription())
            {
                SaveScreenInfos(userCinema.CinemaCode, reply);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 获取影院基础信息
        /// </summary>
        /// <param name="userCinema"></param>
        /// <param name="screen"></param>
        /// <returns></returns>
        [CheckForNullArgumentsAspect]
        public bool QuerySeat(UserCinemaViewEntity userCinema, ScreenInfoEntity screen)
        {
            string querySeatResult = nsService.QuerySeat(userCinema.RealUserName, userCinema.RealPassword,
                userCinema.Url, string.Empty, userCinema.CinemaCode, screen.SCode);

            nsOnlineTicketingServiceReply reply = querySeatResult.Deserialize<nsOnlineTicketingServiceReply>();

            if (reply.QuerySeatReply.Status == StatusEnum.Success.GetDescription())
            {
                SaveSeatInfos(userCinema.CinemaCode, screen.SCode, reply);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 查询影片信息
        /// </summary>
        /// <param name="userCinema"></param>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        [CheckForNullArgumentsAspect]
        public IEnumerable<FilmInfoEntity> QueryFilm(UserCinemaViewEntity userCinema, DateTime StartDate, DateTime EndDate)
        {
            string queryFilmResult = nsService.QueryFilm(userCinema.RealUserName, userCinema.RealPassword,
                userCinema.Url, string.Empty, StartDate, EndDate);

            nsOnlineTicketingServiceReply reply = queryFilmResult.Deserialize<nsOnlineTicketingServiceReply>();

            var FilmCodes = reply.QueryFilmReply.Films.Film.Select(x => x.Code);
            var ExitedFilms = _filmInfoService.GetFilmInfosByCodes(FilmCodes);

            var entities = reply.QueryFilmReply.Films.Film.Select(x => x.MapToEntity(
                ExitedFilms.Where(y => y.FilmCode == x.Code).SingleOrDefault() ?? new FilmInfoEntity()));

            _filmInfoService.BulkMerge(entities);

            return entities;
        }

        /// <summary>
        /// 查询放映计划
        /// </summary>
        /// <param name="userCinema"></param>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        [CheckForNullArgumentsAspect]
        public bool QuerySession(UserCinemaViewEntity userCinema, DateTime StartDate, DateTime EndDate)
        {
            string querySessionResult = nsService.QuerySession(userCinema.RealUserName, userCinema.RealPassword,
                userCinema.Url, string.Empty, userCinema.CinemaCode, StartDate, EndDate);

            nsOnlineTicketingServiceReply reply = querySessionResult.Deserialize<nsOnlineTicketingServiceReply>();

            if (reply.QuerySessionReply.Status == StatusEnum.Success.GetDescription())
            {
                SaveSessions(userCinema, StartDate, EndDate, reply);
                return true;
            }
            else
            {
                return false;
            }
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

            CTMSQuerySessionSeatReply _CTMSQuerySessionSeatReply = new CTMSQuerySessionSeatReply();
            if (reply.QuerySessionSeatReply.Status == StatusEnum.Success.GetDescription())
            {
                _CTMSQuerySessionSeatReply.Status = StatusEnum.Success;
                _CTMSQuerySessionSeatReply.ErrorCode = reply.QuerySessionSeatReply.ErrorCode;
                _CTMSQuerySessionSeatReply.ErrorMessage = reply.QuerySessionSeatReply.ErrorMessage;
                _CTMSQuerySessionSeatReply.SessionSeats = reply.QuerySessionSeatReply.SessionSeat.Seat.Select(x =>
                    new SessionSeatEntity
                    {
                        SeatCode = x.Code,
                        RowNum = x.RowNum,
                        ColumnNum = x.ColumnNum,
                        Status = x.Status.CastToEnum<SessionSeatStatusEnum>()
                    });
            }
            else
            {
                _CTMSQuerySessionSeatReply.Status = StatusEnum.Failure;
                _CTMSQuerySessionSeatReply.ErrorCode = reply.QuerySessionSeatReply.ErrorCode;
                _CTMSQuerySessionSeatReply.ErrorMessage = reply.QuerySessionSeatReply.ErrorMessage;
            }

            return _CTMSQuerySessionSeatReply;
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

            var deleteList = oldScreens.Where(x => newScreens.Where(y => y.Id == x.Id).SingleOrDefault() == null).ToList();

            //插入或更新最新座位
            _screenInfoService.BulkMerge(newScreens);
            //删除数据库中过期座位
            if (deleteList.NotNull().Count > 0)
            {
                _screenInfoService.BulkDelete(deleteList);
            }
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

            var deleteList = oldSeats.Where(x => newSeats.Where(y => y.Id == x.Id).SingleOrDefault() == null).ToList();

            //插入或更新最新座位
            _seatInfoService.BulkMerge(newSeats);
            //删除数据库中过期座位
            if (deleteList.NotNull().Count > 0)
            {
                _seatInfoService.BulkDelete(deleteList);
            }
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

            var deleteList = oldSessions.Where(x => newSessions.Where(y => y.Id == x.Id).SingleOrDefault() == null).ToList();

            //插入或更新最新放映计划
            _sessionInfoService.BulkMerge(newSessions);
            //删除数据库中过期放映计划
            if (deleteList.NotNull().Count > 0)
            {
                _sessionInfoService.BulkDelete(deleteList);
            }
        }
        #endregion
    }
}
