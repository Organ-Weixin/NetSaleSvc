using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NetSaleSvc.Api.CTMS.ChenXing.Models
{
    [XmlRoot("QueryOrderStatusResult")]
    public class CxQueryOrderStatusReply : CxBaseReply
    {
        /// <summary>
        /// 订单编码
        /// </summary>
        [XmlElement]
        public string OrderCode { get; set; }

        /// <summary>
        /// 取票序号
        /// </summary>
        [XmlElement]
        public string PrintNo { get; set; }

        /// <summary>
        /// 取票验证码
        /// </summary>
        [XmlElement]
        public string VerifyCode { get; set; }

        /// <summary>
        /// 订单交易状态
        /// </summary>
        [XmlElement]
        public string OrderStatus { get; set; }
    }
}
