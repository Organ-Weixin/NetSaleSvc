using System.Collections.Generic;
using System.Xml.Serialization;

namespace NetSaleSvc.Api.CTMS.NationalStandard.Models
{
    [XmlType("QueryFilmReply")]
    public class nsQueryFilmReply : nsBaseReply
    {
        /// <summary>
        /// 影片
        /// </summary>
        [XmlElement]
        public nsQueryFilmReplyFilms Films { get; set; }
    }

    /// <summary>
    /// Films节点
    /// </summary>
    public class nsQueryFilmReplyFilms
    {
        /// <summary>
        /// 影片数量
        /// </summary>
        [XmlAttribute]
        public int Count { get; set; }

        /// <summary>
        /// 影片列表
        /// </summary>
        [XmlElement]
        public List<nsQueryFilmReplyFilm> Film { get; set; }
    }

    public class nsQueryFilmReplyFilm
    {
        /// <summary>
        /// 影片编码
        /// </summary>
        [XmlElement]
        public string Code { get; set; }

        /// <summary>
        /// 影片名称
        /// </summary>
        [XmlElement]
        public string Name { get; set; }

        /// <summary>
        /// 发行版本
        /// </summary>
        [XmlElement]
        public string Version { get; set; }

        /// <summary>
        /// 影片时长
        /// </summary>
        [XmlElement]
        public string Duration { get; set; }

        /// <summary>
        /// 公映日期
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
