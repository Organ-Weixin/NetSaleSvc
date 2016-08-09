using System.Xml.Serialization;

namespace NetSaleSvc.Api.CTMS.NationalStandard.Models
{
    [XmlRoot("ApplyFetchTicketReply")]
    public class nsApplyFetchTicketResult
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

        /// <summary>
        /// 取票码
        /// </summary>
        [XmlElement]
        public string PrintNo { get; set; }
    }
}
