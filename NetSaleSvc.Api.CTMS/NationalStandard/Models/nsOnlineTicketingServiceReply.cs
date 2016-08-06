using System.Xml.Serialization;

namespace NetSaleSvc.Api.CTMS.NationalStandard.Models
{
    [XmlType("OnlineTicketingServiceReply")]
    public class nsOnlineTicketingServiceReply
    {
        /// <summary>
        /// Version
        /// </summary>
        [XmlAttribute]
        public string Version { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        [XmlAttribute]
        public string Datetime { get; set; }

        /// <summary>
        /// 查询影院信息返回实体
        /// </summary>
        [XmlElement]
        public nsQueryCinemaReply QueryCinemaReply { get; set; }

        /// <summary>
        /// 查询影厅信息返回实体
        /// </summary>
        [XmlElement]
        public nsQuerySeatReply QuerySeatReply { get; set; }

        /// <summary>
        /// 查询影片信息返回实体
        /// </summary>
        [XmlElement]
        public nsQueryFilmReply QueryFilmReply { get; set; }

        /// <summary>
        /// 查询放映计划返回实体
        /// </summary>
        [XmlElement]
        public nsQuerySessionReply QuerySessionReply { get; set; }

        /// <summary>
        /// 查询放映计划座位状态返回实体
        /// </summary>
        [XmlElement]
        public nsQuerySessionSeatReply QuerySessionSeatReply { get; set; }

        /// <summary>
        /// 锁定座位返回实体
        /// </summary>
        [XmlElement]
        public nsLockSeatReply LockSeatReply { get; set; }

        /// <summary>
        /// 解锁座位返回实体
        /// </summary>
        [XmlElement]
        public nsReleaseSeatReply ReleaseSeatReply { get; set; }
    }
}
