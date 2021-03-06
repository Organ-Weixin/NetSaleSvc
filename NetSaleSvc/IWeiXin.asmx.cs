﻿using NetSaleSvc.Api.Core;
using NetSaleSvc.Api.Models;
using NetSaleSvc.Log;
using NetSaleSvc.Util;
using System;
using System.Web.Services;

namespace NetSaleSvc
{
    /// <summary>
    /// 普照电商云平台
    /// </summary>
    [WebService(Namespace = "http://weixin.com/iweixin/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class IWeiXin : WebService
    {
        /// <summary>
        /// 查询可访问的影院列表
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        [WebMethod]
        public string QueryCinemaList(string Username, string Password)
        {
            OnlineTicketingServiceReply onlineTicketingServiceReply = new OnlineTicketingServiceReply();
            try
            {
                onlineTicketingServiceReply.QueryCinemaListReply = NetSaleSvcCore.Instance.QueryCinemaList(Username, Password);
            }
            catch (Exception ex)
            {
                onlineTicketingServiceReply.QueryCinemaListReply = new QueryCinemaListReply();
                LogHelper.LogException(ex);
            }

            return onlineTicketingServiceReply.Serialize();
        }

        /// <summary>
        /// 查询影院基础信息
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <param name="CinemaCode"></param>
        /// <returns></returns>
        [WebMethod]
        public string QueryCinema(string Username, string Password, string CinemaCode)
        {
            OnlineTicketingServiceReply onlineTicketingServiceReply = new OnlineTicketingServiceReply();
            try
            {
                onlineTicketingServiceReply.QueryCinemaReply = NetSaleSvcCore.Instance.QueryCinema(Username, Password, CinemaCode);
            }
            catch (Exception ex)
            {
                onlineTicketingServiceReply.QueryCinemaReply = new QueryCinemaReply();
                LogHelper.LogException(ex);
            }

            return onlineTicketingServiceReply.Serialize();
        }

        /// <summary>
        /// 查询影厅座位信息
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <param name="CinemaCode"></param>
        /// <param name="ScreenCode"></param>
        /// <returns></returns>
        [WebMethod]
        public string QuerySeat(string Username, string Password, string CinemaCode, string ScreenCode)
        {
            OnlineTicketingServiceReply onlineTicketingServiceReply = new OnlineTicketingServiceReply();
            try
            {
                onlineTicketingServiceReply.QuerySeatReply = NetSaleSvcCore.Instance.QuerySeat(Username,
                    Password, CinemaCode, ScreenCode);
            }
            catch (Exception ex)
            {
                onlineTicketingServiceReply.QuerySeatReply = new QuerySeatReply();
                LogHelper.LogException(ex);
            }

            return onlineTicketingServiceReply.Serialize();
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
        [WebMethod]
        public string QueryFilm(string Username, string Password, string CinemaCode, string StartDate, string EndDate)
        {
            OnlineTicketingServiceReply onlineTicketingServiceReply = new OnlineTicketingServiceReply();
            try
            {
                onlineTicketingServiceReply.QueryFilmReply = NetSaleSvcCore.Instance.QueryFilm(Username,
                    Password, CinemaCode, StartDate, EndDate);
            }
            catch (Exception ex)
            {
                onlineTicketingServiceReply.QueryFilmReply = new QueryFilmReply();
                LogHelper.LogException(ex);
            }

            return onlineTicketingServiceReply.Serialize();
        }

        /// <summary>
        /// 查询影院放映计划信息
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <param name="CinemaCode"></param>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        [WebMethod]
        public string QuerySession(string Username, string Password, string CinemaCode, string StartDate, string EndDate)
        {
            OnlineTicketingServiceReply onlineTicketingServiceReply = new OnlineTicketingServiceReply();
            try
            {
                onlineTicketingServiceReply.QuerySessionReply = NetSaleSvcCore.Instance.QuerySession(Username,
                    Password, CinemaCode, StartDate, EndDate);
            }
            catch (Exception ex)
            {
                onlineTicketingServiceReply.QuerySessionReply = new QuerySessionReply();
                LogHelper.LogException(ex, $"QuerySession异常：Username:{Username},Password:{Password},CinemaCode:{CinemaCode},StartDate:{StartDate},EndDate:{EndDate}");
            }

            return onlineTicketingServiceReply.Serialize();
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
        [WebMethod]
        public string QuerySessionSeat(string Username, string Password, string CinemaCode, string SessionCode, string Status)
        {
            OnlineTicketingServiceReply onlineTicketingServiceReply = new OnlineTicketingServiceReply();
            try
            {
                onlineTicketingServiceReply.QuerySessionSeatReply = NetSaleSvcCore.Instance.QuerySessionSeat(Username,
                    Password, CinemaCode, SessionCode, Status);
            }
            catch (Exception ex)
            {
                onlineTicketingServiceReply.QuerySessionSeatReply = new QuerySessionSeatReply();
                LogHelper.LogException(ex);
            }

            return onlineTicketingServiceReply.Serialize();
        }

        /// <summary>
        /// 锁定座位
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <param name="CinemaCode"></param>
        /// <param name="QueryXml"></param>
        /// <returns></returns>
        [WebMethod]
        public string LockSeat(string Username, string Password, string QueryXml)
        {
            OnlineTicketingServiceReply onlineTicketingServiceReply = new OnlineTicketingServiceReply();
            try
            {
                onlineTicketingServiceReply.LockSeatReply = NetSaleSvcCore.Instance.LockSeat(Username,
                    Password, QueryXml);
            }
            catch (Exception ex)
            {
                onlineTicketingServiceReply.LockSeatReply = new LockSeatReply();
                LogHelper.LogException(ex);
            }

            return onlineTicketingServiceReply.Serialize();
        }

        /// <summary>
        /// 解锁座位
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <param name="QueryXml"></param>
        /// <returns></returns>
        [WebMethod]
        public string ReleaseSeat(string Username, string Password, string QueryXml)
        {
            OnlineTicketingServiceReply onlineTicketingServiceReply = new OnlineTicketingServiceReply();
            try
            {
                onlineTicketingServiceReply.ReleaseSeatReply = NetSaleSvcCore.Instance.ReleaseSeat(Username,
                    Password, QueryXml);
            }
            catch (Exception ex)
            {
                onlineTicketingServiceReply.ReleaseSeatReply = new ReleaseSeatReply();
                LogHelper.LogException(ex);
            }

            return onlineTicketingServiceReply.Serialize();
        }

        /// <summary>
        /// 确认订单
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <param name="QueryXml"></param>
        /// <returns></returns>
        [WebMethod]
        public string SubmitOrder(string Username, string Password, string QueryXml)
        {
            OnlineTicketingServiceReply onlineTicketingServiceReply = new OnlineTicketingServiceReply();
            try
            {
                onlineTicketingServiceReply.SubmitOrderReply = NetSaleSvcCore.Instance.SubmitOrder(Username,
                    Password, QueryXml);
            }
            catch (Exception ex)
            {
                onlineTicketingServiceReply.SubmitOrderReply = new SubmitOrderReply();
                LogHelper.LogException(ex);
            }

            return onlineTicketingServiceReply.Serialize();
        }

        /// <summary>
        /// 查询出票状态
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <param name="CinemaCode"></param>
        /// <param name="PrintNo"></param>
        /// <param name="VerifyCode"></param>
        /// <returns></returns>
        [WebMethod]
        public string QueryPrint(string Username, string Password, string CinemaCode, 
            string PrintNo, string VerifyCode)
        {
            OnlineTicketingServiceReply onlineTicketingServiceReply = new OnlineTicketingServiceReply();
            try
            {
                onlineTicketingServiceReply.QueryPrintReply = NetSaleSvcCore.Instance.QueryPrint(Username,
                    Password, CinemaCode, PrintNo, VerifyCode);
            }
            catch (Exception ex)
            {
                onlineTicketingServiceReply.QueryPrintReply = new QueryPrintReply();
                LogHelper.LogException(ex);
            }

            return onlineTicketingServiceReply.Serialize();
        }

        /// <summary>
        /// 退票
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <param name="CinemaCode"></param>
        /// <param name="PrintNo"></param>
        /// <param name="VerifyCode"></param>
        /// <returns></returns>
        [WebMethod]
        public string RefundTicket(string Username, string Password, string CinemaCode,
            string PrintNo, string VerifyCode)
        {
            OnlineTicketingServiceReply onlineTicketingServiceReply = new OnlineTicketingServiceReply();
            try
            {
                onlineTicketingServiceReply.RefundTicketReply = NetSaleSvcCore.Instance.RefundTicket(Username,
                    Password, CinemaCode, PrintNo, VerifyCode);
            }
            catch (Exception ex)
            {
                onlineTicketingServiceReply.RefundTicketReply = new RefundTicketReply();
                LogHelper.LogException(ex);
            }

            return onlineTicketingServiceReply.Serialize();
        }

        /// <summary>
        /// 查询订单信息
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <param name="CinemaCode"></param>
        /// <param name="OrderCode"></param>
        /// <returns></returns>
        [WebMethod]
        public string QueryOrder(string Username, string Password, string CinemaCode,
            string OrderCode)
        {
            OnlineTicketingServiceReply onlineTicketingServiceReply = new OnlineTicketingServiceReply();
            try
            {
                onlineTicketingServiceReply.QueryOrderReply = NetSaleSvcCore.Instance.QueryOrder(Username,
                    Password, CinemaCode, OrderCode);
            }
            catch (Exception ex)
            {
                onlineTicketingServiceReply.QueryOrderReply = new QueryOrderReply();
                LogHelper.LogException(ex);
            }

            return onlineTicketingServiceReply.Serialize();
        }

        #region 取票接口
        /// <summary>
        /// 查询影票信息
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <param name="CinemaCode"></param>
        /// <param name="PrintNo"></param>
        /// <param name="VerifyCode"></param>
        /// <returns></returns>
        [WebMethod]
        public string QueryTicket(string Username, string Password, string CinemaCode,
            string PrintNo, string VerifyCode)
        {
            OnlineTicketingServiceReply onlineTicketingServiceReply = new OnlineTicketingServiceReply();
            try
            {
                onlineTicketingServiceReply.QueryTicketReply = NetSaleSvcCore.Instance.QueryTicket(Username,
                    Password, CinemaCode, PrintNo, VerifyCode);
            }
            catch (Exception ex)
            {
                onlineTicketingServiceReply.QueryTicketReply = new QueryTicketReply();
                LogHelper.LogException(ex);
            }

            return onlineTicketingServiceReply.Serialize();
        }

        /// <summary>
        /// 确认出票
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <param name="CinemaCode"></param>
        /// <param name="PrintNo"></param>
        /// <param name="VerifyCode"></param>
        /// <returns></returns>
        [WebMethod]
        public string FetchTicket(string Username, string Password, string CinemaCode,
            string PrintNo, string VerifyCode)
        {
            OnlineTicketingServiceReply onlineTicketingServiceReply = new OnlineTicketingServiceReply();
            try
            {
                onlineTicketingServiceReply.FetchTicketReply = NetSaleSvcCore.Instance.FetchTicket(Username,
                    Password, CinemaCode, PrintNo, VerifyCode);
            }
            catch (Exception ex)
            {
                onlineTicketingServiceReply.FetchTicketReply = new FetchTicketReply();
                LogHelper.LogException(ex);
            }

            return onlineTicketingServiceReply.Serialize();
        }
        #endregion
    }
}
