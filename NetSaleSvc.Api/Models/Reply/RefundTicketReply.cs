using NetSaleSvc.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NetSaleSvc.Api.Models
{
    public class RefundTicketReply : BaseReply
    {
        #region ctor
        public RefundTicketReply()
        {
            Id = ID_RefundTicketReply;
        }
        #endregion

        [XmlElement]
        public RefundTicketReplyOrder Order { get; set; }
    }

    public class RefundTicketReplyOrder
    {
        /// <summary>
        /// 订单编码
        /// </summary>
        [XmlAttribute]
        public string OrderCode { get; set; }

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
        /// 退票处理结果
        /// </summary>
        [XmlElement]
        public YesOrNoEnum Status { get; set; }

        /// <summary>
        /// 退票时间
        /// </summary>
        [XmlElement]
        public string RefundTime { get; set; }
    }
}
