using NetSaleSvc.Api.CTMS.Models;
using NetSaleSvc.Entity.Enum;
using NetSaleSvc.Entity.Models;
using NetSaleSvc.Util;
using System;
using System.Collections.Generic;

namespace NetSaleSvc.Api.CTMS
{
    public class DefaultCTMSInterface : ICTMSInterface
    {
        private static string CinemaInterfaceMiss { get; } = "影院接口获取失败!";

        /// <summary>
        /// 查询影院基本信息
        /// </summary>
        /// <param name="cinema"></param>
        /// <returns></returns>
        [CheckForNullArgumentsAspect]
        public bool QueryCinema(UserCinemaViewEntity userCinema)
        {
            throw new Exception(CinemaInterfaceMiss);
        }

        /// <summary>
        /// 查询影厅座位信息
        /// </summary>
        /// <param name="userCinema"></param>
        /// <param name="screen"></param>
        /// <returns></returns>
        [CheckForNullArgumentsAspect]
        public bool QuerySeat(UserCinemaViewEntity userCinema, ScreenInfoEntity screen)
        {
            throw new Exception(CinemaInterfaceMiss);
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
            throw new Exception(CinemaInterfaceMiss);
        }

        /// <summary>
        /// 查询放映计划信息
        /// </summary>
        /// <param name="userCinema"></param>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        [CheckForNullArgumentsAspect]
        public bool QuerySession(UserCinemaViewEntity userCinema, DateTime StartDate, DateTime EndDate)
        {
            throw new Exception(CinemaInterfaceMiss);
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
            throw new Exception(CinemaInterfaceMiss);
        }
    }
}
