using System;

namespace NetSaleSvc.Util
{
    public static class DateTimeExtension
    {
        /// <summary>
        /// ISO 8601标准时间格式
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string ToFormatStringWithT(this DateTime dateTime)
        {
            return dateTime.ToString("s");
        }

        /// <summary>
        /// 标准日期字符串
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string ToFormatDateString(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// 标准日期字符串
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string ToFormatDateString(this DateTime? dateTime)
        {
            if (dateTime.HasValue)
            {
                return dateTime.Value.ToFormatDateString();
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
