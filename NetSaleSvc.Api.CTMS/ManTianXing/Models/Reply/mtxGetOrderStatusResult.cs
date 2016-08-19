using System.Xml.Serialization;

namespace NetSaleSvc.Api.CTMS.ManTianXing.Models
{
    [XmlRoot("GetOrderStatusResult")]
    public class mtxGetOrderStatusResult : mtxBaseReply
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        [XmlElement]
        public string OrderNo { get; set; }

        /// <summary>
        /// 订单验证码
        /// </summary>
        [XmlElement]
        public string ValidCode { get; set; }

        /// <summary>
        /// 订单状态：
        /// 4已支付
        /// 6支付失败
        /// 7已退票
        /// 8已打票
        /// 9地面售票成功
        /// </summary>
        [XmlElement]
        public string OrderStatus { get; set; }
    }
}
