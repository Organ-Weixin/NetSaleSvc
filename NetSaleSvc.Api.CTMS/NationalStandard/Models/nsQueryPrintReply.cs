using NetSaleSvc.Entity.Enum;
using System.Xml.Serialization;

namespace NetSaleSvc.Api.CTMS.NationalStandard.Models
{
    public class nsQueryPrintReply : nsBaseReply
    {
        [XmlElement]
        public nsQueryPrintReplyOrder Order { get; set; }
    }

    public class nsQueryPrintReplyOrder
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
        /// 打印状态
        /// </summary>
        [XmlElement]
        public PrintStatusEnum Status { get; set; }

        /// <summary>
        /// 打印时间
        /// </summary>
        [XmlElement]
        public string PrintTime { get; set; }
    }
}
