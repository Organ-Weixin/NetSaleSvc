using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NetSaleSvc.Api.CTMS.NationalStandard.Models
{
    /// <summary>
    /// 查询放映计划返回实体
    /// </summary>
    public class nsQuerySessionReply : nsBaseReply
    {
        [XmlElement]
        public nsQuerySessionReplySessions Sessions { get; set; }
    }

    /// <summary>
    /// Sessions
    /// </summary>
    public class nsQuerySessionReplySessions
    {
        /// <summary>
        /// 影院编码
        /// </summary>
        [XmlAttribute]
        public string CinemaCode { get; set; }

        /// <summary>
        /// 排期列表
        /// </summary>
        [XmlElement]
        public List<nsQuerySessionReplySession> Session { get; set; }
    }

    /// <summary>
    /// 放映计划
    /// </summary>
    public class nsQuerySessionReplySession
    {
        /// <summary>
        /// 影厅编码
        /// </summary>
        [XmlAttribute]
        public string ScreenCode { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        [XmlElement]
        public string Code { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        [XmlElement]
        public string StartTime { get; set; }

        /// <summary>
        /// 连场标识，取值：Yes/No
        /// </summary>
        [XmlElement]
        public string PlaythroughFlag { get; set; }

        /// <summary>
        /// 影片列表
        /// </summary>
        [XmlElement]
        public nsQuerySessionReplyFilms Films { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        [XmlElement]
        public nsQuerySessionReplyPrice Price { get; set; }
    }

    public class nsQuerySessionReplyFilms
    {
        /// <summary>
        /// 影片列表
        /// </summary>
        [XmlElement]
        public List<nsQuerySessionReplyFilm> Film { get; set; }
    }

    public class nsQuerySessionReplyFilm
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
        /// 影片维度
        /// </summary>
        [XmlElement]
        public string Dimensional { get; set; }

        /// <summary>
        /// 影片时长
        /// </summary>
        [XmlElement]
        public int Duration { get; set; }

        /// <summary>
        /// 影片在连场中的序号
        /// </summary>
        [XmlElement]
        public int Sequence { get; set; }
    }

    /// <summary>
    /// 价格
    /// </summary>
    public class nsQuerySessionReplyPrice
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
    }
}
