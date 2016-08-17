using System.Xml.Serialization;

namespace NetSaleSvc.Api.CTMS.ChenXing.Models
{
    public class CxBaseReply
    {
        /// <summary>
        /// 返回结果号
        /// </summary>
        [XmlElement]
        public string ResultCode { get; set; }

        /// <summary>
        /// 返回信息
        /// </summary>
        [XmlElement]
        public string Message { get; set; }
    }
}
