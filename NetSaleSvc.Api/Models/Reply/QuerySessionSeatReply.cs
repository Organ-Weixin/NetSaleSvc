using System.Collections.Generic;
using System.Xml.Serialization;

namespace NetSaleSvc.Api.Models
{
    public class QuerySessionSeatReply : BaseReply
    {
        #region ctor
        public QuerySessionSeatReply()
        {
            Id = ID_QuerySessionSeatReply;
        }
        #endregion

        [XmlElement]
        public QuerySessionSeatReplySessionSeat SessionSeat { get; set; }
    }

    public class QuerySessionSeatReplySessionSeat
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
        public List<QuerySessionSeatReplySeat> Seat { get; set; }
    }

    public class QuerySessionSeatReplySeat
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
