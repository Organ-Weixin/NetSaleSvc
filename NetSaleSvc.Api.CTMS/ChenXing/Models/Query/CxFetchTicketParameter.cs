using System.Collections.Generic;
using System.Xml.Serialization;

namespace NetSaleSvc.Api.CTMS.ChenXing.Models
{
    [XmlRoot("FetchTicketParameter")]
    public class CxFetchTicketParameter
    {
        /// <summary>
        /// 应用编码
        /// </summary>
        [XmlElement]
        public string AppCode { get; set; }

        /// <summary>
        /// 影院编码
        /// </summary>
        [XmlElement]
        public string CinemaCode { get; set; }

        /// <summary>
        /// 需要出票的影票信息
        /// </summary>
        [XmlElement]
        public CxFetchTicketParameterTickets Tickets { get; set; }

        /// <summary>
        /// 是否压缩
        /// </summary>
        [XmlElement]
        public string Compress { get; set; }

        /// <summary>
        /// 校验信息
        /// </summary>
        [XmlElement]
        public string VerifyInfo { get; set; }
    }

    public class CxFetchTicketParameterTickets
    {
        /// <summary>
        /// 影票列表
        /// </summary>
        [XmlElement]
        public List<CxFetchTicketParameterTicket> Ticket { get; set; }
    }

    public class CxFetchTicketParameterTicket
    {
        /// <summary>
        /// 取票序号
        /// </summary>
        [XmlElement]
        public string PrintNo { get; set; }
    }
}
