using System.Xml.Serialization;

namespace NetSaleSvc.Api.CTMS.ManTianXing.Models
{
    public class mtxBaseReply
    {
        /// <summary>
        /// 返回结果号
        /// </summary>
        [XmlElement]
        public string ResultCode { get; set; }
    }
}
