using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NetSaleSvc.Api.CTMS.NationalStandard.Models
{
    /// <summary>
    /// 查询放映计划座位状态返回实体
    /// </summary>
    public class nsQuerySessionSeatReply : nsBaseReply
    {
        [XmlElement]
        public nsQuerySessionSeatReplySessionSeat SessionSeat { get; set; }
    }

    public class nsQuerySessionSeatReplySessionSeat
    {
        /// <summary>
        /// 影院编码
        /// </summary>
        [XmlAttribute]
        public string CinemaCode { get; set; }

        /// <summary>
        /// 排期编码
        /// </summary>
        [XmlAttribute]
        public string SessionCode { get; set; }

        /// <summary>
        /// 座位列表
        /// </summary>
        [XmlElement]
        public List<nsQuerySessionSeatReplySeat> Seat { get; set; }
    }

    public class nsQuerySessionSeatReplySeat
    {
        /// <summary>
        /// 座位编码
        /// </summary>
        [XmlElement]
        public string Code { get; set; }

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
        /// 座位售出状态
        /// </summary>
        [XmlElement]
        public string Status { get; set; }
    }
}
