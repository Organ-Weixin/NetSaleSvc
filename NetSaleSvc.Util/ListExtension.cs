using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetSaleSvc.Util
{
    public static class ListExtension
    {
        /// <summary>
        /// 确保List不为空
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static IList<T> NotNull<T>(this IList<T> list)
        {
            if (list == null)
            {
                list = new List<T>();
            }

            return list;
        }
    }
}
