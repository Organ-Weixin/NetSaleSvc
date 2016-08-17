using System.Collections.Generic;
using System.Xml.Serialization;

namespace NetSaleSvc.Api.CTMS.ChenXing.Models
{
    [XmlRoot("ApplyFetchTicketResult")]
    public class CxApplyFetchTicketResult : CxBaseReply
    {
        [XmlElement]
        public CxApplyFetchTicketResultTickets Tickets { get; set; }
    }

    public class CxApplyFetchTicketResultTickets
    {
        /// <summary>
        /// 请求结果列表
        /// </summary>
        [XmlElement]
        public List<CxApplyFetchTicketResultTicket> Ticket { get; set; }
    }

    public class CxApplyFetchTicketResultTicket
    {
        /// <summary>
        /// 取票序号
        /// </summary>
        [XmlElement]
        public string PrintNo { get; set; }

        /// <summary>
        /// 返回值 0-成功，1-电影票已打印，2-未知错误
        /// </summary>
        [XmlElement]
        public int ReturnValue { get; set; }
    }
}
