using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetSaleSvc.Entity.Enum
{
    /// <summary>
    /// 影院设置的票价类型
    /// </summary>
    public enum PricePlanTypeEnum : byte
    {
        /// <summary>
        /// 影片价格
        /// </summary>
        [Description("Film")]
        Film = 1,

        /// <summary>
        /// 排期价格
        /// </summary>
        [Description("Session")]
        Session = 2,

        /// <summary>
        /// 最低价格
        /// </summary>
        [Description("LowestPrice")]
        LowestPrice = 3
    }
}
