using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace NetSaleSvc.Api.CTMS.DingXin.Models
{
    public class DxBaseReply
    {
        /// <summary>
        /// 返回状态值
        /// </summary>
        [XmlElement]
        public string status { get; set; }
        /// <summary>
        /// 错误描述
        /// </summary>
        [XmlElement]
        public string errorMessage { get; set; }
        /// <summary>
        /// 错误代码
        /// </summary>
        [XmlElement]
        public string errorCode { get; set; }
    }
}
