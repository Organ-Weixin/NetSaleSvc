using System.Collections.Generic;
using System.Xml.Serialization;

namespace NetSaleSvc.Api.CTMS.ChenXing.Models
{
    [XmlRoot("QueryCinemaInfoResult")]
    public class CxQueryCinemaInfoResult : CxBaseReply
    {
        [XmlElement]
        public CxQueryCinemaInfoResultCinema Cinema { get; set; }
    }

    public class CxQueryCinemaInfoResultCinema
    {
        /// <summary>
        /// 影院编码
        /// </summary>
        [XmlElement]
        public string CinemaCode { get; set; }

        /// <summary>
        /// 影院名称
        /// </summary>
        [XmlElement]
        public string CinemaName { get; set; }

        /// <summary>
        /// 影院地址
        /// </summary>
        [XmlElement]
        public string Address { get; set; }

        /// <summary>
        /// 影厅数量
        /// </summary>
        [XmlElement]
        public int ScreenCount { get; set; }

        /// <summary>
        /// 影厅信息
        /// </summary>
        [XmlElement]
        public CxQueryCinemaInfoResultScreens Screens { get; set; }
    }

    public class CxQueryCinemaInfoResultScreens
    {
        /// <summary>
        /// 影厅列表
        /// </summary>
        [XmlElement]
        public List<CxQueryCinemaInfoResultScreenVO> ScreenVO { get; set; }
    }

    public class CxQueryCinemaInfoResultScreenVO
    {
        /// <summary>
        /// 影厅编码
        /// </summary>
        [XmlElement]
        public string ScreenCode { get; set; }

        /// <summary>
        /// 影厅名称
        /// </summary>
        [XmlElement]
        public string ScreenName { get; set; }

        /// <summary>
        /// 座位数量
        /// </summary>
        [XmlElement]
        public int SeatCount { get; set; }

        /// <summary>
        /// 影厅类型
        /// </summary>
        [XmlElement]
        public string Type { get; set; }
    }
}
