using System.Collections.Generic;
using System.Xml.Serialization;

namespace NetSaleSvc.Api.CTMS.ChenXing.Models
{
    [XmlRoot("ApplyFetchTicketParameter")]
    public class CxApplyFetchTicketParameter
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
        public CxApplyFetchTicketParameterTickets Tickets { get; set; }

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

    public class CxApplyFetchTicketParameterTickets
    {
        /// <summary>
        /// 影票列表
        /// </summary>
        [XmlElement]
        public List<CxApplyFetchTicketParameterTicket> Ticket { get; set; }
    }

    public class CxApplyFetchTicketParameterTicket
    {
        /// <summary>
        /// 取票序号
        /// </summary>
        [XmlElement]
        public string PrintNo { get; set; }

        /// <summary>
        /// 取票验证码MD5加密后的字符串
        /// </summary>
        [XmlElement]
        public string VerifyCodeMD5 { get; set; }
    }
}
