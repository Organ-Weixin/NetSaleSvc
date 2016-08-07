using NetSaleSvc.Util;
using System;
using System.Xml.Serialization;

namespace NetSaleSvc.Api.Models
{
    /// <summary>
    /// 返回报文主体
    /// </summary>
    [XmlRoot]
    public class OnlineTicketingServiceReply
    {
        /// <summary>
        /// Version
        /// </summary>
        [XmlAttribute]
        public string Version { get; set; } = "2.0";

        /// <summary>
        /// 时间
        /// </summary>
        [XmlAttribute]
        public string Datetime { get; set; } = DateTime.Now.ToFormatStringWithT();

        /// <summary>
        /// 查询影院列表返回实体
        /// </summary>
        [XmlElement]
        public QueryCinemaListReply QueryCinemaListReply { get; set; }

        /// <summary>
        /// 查询影院信息返回实体
        /// </summary>
        [XmlElement]
        public QueryCinemaReply QueryCinemaReply { get; set; }

        /// <summary>
        /// 查询影厅座位信息
        /// </summary>
        [XmlElement]
        public QuerySeatReply QuerySeatReply { get; set; }

        /// <summary>
        /// 查询影片信息接口
        /// </summary>
        [XmlElement]
        public QueryFilmReply QueryFilmReply { get; set; }

        /// <summary>
        /// 查询影院放映计划信息
        /// </summary>
        [XmlElement]
        public QuerySessionReply QuerySessionReply { get; set; }

        /// <summary>
        /// 查询放映计划座位售出状态
        /// </summary>
        [XmlElement]
        public QuerySessionSeatReply QuerySessionSeatReply { get; set; }

        /// <summary>
        /// 锁座
        /// </summary>
        [XmlElement]
        public LockSeatReply LockSeatReply { get; set; }

        /// <summary>
        /// 解锁座位
        /// </summary>
        [XmlElement]
        public ReleaseSeatReply ReleaseSeatReply { get; set; }

        /// <summary>
        /// 确认订单
        /// </summary>
        [XmlElement]
        public SubmitOrderReply SubmitOrderReply { get; set; }
    }
}