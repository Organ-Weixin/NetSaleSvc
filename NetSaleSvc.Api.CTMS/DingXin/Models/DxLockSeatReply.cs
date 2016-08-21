namespace NetSaleSvc.Api.CTMS.DingXin.Models
{
    public class DxLockSeatReply
    {
        public DxLockSeatReplyRes res { get; set; }
    }

    public class DxLockSeatReplyRes : DxBaseReplyRes
    {
        public DxLockSeatReplyData data { get; set; }
    }

    public class DxLockSeatReplyData
    {
        /// <summary>
        /// 锁定标志位
        /// </summary>
        public string lockFlag { get; set; }

        /// <summary>
        /// 电商平台启用算出的价格，如果该值不为空，则售卖价格需大于等于该价格
        /// </summary>
        public decimal? partnerPrice { get; set; }
    }
}
