using System;

namespace NetSaleSvc.Util
{
    public class RandomHelper
    {
        /// <summary>
        /// 生成指定位数的随机密码
        /// </summary>
        /// <param name="sum">默认是6</param>
        /// <returns></returns>
        public static string CreatePwd(int sum = 6)
        {
            Random x = new Random();
            string p = "";
            for (int i = 0; i < sum; i++)
            {
                p += x.Next(1, 9);
            }
            return p;
        }
    }
}
