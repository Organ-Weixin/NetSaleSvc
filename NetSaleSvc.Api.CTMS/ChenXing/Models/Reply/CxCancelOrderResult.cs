using System.Xml.Serialization;

namespace NetSaleSvc.Api.CTMS.ChenXing.Models
{
    [XmlRoot("CancelOrderResult")]
    public class CxCancelOrderResult : CxBaseReply
    {
        /// <summary>
        /// 订单编码
        /// </summary>
        [XmlElement]
        public string OrderCode { get; set; }

        /// <summary>
        /// 取票序号
        /// </summary>
        [XmlElement]
        public string PrintNo { get; set; }

        /// <summary>
        /// 取票验证码
        /// </summary>
        [XmlElement]
        public string VerifyCode { get; set; }
    }
}
