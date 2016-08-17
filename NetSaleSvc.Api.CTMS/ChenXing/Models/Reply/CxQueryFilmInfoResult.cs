using System.Collections.Generic;
using System.Xml.Serialization;

namespace NetSaleSvc.Api.CTMS.ChenXing.Models
{
    [XmlRoot("QueryFilmInfoResult")]
    public class CxQueryFilmInfoResult : CxBaseReply
    {
        /// <summary>
        /// 影片信息
        /// </summary>
        [XmlElement]
        public CxQueryFilmInfoResultFilmInfoVOs FilmInfoVOs { get; set; }
    }

    public class CxQueryFilmInfoResultFilmInfoVOs
    {
        /// <summary>
        /// 影片列表
        /// </summary>
        [XmlElement]
        public List<CxQueryFilmInfoResultFilmInfoVO> FilmInfoVO { get; set; }
    }

    public class CxQueryFilmInfoResultFilmInfoVO
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
        /// 发行版本
        /// </summary>
        [XmlElement]
        public string Version { get; set; }

        /// <summary>
        /// 时长
        /// </summary>
        [XmlElement]
        public string Duration { get; set; }

        /// <summary>
        /// 上映日期
        /// </summary>
        [XmlElement]
        public string PublishDate { get; set; }

        /// <summary>
        /// 发行商
        /// </summary>
        [XmlElement]
        public string Publisher { get; set; }

        /// <summary>
        /// 制作人
        /// </summary>
        [XmlElement]
        public string Producer { get; set; }

        /// <summary>
        /// 导演
        /// </summary>
        [XmlElement]
        public string Director { get; set; }

        /// <summary>
        /// 演员
        /// </summary>
        [XmlElement]
        public string Cast { get; set; }

        /// <summary>
        /// 简介
        /// </summary>
        [XmlElement]
        public string Introduction { get; set; }
    }
}
