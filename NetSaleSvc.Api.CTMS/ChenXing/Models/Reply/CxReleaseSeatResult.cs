using System.Collections.Generic;
using System.Xml.Serialization;

namespace NetSaleSvc.Api.CTMS.ChenXing.Models
{
    [XmlRoot("ReleaseSeatResult")]
    public class CxReleaseSeatResult : CxBaseReply
    {
        /// <summary>
        /// 订单编码
        /// </summary>
        [XmlElement]
        public string OrderCode { get; set; }

        /// <summary>
        /// 排期编码
        /// </summary>
        [XmlElement]
        public string FeatureAppNo { get; set; }

        /// <summary>
        /// 座位信息
        /// </summary>
        [XmlElement]
        public CxReleaseSeatResultSeatInfos SeatInfos { get; set; }
    }

    public class CxReleaseSeatResultSeatInfos
    {
        /// <summary>
        /// 座位列表
        /// </summary>
        [XmlElement]
        public List<string> SeatCode { get; set; }
    }
}
