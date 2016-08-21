using System.Collections.Generic;

namespace NetSaleSvc.Api.CTMS.DingXin.Models
{
    public class DxTicketRefundReply
    {
        public DxTicketRefundReplyRes res { get; set; }
    }

    public class DxTicketRefundReplyRes : DxBaseReplyRes
    {
        /// <summary>
        /// 座位信息
        /// </summary>
        public List<DxTicketRefundReplySeat> data { get; set; }
    }

    public class DxTicketRefundReplySeat
    {
        /// <summary>
        /// 座位编号
        /// </summary>
        public string seatId { get; set; }

        /// <summary>
        /// 回退金额
        /// </summary>
        public string refundMoney { get; set; }

        /// <summary>
        /// 退票票号
        /// </summary>
        public string refundCode { get; set; }

        /// <summary>
        /// 退票时间
        /// </summary>
        public string refundTime { get; set; }
    }
}
