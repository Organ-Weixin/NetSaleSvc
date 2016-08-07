using NetSaleSvc.Entity.Enum;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace NetSaleSvc.Api.Models
{
    public class SubmitOrderReply : BaseReply
    {
        #region ctor
        public SubmitOrderReply()
        {
            Id = ID_SubmitOrderReply;
        }
        #endregion

        /// <summary>
        /// 订单详情
        /// </summary>
        [XmlElement]
        public SubmitOrderReplyOrder Order { get; set; }
    }

    public class SubmitOrderReplyOrder
    {
        /// <summary>
        /// 影院类型
        /// </summary>
        [XmlAttribute]
        public CinemaTypeEnum CinemaType { get; set; }

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
        /// 取票序号
        /// </summary>
        [XmlAttribute]
        public string PrintNo { get; set; }

        /// <summary>
        /// 取票验证码
        /// </summary>
        [XmlAttribute]
        public string VerifyCode { get; set; }

        /// <summary>
        /// 座位列表
        /// </summary>
        [XmlElement]
        public List<SubmitOrderReplySeat> Seat { get; set; }
    }

    public class SubmitOrderReplySeat
    {
        /// <summary>
        /// 座位编码
        /// </summary>
        [XmlAttribute]
        public string SeatCode { get; set; }

        /// <summary>
        /// 电影票编码
        /// </summary>
        [XmlAttribute]
        public string FilmTicketCode { get; set; }
    }
}
