using System.Collections.Generic;
using System.Xml.Serialization;

namespace NetSaleSvc.Api.CTMS.ChenXing.Models
{
    [XmlRoot("QueryTicketInfoParameter")]
    public class CxQueryTicketInfoParameter
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
        /// 影票信息
        /// </summary>
        [XmlElement]
        public CxQueryTicketInfoParameterTickets Tickets { get; set; }

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

    public class CxQueryTicketInfoParameterTickets
    {
        /// <summary>
        /// 影票列表
        /// </summary>
        [XmlElement]
        public List<CxQueryTicketInfoParameterTicket> Ticket { get; set; }
    }

    public class CxQueryTicketInfoParameterTicket
    {
        /// <summary>
        /// 取票序号
        /// </summary>
        [XmlElement]
        public string PrintNo { get; set; }
    }
}
