using System.Collections.Generic;
using System.Xml.Serialization;

namespace NetSaleSvc.Api.CTMS.NationalStandard.Models
{
    [XmlRoot("QueryTicketInfoReply")]
    public class nsQueryTicketReply
    {
        /// <summary>
        /// 返回结果号
        /// </summary>
        [XmlElement]
        public string ResultCode { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        [XmlElement]
        public string Message { get; set; }

        /// <summary>
        /// 影票信息
        /// </summary>
        [XmlElement]
        public nsQueryTicketReplyTickets Tickets { get; set; }
    }

    public class nsQueryTicketReplyTickets
    {
        /// <summary>
        /// 影票列表
        /// </summary>
        [XmlElement]
        public List<nsQueryTicketReplyTicket> Ticket { get; set; }
    }

    public class nsQueryTicketReplyTicket
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
        /// 排期编码
        /// </summary>
        [XmlElement]
        public string SessionCode { get; set; }

        /// <summary>
        /// 排期时间
        /// </summary>
        [XmlElement]
        public string SessionDateTime { get; set; }

        /// <summary>
        /// 电影票编码
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
        /// 票价
        /// </summary>
        [XmlElement]
        public string Price { get; set; }

        /// <summary>
        /// 服务费
        /// </summary>
        [XmlElement]
        public string Service { get; set; }

        /// <summary>
        /// 打印标识
        /// </summary>
        [XmlElement]
        public string PrintFlag { get; set; }
    }
}
