using NetSaleSvc.Entity.Enum;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace NetSaleSvc.Api.CTMS.NationalStandard.Models
{
    public class nsQueryOrderReply : nsBaseReply
    {
        [XmlElement]
        public nsQueryOrderReplyOrder Order { get; set; }
    }

    public class nsQueryOrderReplyOrder
    {
        /// <summary>
        /// 订单编码
        /// </summary>
        [XmlAttribute]
        public string OrderCode { get; set; }

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
        /// 排期编码
        /// </summary>
        [XmlElement]
        public string SessionCode { get; set; }

        /// <summary>
        /// 排期开始时间
        /// </summary>
        [XmlElement]
        public string StartTime { get; set; }

        /// <summary>
        /// 连场标识
        /// </summary>
        [XmlElement]
        public string PlaythroughFlag { get; set; }

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
        /// 影片信息
        /// </summary>
        [XmlElement]
        public nsQueryOrderReplyFilms Films { get; set; }

        /// <summary>
        /// 座位信息
        /// </summary>
        [XmlElement]
        public nsQueryOrderReplySeats Seats { get; set; }
    }

    public class nsQueryOrderReplyFilms
    {
        /// <summary>
        /// 影片列表
        /// </summary>
        [XmlElement]
        public List<nsQueryOrderReplyFilm> Film { get; set; }
    }

    public class nsQueryOrderReplyFilm
    {
        /// <summary>
        /// 影片编码
        /// </summary>
        [XmlElement]
        public string Code { get; set; }

        /// <summary>
        /// 影片名称
        /// </summary>
        [XmlElement]
        public string Name { get; set; }

        /// <summary>
        /// 影片时长
        /// </summary>
        [XmlElement]
        public string Duration { get; set; }

        /// <summary>
        /// 影片在连场中的序号
        /// </summary>
        [XmlElement]
        public string Sequence { get; set; }
    }

    public class nsQueryOrderReplySeats
    {
        /// <summary>
        /// 座位列表
        /// </summary>
        [XmlElement]
        public List<nsQueryOrderReplySeat> Seat { get; set; }
    }

    public class nsQueryOrderReplySeat
    {
        /// <summary>
        /// 座位编码
        /// </summary>
        [XmlElement]
        public string SeatCode { get; set; }

        /// <summary>
        /// 座位行号
        /// </summary>
        [XmlElement]
        public string RowNum { get; set; }

        /// <summary>
        /// 座位列号
        /// </summary>
        [XmlElement]
        public string ColumnNum { get; set; }

        /// <summary>
        /// 电影票编码
        /// </summary>
        [XmlElement]
        public string FilmTicketCode { get; set; }

        /// <summary>
        /// 出票状态
        /// </summary>
        [XmlElement]
        public YesOrNoEnum PrintStatus { get; set; }

        /// <summary>
        /// 出票时间
        /// </summary>
        [XmlElement]
        public string PrintTime { get; set; }

        /// <summary>
        /// 退票状态
        /// </summary>
        [XmlElement]
        public YesOrNoEnum RefundStatus { get; set; }

        /// <summary>
        /// 退票时间
        /// </summary>
        [XmlElement]
        public string RefundTime { get; set; }
    }
}
