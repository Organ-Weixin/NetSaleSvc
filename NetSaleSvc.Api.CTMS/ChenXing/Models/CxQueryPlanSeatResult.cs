using System.Collections.Generic;
using System.Xml.Serialization;

namespace NetSaleSvc.Api.CTMS.ChenXing.Models
{
    [XmlRoot("QueryPlanSeatResult")]
    public class CxQueryPlanSeatResult : CxBaseReply
    {
        /// <summary>
        /// 排期编码
        /// </summary>
        [XmlElement]
        public string FeatureAppNo { get; set; }

        /// <summary>
        /// 座位信息
        /// </summary>
        [XmlElement]
        public CxQueryPlanSeatResultPlanSiteStates PlanSiteStates { get; set; }
    }

    public class CxQueryPlanSeatResultPlanSiteStates
    {
        /// <summary>
        /// 座位列表
        /// </summary>
        [XmlElement]
        public List<CxQueryPlanSeatResultPlanSiteState> PlanSiteState { get; set; }
    }

    public class CxQueryPlanSeatResultPlanSiteState
    {
        /// <summary>
        /// 座位编码
        /// </summary>
        [XmlElement]
        public string SeatCode { get; set; }

        /// <summary>
        /// 座位行号
        /// </summary>
        [XmlElement]
        public string RowNum { get; set; }

        /// <summary>
        /// 座位列号
        /// </summary>
        [XmlElement]
        public string ColumnNum { get; set; }

        /// <summary>
        /// 座位状态
        /// </summary>
        [XmlElement]
        public string Status { get; set; }
    }
}
