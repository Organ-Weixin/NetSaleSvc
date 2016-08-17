using NetSaleSvc.Entity.Enum;
using System.Xml.Serialization;

namespace NetSaleSvc.Api.CTMS.ChenXing.Models
{
    [XmlRoot("QueryDeliveryStatusResult")]
    public class CxQueryDeliveryStatusResult : CxBaseReply
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

        /// <summary>
        /// 出票状态
        /// </summary>
        [XmlElement]
        public string PrintStatus { get; set; }

        /// <summary>
        /// 出票时间
        /// </summary>
        [XmlElement]
        public string PrintTime { get; set; }

        /// <summary>
        /// 卖品取货状态，目前无用
        /// </summary>
        [XmlElement]
        public string DeliveryStatus { get; set; }

        /// <summary>
        /// 卖品取货时间，目前无用
        /// </summary>
        [XmlElement]
        public string DeliveryTime { get; set; }
    }
}
