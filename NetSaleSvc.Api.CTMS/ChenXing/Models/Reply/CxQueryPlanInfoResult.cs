using System.Collections.Generic;
using System.Xml.Serialization;

namespace NetSaleSvc.Api.CTMS.ChenXing.Models
{
    [XmlRoot("QueryPlanInfoResult")]
    public class CxQueryPlanInfoResult : CxBaseReply
    {
        [XmlElement]
        public CxQueryPlanInfoResultCinemaPlans CinemaPlans { get; set; }
    }

    public class CxQueryPlanInfoResultCinemaPlans
    {
        [XmlElement]
        public List<CxQueryPlanInfoResultCinemaPlan> CinemaPlan { get; set; }
    }

    public class CxQueryPlanInfoResultCinemaPlan
    {
        /// <summary>
        /// 影厅编码
        /// </summary>
        [XmlElement]
        public string ScreenCode { get; set; }

        /// <summary>
        /// 排期编码
        /// </summary>
        [XmlElement]
        public string FeatureAppNo { get; set; }

        /// <summary>
        /// 排期开始时间
        /// </summary>
        [XmlElement]
        public string StartTime { get; set; }

        /// <summary>
        /// 连场标识
        /// </summary>
        [XmlElement]
        public string PlaythroughFlag { get; set; }

        /// <summary>
        /// 影片列表
        /// </summary>
        [XmlElement]
        public CxQueryPlanInfoResultFilms Films { get; set; }

        /// <summary>
        /// 价格信息
        /// </summary>
        [XmlElement]
        public CxQueryPlanInfoResultPrice Price { get; set; }
    }

    public class CxQueryPlanInfoResultFilms
    {
        /// <summary>
        /// 影片列表
        /// </summary>
        [XmlElement]
        public List<CxQueryPlanInfoResultFilm> Film { get; set; }
    }

    public class CxQueryPlanInfoResultFilm
    {
        /// <summary>
        /// 影片编码
        /// </summary>
        [XmlElement]
        public string FilmCode { get; set; }

        /// <summary>
        /// 影片名称
        /// </summary>
        [XmlElement]
        public string FilmName { get; set; }

        /// <summary>
        /// 语言
        /// </summary>
        [XmlElement]
        public string Lang { get; set; }

        /// <summary>
        /// 影片时长
        /// </summary>
        [XmlElement]
        public int Duration { get; set; }

        /// <summary>
        /// 连场中的序号
        /// </summary>
        [XmlElement]
        public int Sequence { get; set; }
    }

    public class CxQueryPlanInfoResultPrice
    {
        /// <summary>
        /// 最低价
        /// </summary>
        [XmlElement]
        public decimal LowestPrice { get; set; }

        /// <summary>
        /// 标准价
        /// </summary>
        [XmlElement]
        public decimal StandardPrice { get; set; }

        /// <summary>
        /// 门市价
        /// </summary>
        [XmlElement]
        public decimal ListingPrice { get; set; }
    }
}
