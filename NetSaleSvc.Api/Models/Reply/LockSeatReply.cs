using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NetSaleSvc.Api.Models
{
    public class LockSeatReply : BaseReply
    {
        #region ctor
        public LockSeatReply()
        {
            Id = ID_LockSeatReply;
        }
        #endregion

        /// <summary>
        /// 订单信息
        /// </summary>
        [XmlElement]
        public LockSeatReplyOrder Order { get; set; }
    }

    public class LockSeatReplyOrder
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        [XmlAttribute]
        public string OrderCode { get; set; }

        /// <summary>
        /// 自动解锁时间
        /// </summary>
        [XmlAttribute]
        public string AutoUnlockDatetime { get; set; }

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
        public List<LockSeatReplySeat> Seat { get; set; }
    }

    public class LockSeatReplySeat
    {
        /// <summary>
        /// 座位编码
        /// </summary>
        [XmlAttribute]
        public string SeatCode { get; set; }
    }
}
