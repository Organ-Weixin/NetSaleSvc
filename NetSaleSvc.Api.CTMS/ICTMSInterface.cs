﻿using NetSaleSvc.Api.CTMS.Models;
using NetSaleSvc.Entity.Enum;
using NetSaleSvc.Entity.Models;
using System;
using System.Collections.Generic;

namespace NetSaleSvc.Api.CTMS
{
    public interface ICTMSInterface
    {
        /// <summary>
        /// 查询影院基本信息
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        CTMSQueryCinemaReply QueryCinema(UserCinemaViewEntity userCinema);

        /// <summary>
        /// 查询影厅座位信息
        /// </summary>
        /// <param name="userCinema"></param>
        /// <param name="screen"></param>
        /// <returns></returns>
        CTMSQuerySeatReply QuerySeat(UserCinemaViewEntity userCinema, ScreenInfoEntity screen);

        /// <summary>
        /// 查询影片信息
        /// </summary>
        /// <param name="userCinema"></param>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        CTMSQueryFilmReply QueryFilm(UserCinemaViewEntity userCinema, DateTime StartDate, DateTime EndDate);

        /// <summary>
        /// 查询放映计划信息
        /// </summary>
        /// <param name="userCinema"></param>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        CTMSQuerySessionReply QuerySession(UserCinemaViewEntity userCinema, DateTime StartDate, DateTime EndDate);

        /// <summary>
        /// 查询放映计划座位状态
        /// </summary>
        /// <param name="userCinema"></param>
        /// <param name="SessionCode"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        CTMSQuerySessionSeatReply QuerySessionSeat(UserCinemaViewEntity userCinema,
            string SessionCode, SessionSeatStatusEnum Status);

        /// <summary>
        /// 锁定座位
        /// </summary>
        /// <param name="userCinema"></param>
        /// <param name="QueryXml"></param>
        /// <returns></returns>
        CTMSLockSeatReply LockSeat(UserCinemaViewEntity userCinema, OrderViewEntity order);

        /// <summary>
        /// 解锁座位
        /// </summary>
        /// <param name="userCinema"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        CTMSReleaseSeatReply ReleaseSeat(UserCinemaViewEntity userCinema, OrderViewEntity order);

        /// <summary>
        /// 提交订单
        /// </summary>
        /// <param name="userCinema"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        CTMSSubmitOrderReply SubmitOrder(UserCinemaViewEntity userCinema, OrderViewEntity order);

        /// <summary>
        /// 查询出票状态
        /// </summary>
        /// <param name="userCinema"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        CTMSQueryPrintReply QueryPrint(UserCinemaViewEntity userCinema, OrderViewEntity order);

        /// <summary>
        /// 退票
        /// </summary>
        /// <param name="userCinema"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        CTMSRefundTicketReply RefundTicket(UserCinemaViewEntity userCinema, OrderViewEntity order);

        /// <summary>
        /// 查询订单信息
        /// </summary>
        /// <param name="userCinema"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        CTMSQueryOrderReply QueryOrder(UserCinemaViewEntity userCinema, OrderViewEntity order);

        /// <summary>
        /// 查询影票信息
        /// </summary>
        /// <param name="userCinema"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        CTMSQueryTicketReply QueryTicket(UserCinemaViewEntity userCinema, OrderViewEntity order);

        /// <summary>
        /// 确认出票
        /// </summary>
        /// <param name="userCinema"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        CTMSFetchTicketReply FetchTicket(UserCinemaViewEntity userCinema, OrderViewEntity order);
    }
}
