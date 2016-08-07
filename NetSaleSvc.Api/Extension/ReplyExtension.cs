using NetSaleSvc.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetSaleSvc.Api.Extension
{
    public static class ReplyExtension
    {
        /// <summary>
        /// 检查传入参数
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public static bool RequestInfoGuard(this QueryCinemaListReply reply, string Username, string Password)
        {
            if (string.IsNullOrEmpty(Username))
            {
                reply.SetNecessaryParamMissReply(nameof(Username));
                return false;
            }
            if (string.IsNullOrEmpty(Password))
            {
                reply.SetNecessaryParamMissReply(nameof(Password));
                return false;
            }

            return true;
        }

        /// <summary>
        /// 检查传入参数
        /// </summary>
        /// <param name="reply"></param>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <param name="CinemaCode"></param>
        /// <returns></returns>
        public static bool RequestInfoGuard(this QueryCinemaReply reply, string Username, string Password, string CinemaCode)
        {
            if (string.IsNullOrEmpty(Username))
            {
                reply.SetNecessaryParamMissReply(nameof(Username));
                return false;
            }
            if (string.IsNullOrEmpty(Password))
            {
                reply.SetNecessaryParamMissReply(nameof(Password));
                return false;
            }
            if (string.IsNullOrEmpty(CinemaCode))
            {
                reply.SetNecessaryParamMissReply(nameof(CinemaCode));
                return false;
            }

            return true;
        }

        /// <summary>
        /// 检查传入参数
        /// </summary>
        /// <param name="reply"></param>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <param name="CinemaCode"></param>
        /// <param name="ScreenCode"></param>
        /// <returns></returns>
        public static bool RequestInfoGuard(this QuerySeatReply reply, string Username, 
            string Password, string CinemaCode, string ScreenCode)
        {
            if (string.IsNullOrEmpty(Username))
            {
                reply.SetNecessaryParamMissReply(nameof(Username));
                return false;
            }
            if (string.IsNullOrEmpty(Password))
            {
                reply.SetNecessaryParamMissReply(nameof(Password));
                return false;
            }
            if (string.IsNullOrEmpty(CinemaCode))
            {
                reply.SetNecessaryParamMissReply(nameof(CinemaCode));
                return false;
            }
            if (string.IsNullOrEmpty(ScreenCode))
            {
                reply.SetNecessaryParamMissReply(nameof(ScreenCode));
                return false;
            }

            return true;
        }

        /// <summary>
        /// 检查传入参数
        /// </summary>
        /// <param name="reply"></param>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <param name="CinemaCode"></param>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public static bool RequestInfoGuard(this QueryFilmReply reply, string Username, string Password,
            string CinemaCode, string StartDate, string EndDate)
        {
            if (string.IsNullOrEmpty(Username))
            {
                reply.SetNecessaryParamMissReply(nameof(Username));
                return false;
            }
            if (string.IsNullOrEmpty(Password))
            {
                reply.SetNecessaryParamMissReply(nameof(Password));
                return false;
            }
            if (string.IsNullOrEmpty(CinemaCode))
            {
                reply.SetNecessaryParamMissReply(nameof(CinemaCode));
                return false;
            }
            if (string.IsNullOrEmpty(StartDate))
            {
                reply.SetNecessaryParamMissReply(nameof(StartDate));
                return false;
            }
            if (string.IsNullOrEmpty(EndDate))
            {
                reply.SetNecessaryParamMissReply(nameof(EndDate));
                return false;
            }

            return true;
        }

        /// <summary>
        /// 检查传入参数
        /// </summary>
        /// <param name="reply"></param>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <param name="CinemaCode"></param>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public static bool RequestInfoGuard(this QuerySessionReply reply, string Username, string Password,
            string CinemaCode, string StartDate, string EndDate)
        {
            if (string.IsNullOrEmpty(Username))
            {
                reply.SetNecessaryParamMissReply(nameof(Username));
                return false;
            }
            if (string.IsNullOrEmpty(Password))
            {
                reply.SetNecessaryParamMissReply(nameof(Password));
                return false;
            }
            if (string.IsNullOrEmpty(CinemaCode))
            {
                reply.SetNecessaryParamMissReply(nameof(CinemaCode));
                return false;
            }
            if (string.IsNullOrEmpty(StartDate))
            {
                reply.SetNecessaryParamMissReply(nameof(StartDate));
                return false;
            }
            if (string.IsNullOrEmpty(EndDate))
            {
                reply.SetNecessaryParamMissReply(nameof(EndDate));
                return false;
            }

            return true;
        }

        /// <summary>
        /// 检查传入参数
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <param name="CinemaCode"></param>
        /// <param name="SessionCode"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        public static bool RequestInfoGuard(this QuerySessionSeatReply reply, string Username, string Password,
            string CinemaCode, string SessionCode, string Status)
        {
            if (string.IsNullOrEmpty(Username))
            {
                reply.SetNecessaryParamMissReply(nameof(Username));
                return false;
            }
            if (string.IsNullOrEmpty(Password))
            {
                reply.SetNecessaryParamMissReply(nameof(Password));
                return false;
            }
            if (string.IsNullOrEmpty(CinemaCode))
            {
                reply.SetNecessaryParamMissReply(nameof(CinemaCode));
                return false;
            }
            if (string.IsNullOrEmpty(SessionCode))
            {
                reply.SetNecessaryParamMissReply(nameof(SessionCode));
                return false;
            }
            if (string.IsNullOrEmpty(Status))
            {
                reply.SetNecessaryParamMissReply(nameof(Status));
                return false;
            }

            return true;
        }

        /// <summary>
        /// 检查传入参数
        /// </summary>
        /// <param name="reply"></param>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <param name="QueryXml"></param>
        /// <returns></returns>
        public static bool RequestInfoGuard(this LockSeatReply reply, string Username, string Password,
            string QueryXml)
        {
            if (string.IsNullOrEmpty(Username))
            {
                reply.SetNecessaryParamMissReply(nameof(Username));
                return false;
            }
            if (string.IsNullOrEmpty(Password))
            {
                reply.SetNecessaryParamMissReply(nameof(Password));
                return false;
            }
            if (string.IsNullOrEmpty(QueryXml))
            {
                reply.SetNecessaryParamMissReply(nameof(QueryXml));
                return false;
            }

            return true;
        }

        /// <summary>
        /// 检查传入参数
        /// </summary>
        /// <param name="reply"></param>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <param name="QueryXml"></param>
        /// <returns></returns>
        public static bool RequestInfoGuard(this ReleaseSeatReply reply, string Username, string Password,
            string QueryXml)
        {
            if (string.IsNullOrEmpty(Username))
            {
                reply.SetNecessaryParamMissReply(nameof(Username));
                return false;
            }
            if (string.IsNullOrEmpty(Password))
            {
                reply.SetNecessaryParamMissReply(nameof(Password));
                return false;
            }
            if (string.IsNullOrEmpty(QueryXml))
            {
                reply.SetNecessaryParamMissReply(nameof(QueryXml));
                return false;
            }

            return true;
        }

        /// <summary>
        /// 检查传入参数
        /// </summary>
        /// <param name="reply"></param>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <param name="QueryXml"></param>
        /// <returns></returns>
        public static bool RequestInfoGuard(this SubmitOrderReply reply, string Username, string Password,
            string QueryXml)
        {
            if (string.IsNullOrEmpty(Username))
            {
                reply.SetNecessaryParamMissReply(nameof(Username));
                return false;
            }
            if (string.IsNullOrEmpty(Password))
            {
                reply.SetNecessaryParamMissReply(nameof(Password));
                return false;
            }
            if (string.IsNullOrEmpty(QueryXml))
            {
                reply.SetNecessaryParamMissReply(nameof(QueryXml));
                return false;
            }

            return true;
        }

        /// <summary>
        /// 检查传入参数
        /// </summary>
        /// <param name="reply"></param>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <param name="CinemaCode"></param>
        /// <param name="PrintNo"></param>
        /// <param name="VerifyCode"></param>
        /// <returns></returns>
        public static bool RequestInfoGuard(this QueryPrintReply reply, string Username, string Password,
            string CinemaCode, string PrintNo, string VerifyCode)
        {
            if (string.IsNullOrEmpty(Username))
            {
                reply.SetNecessaryParamMissReply(nameof(Username));
                return false;
            }
            if (string.IsNullOrEmpty(Password))
            {
                reply.SetNecessaryParamMissReply(nameof(Password));
                return false;
            }
            if (string.IsNullOrEmpty(CinemaCode))
            {
                reply.SetNecessaryParamMissReply(nameof(CinemaCode));
                return false;
            }
            if (string.IsNullOrEmpty(PrintNo))
            {
                reply.SetNecessaryParamMissReply(nameof(PrintNo));
                return false;
            }
            if (string.IsNullOrEmpty(VerifyCode))
            {
                reply.SetNecessaryParamMissReply(nameof(VerifyCode));
                return false;
            }

            return true;
        }
    }
}
