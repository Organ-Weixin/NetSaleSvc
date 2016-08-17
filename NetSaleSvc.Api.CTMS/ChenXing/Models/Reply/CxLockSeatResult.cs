using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace NetSaleSvc.Api.CTMS.ChenXing.Models
{
    [XmlRoot("LockSeatResult")]
    public class CxLockSeatResult : CxBaseReply
    {
        /// <summary>
        /// 订单编码
        /// </summary>
        [XmlElement]
        public string OrderCode { get; set; }

        /// <summary>
        /// 自动解锁时间
        /// </summary>
        [XmlElement]
        public string AutoUnlockDatetime { get; set; }

        /// <summary>
        /// 排期编码
        /// </summary>
        [XmlElement]
        public string FeatureAppNo { get; set; }

        /// <summary>
        /// 座位信息
        /// </summary>
        [XmlElement]
        public CxLockSeatResultSeatInfos SeatInfos { get; set; }
    }

    public class CxLockSeatResultSeatInfos
    {
        /// <summary>
        /// 座位编码列表
        /// </summary>
        [XmlElement]
        public List<string> SeatCode { get; set; }
    }
}
