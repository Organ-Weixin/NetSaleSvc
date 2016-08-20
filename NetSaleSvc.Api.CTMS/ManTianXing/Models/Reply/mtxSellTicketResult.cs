using System.Xml.Serialization;

namespace NetSaleSvc.Api.CTMS.ManTianXing.Models
{
    [XmlRoot("SellTicketResult")]
    public class mtxSellTicketResult : mtxBaseReply
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
    }
}
