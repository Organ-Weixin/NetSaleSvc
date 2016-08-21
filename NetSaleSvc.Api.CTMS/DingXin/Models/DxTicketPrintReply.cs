namespace NetSaleSvc.Api.CTMS.DingXin.Models
{
    public class DxTicketPrintReply
    {
        public DxTicketPrintReplyRes res { get; set; }
    }

    public class DxTicketPrintReplyRes : DxBaseReplyRes
    {
        public DxTicketPrintReplyData data { get; set; }
    }

    public class DxTicketPrintReplyData
    {
        /// <summary>
        /// 请求出票总数
        /// </summary>
        public int printCount { get; set; }

        /// <summary>
        /// 已出票数
        /// </summary>
        public int successNum { get; set; }
    }
}
