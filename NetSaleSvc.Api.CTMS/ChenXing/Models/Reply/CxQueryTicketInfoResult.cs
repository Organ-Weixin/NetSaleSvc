using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NetSaleSvc.Api.CTMS.ChenXing.Models
{
    [XmlRoot("QueryTicketInfoResult")]
    public class CxQueryTicketInfoResult : CxBaseReply
    {
        /// <summary>
        /// 影票信息
        /// </summary>
        [XmlElement]
        public CxQueryTicketInfoResultTickets Tickets { get; set; }
    }

    public class CxQueryTicketInfoResultTickets
    {
        /// <summary>
        /// 影票信息列表
        /// </summary>
        [XmlElement]
        public List<CxQueryTicketInfoResultTicket> Ticket { get; set; }
    }

    public class CxQueryTicketInfoResultTicket
    {
        /// <summary>
        /// 取票序号
        /// </summary>
        [XmlElement]
        public string PrintNo { get; set; }

        /// <summary>
        /// 电影票信息码
        /// </summary>
        [XmlElement]
        public string TicketInfoCode { get; set; }

        /// <summary>
        /// 影院编码
        /// </summary>
        [XmlElement]
        public string CinemaCode { get; set; }

        /// <summary>
        /// 影院名称
        /// </summary>
        [XmlElement]
        public string CinemaName { get; set; }

        /// <summary>
        /// 影厅编码
        /// </summary>
        [XmlElement]
        public string ScreenCode { get; set; }

        /// <summary>
        /// 影厅名称
        /// </summary>
        [XmlElement]
        public string ScreenName { get; set; }

        /// <summary>
        /// 影片编码
        /// </summary>
        [XmlElement]
        public string FilmCode { get; set; }

        /// <summary>
        /// 影片名称
        /// </summary>
        [XmlElement]
        public string FilmName { get; set; }

        /// <summary>
        /// 排期编号
        /// </summary>
        [XmlElement]
        public string FeatureAppNo { get; set; }

        /// <summary>
        /// 排期开始时间
        /// </summary>
        [XmlElement]
        public string StartTime { get; set; }

        /// <summary>
        /// 影票编码
        /// </summary>
        [XmlElement]
        public string TicketCode { get; set; }

        /// <summary>
        /// 座位编码
        /// </summary>
        [XmlElement]
        public string SeatCode { get; set; }

        /// <summary>
        /// 座位名称
        /// </summary>
        [XmlElement]
        public string SeatName { get; set; }

        /// <summary>
        /// 票价，不包括服务费
        /// </summary>
        [XmlElement]
        public decimal Price { get; set; }

        /// <summary>
        /// 服务费
        /// </summary>
        [XmlElement]
        public decimal Service { get; set; }

        /// <summary>
        /// 打印标识  0-未打印，1-已打印
        /// </summary>
        [XmlElement]
        public string PrintFlag { get; set; }
    }
}
