using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NetSaleSvc.Api.Models
{
    [XmlRoot("ReleaseSeat")]
    public class ReleaseSeatQueryXml
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
        public ReleaseSeatQueryXmlOrder Order { get; set; }
    }

    public class ReleaseSeatQueryXmlOrder
    {
        /// <summary>
        /// 订单编码
        /// </summary>
        [XmlAttribute]
        public string OrderCode { get; set; }

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
        /// 座位列表
        /// </summary>
        [XmlElement]
        public List<ReleaseSeatQueryXmlSeat> Seat { get; set; }
    }

    public class ReleaseSeatQueryXmlSeat
    {
        /// <summary>
        /// 座位编码
        /// </summary>
        [XmlAttribute]
        public string SeatCode { get; set; }
    }
}
