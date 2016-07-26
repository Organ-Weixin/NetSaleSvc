using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NetSaleSvc.Api.Models
{
    /// <summary>
    /// QuerySeat接口返回实体
    /// </summary>
    public class QuerySeatReply : BaseReply
    {
        #region ctor
        public QuerySeatReply()
        {
            Id = ID_QuerySeatReply;
        }
        #endregion

        /// <summary>
        /// 影院
        /// </summary>
        [XmlElement]
        public QuerySeatReplyCinema Cinema { get; set; }
    }

    /// <summary>
    /// Cinema
    /// </summary>
    public class QuerySeatReplyCinema
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
        public QuerySeatReplyScreen Screen { get; set; }
    }

    /// <summary>
    /// Screen
    /// </summary>
    public class QuerySeatReplyScreen
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
        public List<QuerySeatReplySeat> Seat { get; set; }
    }

    /// <summary>
    /// Seat
    /// </summary>
    public class QuerySeatReplySeat
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

        /// <summary>
        /// 情侣座标识
        /// </summary>
        [XmlElement]
        public string LoveFlag { get; set; }
    }
}
