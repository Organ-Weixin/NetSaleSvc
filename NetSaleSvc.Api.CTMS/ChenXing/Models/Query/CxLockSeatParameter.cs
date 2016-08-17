using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace NetSaleSvc.Api.CTMS.ChenXing.Models
{
    [XmlRoot("LockSeatParameter")]
    public class CxLockSeatParameter
    {
        /// <summary>
        /// 应用编码
        /// </summary>
        [XmlElement]
        public string AppCode { get; set; }

        /// <summary>
        /// 影院编码
        /// </summary>
        [XmlElement]
        public string CinemaCode { get; set; }

        /// <summary>
        /// 排期编码
        /// </summary>
        [XmlElement]
        public string FeatureAppNo { get; set; }

        /// <summary>
        /// 座位信息
        /// </summary>
        [XmlElement]
        public CxLockSeatXmlSeatInfos SeatInfos { get; set; }

        /// <summary>
        /// 压缩标识
        /// </summary>
        [XmlElement]
        public string Compress { get; set; }

        /// <summary>
        /// 校验信息
        /// </summary>
        [XmlElement]
        public string VerifyInfo { get; set; }
    }

    public class CxLockSeatXmlSeatInfos
    {
        /// <summary>
        /// 座位编码列表
        /// </summary>
        [XmlElement]
        public List<string> SeatCode { get; set; }
    }
}
