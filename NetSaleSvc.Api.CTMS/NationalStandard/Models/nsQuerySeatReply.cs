using System.Collections.Generic;
using System.Xml.Serialization;

namespace NetSaleSvc.Api.CTMS.NationalStandard.Models
{
    [XmlType("QuerySeatReply")]
    public class nsQuerySeatReply : nsBaseReply
    {
        /// <summary>
        /// 影院
        /// </summary>
        [XmlElement]
        public nsQuerySeatReplyCinema Cinema { get; set; }
    }

    /// <summary>
    /// Cinema
    /// </summary>
    public class nsQuerySeatReplyCinema
    {
        /// <summary>
        /// 影院编码
        /// </summary>
        [XmlAttribute]
        public string Code { get; set; }

        /// <summary>
        /// 影厅
        /// </summary>
        [XmlElement]
        public nsQuerySeatReplyScreen Screen { get; set; }
    }

    /// <summary>
    /// Screen
    /// </summary>
    public class nsQuerySeatReplyScreen
    {
        /// <summary>
        /// 影厅编码
        /// </summary>
        [XmlAttribute]
        public string Code { get; set; }

        /// <summary>
        /// 影厅座位列表
        /// </summary>
        [XmlElement]
        public List<nsQuerySeatReplySeat> Seat { get; set; }
    }

    /// <summary>
    /// Seat
    /// </summary>
    public class nsQuerySeatReplySeat
    {
        /// <summary>
        /// 座位编码
        /// </summary>
        [XmlElement]
        public string Code { get; set; }
        /// <summary>
        /// 座位分组编码
        /// </summary>
        [XmlElement]
        public string GroupCode { get; set; }
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
        /// 座位横坐标
        /// </summary>
        [XmlElement]
        public int XCoord { get; set; }
        /// <summary>
        /// 座位纵坐标
        /// </summary>
        [XmlElement]
        public int YCoord { get; set; }
        /// <summary>
        /// 座位状态
        /// </summary>
        [XmlElement]
        public string Status { get; set; }
    }
}
