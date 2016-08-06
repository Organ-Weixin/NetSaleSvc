using System.Collections.Generic;
using System.Xml.Serialization;

namespace NetSaleSvc.Api.Models
{
    public class ReleaseSeatReply : BaseReply
    {
        #region ctor
        public ReleaseSeatReply()
        {
            Id = ID_ReleaseSeatReply;
        }
        #endregion

        /// <summary>
        /// 订单信息
        /// </summary>
        [XmlElement]
        public ReleaseSeatReplyOrder Order { get; set; }
    }

    public class ReleaseSeatReplyOrder
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        [XmlAttribute]
        public string OrderCode { get; set; }

        /// <summary>
        /// 排期编码
        /// </summary>
        [XmlAttribute]
        public string SessionCode { get; set; }

        /// <summary>
        /// 座位数量
        /// </summary>
        [XmlAttribute]
        public int Count { get; set; }

        /// <summary>
        /// 座位列表
        /// </summary>
        [XmlElement]
        public List<ReleaseSeatReplySeat> Seat { get; set; }
    }

    public class ReleaseSeatReplySeat
    {
        /// <summary>
        /// 座位编码
        /// </summary>
        [XmlAttribute]
        public string SeatCode { get; set; }
    }
}
