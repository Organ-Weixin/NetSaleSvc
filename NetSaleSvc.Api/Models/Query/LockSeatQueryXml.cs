using System.Collections.Generic;
using System.Xml.Serialization;

namespace NetSaleSvc.Api.Models
{
    [XmlRoot("LockSeat")]
    public class LockSeatQueryXml
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
        public LockSeatQueryXmlOrder Order { get; set; }
    }

    public class LockSeatQueryXmlOrder
    {
        /// <summary>
        /// 场次编码
        /// </summary>
        [XmlAttribute]
        public string SessionCode { get; set; }

        /// <summary>
        /// 锁座数量
        /// </summary>
        [XmlAttribute]
        public int Count { get; set; }

        /// <summary>
        /// 支付方式，满天星专用，其他系统忽略。1表示会员支付，其他表示非会员支付
        /// </summary>
        [XmlAttribute]
        public string PayType { get; set; }

        /// <summary>
        /// 座位列表
        /// </summary>
        [XmlElement]
        public List<LockSeatQueryXmlSeat> Seat { get; set; }
    }

    public class LockSeatQueryXmlSeat
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
        /// 服务费
        /// </summary>
        [XmlAttribute]
        public decimal Fee { get; set; }
    }
}
