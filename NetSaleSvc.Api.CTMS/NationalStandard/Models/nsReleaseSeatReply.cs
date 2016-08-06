using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace NetSaleSvc.Api.CTMS.NationalStandard.Models
{
    public class nsReleaseSeatReply : nsBaseReply
    {
        /// <summary>
        /// 订单信息
        /// </summary>
        [XmlElement]
        public nsReleaseSeatReplyOrder Order { get; set; }
    }

    public class nsReleaseSeatReplyOrder
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
        public List<nsReleaseSeatReplySeat> Seat { get; set; }
    }

    public class nsReleaseSeatReplySeat
    {
        /// <summary>
        /// 座位编码
        /// </summary>
        [XmlAttribute]
        public string SeatCode { get; set; }
    }
}
