using System.Collections.Generic;
using System.Xml.Serialization;

namespace NetSaleSvc.Api.Models
{
    [XmlRoot("LockSeat")]
    public class LockSeatQueryXml
    {
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
        public string Count { get; set; }

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
    }
}
