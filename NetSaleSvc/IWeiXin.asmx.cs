using NetSaleSvc.Api.Core;
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
                LogHelper.LogException(ex);
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
    }
}
