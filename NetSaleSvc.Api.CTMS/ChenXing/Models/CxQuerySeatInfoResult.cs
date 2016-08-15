using System.Collections.Generic;
using System.Xml.Serialization;

namespace NetSaleSvc.Api.CTMS.ChenXing.Models
{
    [XmlRoot("QuerySeatInfoResult")]
    public class CxQuerySeatInfoResult : CxBaseReply
    {
        /// <summary>
        /// 座位信息
        /// </summary>
        [XmlElement]
        public CxQuerySeatInfoResultScreenSites ScreenSites { get; set; }
    }

    public class CxQuerySeatInfoResultScreenSites
    {
        /// <summary>
        /// 座位列表
        /// </summary>
        [XmlElement]
        public List<CxQuerySeatInfoResultScreenSite> ScreenSite { get; set; }
    }

    public class CxQuerySeatInfoResultScreenSite
    {
        /// <summary>
        /// 座位编码
        /// </summary>
        [XmlElement]
        public string SeatCode { get; set; }

        /// <summary>
        /// 分组编码，目前用于标识情侣座，两个GroupCode相同的座位为情侣座
        /// </summary>
        [XmlElement]
        public string GroupCode { get; set; }

        /// <summary>
        /// 行号
        /// </summary>
        [XmlElement]
        public string RowNum { get; set; }

        /// <summary>
        /// 列号
        /// </summary>
        [XmlElement]
        public string ColumnNum { get; set; }

        /// <summary>
        /// 座位横坐标
        /// </summary>
        [XmlElement]
        public int XCoord { get; set; }

        /// <summary>
        /// 座位纵坐标
        /// </summary>
        [XmlElement]
        public int YCoord { get; set; }

        /// <summary>
        /// 座位状态
        /// </summary>
        [XmlElement]
        public string Status { get; set; }
    }
}
