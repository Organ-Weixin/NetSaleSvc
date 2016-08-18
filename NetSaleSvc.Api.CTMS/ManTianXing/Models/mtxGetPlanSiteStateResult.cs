using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NetSaleSvc.Api.CTMS.ManTianXing.Models
{
    [XmlRoot("GetPlanSiteStateResult")]
    public class mtxGetPlanSiteStateResult : mtxBaseReply
    {
        /// <summary>
        /// 排期座位信息
        /// </summary>
        [XmlElement]
        public mtxGetPlanSiteStateResultPlanSiteStates PlanSiteStates { get; set; }
    }

    public class mtxGetPlanSiteStateResultPlanSiteStates
    {
        /// <summary>
        /// 排期座位列表
        /// </summary>
        [XmlElement]
        public List<mtxGetPlanSiteStateResultPlanSiteState> PlanSiteState { get; set; }
    }

    public class mtxGetPlanSiteStateResultPlanSiteState
    {
        /// <summary>
        /// 座位编码
        /// </summary>
        [XmlElement]
        public string SeatNo { get; set; }

        /// <summary>
        /// 座区编码
        /// </summary>
        [XmlElement]
        public string SeatPieceNo { get; set; }

        /// <summary>
        /// y坐标
        /// </summary>
        [XmlElement]
        public string GraphRow { get; set; }

        /// <summary>
        /// x坐标
        /// </summary>
        [XmlElement]
        public string GraphCol { get; set; }

        /// <summary>
        /// 行
        /// </summary>
        [XmlElement]
        public string SeatRow { get; set; }

        /// <summary>
        /// 列
        /// </summary>
        [XmlElement]
        public string SeatCol { get; set; }

        /// <summary>
        /// 状态	(-1不可售  0-未售，1-售出，3-预订，4-选中，7-已锁定,9-验收)
        /// </summary>
        [XmlElement]
        public string SeatState { get; set; }

        /// <summary>
        /// 座区名称
        /// </summary>
        [XmlElement]
        public string SeatPieceName { get; set; }
    }
}
