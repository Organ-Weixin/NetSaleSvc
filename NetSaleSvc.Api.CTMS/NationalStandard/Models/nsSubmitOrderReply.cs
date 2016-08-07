using System.Collections.Generic;
using System.Xml.Serialization;

namespace NetSaleSvc.Api.CTMS.NationalStandard.Models
{
    public class nsSubmitOrderReply : nsBaseReply
    {
        /// <summary>
        /// 订单详情
        /// </summary>
        [XmlElement]
        public nsSubmitOrderReplyOrder Order { get; set; }
    }

    public class nsSubmitOrderReplyOrder
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
        public List<nsSubmitOrderReplySeat> Seat { get; set; }
    }

    public class nsSubmitOrderReplySeat
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
