using System.Xml.Serialization;

namespace NetSaleSvc.Api.CTMS.NationalStandard.Models
{
    [XmlRoot("FetchTicketReply")]
    public class nsFetchTicketResult
    {
        /// <summary>
        /// 返回结果号
        /// </summary>
        [XmlElement]
        public string ResultCode { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        [XmlElement]
        public string Message { get; set; }
    }
}
