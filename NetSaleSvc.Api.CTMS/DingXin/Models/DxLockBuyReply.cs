using System.Collections.Generic;

namespace NetSaleSvc.Api.CTMS.DingXin.Models
{
    public class DxLockBuyReply
    {
        public DxLockBuyReplyRes res { get; set; }
    }

    public class DxLockBuyReplyRes : DxBaseReplyRes
    {
        public DxLockBuyReplyData data { get; set; }
    }

    public class DxLockBuyReplyData
    {
        /// <summary>
        /// 取票验证码第1部分（序列号）
        /// </summary>
        public string ticketFlag1 { get; set; }

        /// <summary>
        /// 取票验证码第2部分（验证码）
        /// </summary>
        public string ticketFlag2 { get; set; }

        /// <summary>
        /// 售票信息
        /// </summary>
        public List<DxLockBuyReplySellInfo> sellInfo { get; set; }
    }

    public class DxLockBuyReplySellInfo
    {
        /// <summary>
        /// 影院座位ID
        /// </summary>
        public string seatId { get; set; }

        /// <summary>
        /// 售票时间
        /// </summary>
        public string sellTime { get; set; }

        /// <summary>
        /// 票号
        /// </summary>
        public string sellId { get; set; }

        /// <summary>
        /// 票价
        /// </summary>
        public string ticketIncome { get; set; }

        /// <summary>
        /// 连场销售票房价格
        /// </summary>
        public string joinIncome { get; set; }
    }
}
