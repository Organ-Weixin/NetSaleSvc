using System.Collections.Generic;
using System.Xml.Serialization;

namespace NetSaleSvc.Api.CTMS.ManTianXing.Models
{
    [XmlRoot("GetCinemaPlanResult")]
    public class mtxGetCinemaPlanResult : mtxBaseReply
    {
        /// <summary>
        /// 排期信息
        /// </summary>
        [XmlElement]
        public mtxGetCinemaPlanResultCinemaPlans CinemaPlans { get; set; }
    }

    public class mtxGetCinemaPlanResultCinemaPlans
    {
        /// <summary>
        /// 排期列表
        /// </summary>
        [XmlElement]
        public List<mtxGetCinemaPlanResultCinemaPlan> CinemaPlan { get; set; }
    }

    public class mtxGetCinemaPlanResultCinemaPlan
    {
        /// <summary>
        /// 排期应用号
        /// </summary>
        [XmlElement]
        public string FeatureAppNo { get; set; }

        /// <summary>
        /// 排期号，应用于会员卡接口
        /// </summary>
        [XmlElement]
        public string FeatureNo { get; set; }

        /// <summary>
        /// 排期日期
        /// </summary>
        [XmlElement]
        public string FeatureDate { get; set; }

        /// <summary>
        /// 排期时间
        /// </summary>
        [XmlElement]
        public string FeatureTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        [XmlElement]
        public string TotalTime { get; set; }

        /// <summary>
        /// 影片编码
        /// </summary>
        [XmlElement]
        public string FilmNo { get; set; }

        /// <summary>
        /// 影片名称
        /// </summary>
        [XmlElement]
        public string FilmName { get; set; }

        /// <summary>
        /// 影厅编号
        /// </summary>
        [XmlElement]
        public string HallNo { get; set; }

        /// <summary>
        /// 影厅名称
        /// </summary>
        [XmlElement]
        public string HallName { get; set; }

        /// <summary>
        /// 影院编号
        /// </summary>
        [XmlElement]
        public string PlaceNo { get; set; }

        /// <summary>
        /// 影院名称
        /// </summary>
        [XmlElement]
        public string PlaceName { get; set; }

        /// <summary>
        /// 票价
        /// </summary>
        [XmlElement]
        public decimal AppPric { get; set; }

        /// <summary>
        /// 标准价
        /// </summary>
        [XmlElement]
        public decimal StandPric { get; set; }

        /// <summary>
        /// 保护价
        /// </summary>
        [XmlElement]
        public decimal ProtectPrice { get; set; }

        /// <summary>
        /// 可用性：0可用，1不可用，3待审核
        /// </summary>
        [XmlElement]
        public int UseSign { get; set; }

        /// <summary>
        /// 计划状态：0未售，1开售，2截止，3停售，5统计，9注销
        /// </summary>
        [XmlElement]
        public int SetClose { get; set; }

        /// <summary>
        /// 拷贝类型
        /// </summary>
        [XmlElement]
        public string CopyType { get; set; }

        /// <summary>
        /// 拷贝语言
        /// </summary>
        [XmlElement]
        public string CopyLanguage { get; set; }

        /// <summary>
        /// 剩余座位数，暂时无用
        /// </summary>
        [XmlElement]
        public int AvailableSeats { get; set; }

        /// <summary>
        /// 影厅座位数，暂时无用
        /// </summary>
        [XmlElement]
        public int HallSeats { get; set; }
    }
}
