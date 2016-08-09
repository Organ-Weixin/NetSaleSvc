using System.Collections.Generic;
using System.Xml.Serialization;

namespace NetSaleSvc.Api.Models
{
    /// <summary>
    /// 查询影院放映计划信息返回实体
    /// </summary>
    public class QuerySessionReply : BaseReply
    {
        #region ctor
        public QuerySessionReply()
        {
            Id = ID_QuerySessionReply;
        }
        #endregion

        [XmlElement]
        public QuerySessionReplySessions Sessions { get; set; }
    }

    public class QuerySessionReplySessions
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
        public List<QuerySessionReplySession> Session { get; set; }
    }

    /// <summary>
    /// 放映计划
    /// </summary>
    public class QuerySessionReplySession
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
        public QuerySessionReplyFilms Films { get;set;}

        /// <summary>
        /// 价格
        /// </summary>
        [XmlElement]
        public QuerySessionReplyPrice Price { get; set; }
    }

    public class QuerySessionReplyFilms
    {
        public QuerySessionReplyFilms()
        {
            Film = new List<QuerySessionReplyFilm>();
        }

        /// <summary>
        /// 影片列表
        /// </summary>
        [XmlElement]
        public List<QuerySessionReplyFilm> Film { get; set; }
    }

    public class QuerySessionReplyFilm
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
        public string Duration { get; set; }

        /// <summary>
        /// 影片在连场中的序号
        /// </summary>
        [XmlElement]
        public string Sequence { get; set; }

        /// <summary>
        /// 语言
        /// </summary>
        [XmlElement]
        public string Language { get; set; }
    }

    /// <summary>
    /// 价格
    /// </summary>
    public class QuerySessionReplyPrice
    {
        /// <summary>
        /// 最低价
        /// </summary>
        [XmlElement]
        public string LowestPrice { get; set; }

        /// <summary>
        /// 标准价
        /// </summary>
        [XmlElement]
        public string StandardPrice { get; set; }
    }
}
