using System;
using System.Collections.Generic;

namespace NetSaleSvc.Util
{
    public static class FilmCodeUtil
    {
        private static List<string> _3DFlags = new List<string> {
            "2", "4", "9", "c", "e", "j", "m", "o", "t", "w", "y", "D"
        };

        /// <summary>
        /// 获取影片维度
        /// </summary>
        /// <param name="FilmCode"></param>
        /// <returns></returns>
        public static string GetFilmDimensional(string FilmCode)
        {
            if (string.IsNullOrEmpty(FilmCode))
            {
                throw new ArgumentNullException(nameof(FilmCode));
            }

            string DimensionalFlag = FilmCode.Substring(3, 1);
            if (_3DFlags.Contains(DimensionalFlag))
            {
                return "3D";
            }
            else
            {
                return "2D";
            }
        }

        /// <summary>
        /// 获取影片语言
        /// </summary>
        /// <param name="FilmCode"></param>
        /// <returns></returns>
        public static string GetFilmLanguage(string FilmCode)
        {
            try
            {
                string CountryCode = FilmCode.Substring(0, 3);
                switch (CountryCode)
                {
                    case "001":
                    case "002":
                    case "003":
                    case "004":
                        return "国语";
                    case "010":
                        return "韩语";
                    case "012":
                        return "日语";
                    case "013":
                        return "越南语";
                    case "014":
                        return "泰语";
                    case "019":
                        return "印度语";
                    default:
                        return "英语";
                }
            }
            catch
            {
                return "国语";
            }
        }
    }
}
