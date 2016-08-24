using System.Collections.Generic;
using System.Xml.Serialization;

namespace NetSaleSvc.Api.Models
{
    [XmlRoot("SubmitOrder")]
    public class SubmitOrderQueryXml
    {
        /// <summary>
        /// 影院编码
        /// </summary>
        [XmlAttribute]
        public string CinemaCode { get; set; }

        /// <summary>
        /// 订单
        /// </summary>
        [XmlElement]
        public SubmitOrderQueryXmlOrder Order { get; set; }
    }

    public class SubmitOrderQueryXmlOrder
    {
        /// <summary>
        /// 满天星会员卡支付交易流水号
        /// </summary>
        [XmlAttribute]
        public string PaySeqNo { get; set; }

        /// <summary>
        /// 订单编码
        /// </summary>
        [XmlAttribute]
        public string OrderCode { get; set; }

        /// <summary>
        /// 排期编码
        /// </summary>
        [XmlAttribute]
        public string SessionCode { get; set; }

        /// <summary>
        /// 座位数量
        /// </summary>
        [XmlAttribute]
        public int Count { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        [XmlAttribute]
        public string MobilePhone { get; set; }

        /// <summary>
        /// 座位列表
        /// </summary>
        [XmlElement]
        public List<SubmitOrderQueryXmlSeat> Seat { get; set; }
    }

    public class SubmitOrderQueryXmlSeat
    {
        /// <summary>
        /// 座位编码
        /// </summary>
        [XmlAttribute]
        public string SeatCode { get; set; }

        /// <summary>
        /// 票价
        /// </summary>
        [XmlAttribute]
        public decimal Price { get; set; }

        /// <summary>
        /// 接入商实际销售票价
        /// </summary>
        [XmlAttribute]
        public decimal RealPrice { get; set; }

        /// <summary>
        /// 服务费
        /// </summary>
        [XmlAttribute]
        public decimal Fee { get; set; }
    }
}
