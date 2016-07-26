using NetSaleSvc.Entity.Enum;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace NetSaleSvc.Api.Models
{
    /// <summary>
    /// QueryCinemaList接口返回实体
    /// </summary>
    public class QueryCinemaListReply : BaseReply
    {
        #region ctor
        public QueryCinemaListReply() : base()
        {
            Id = ID_QueryCinemaListReply;
        }
        #endregion

        /// <summary>
        /// Cinemas
        /// </summary>
        [XmlElement]
        public QueryCinemaListReplyCinemas Cinemas { get; set; }
    }

    /// <summary>
    /// Cinemas节点
    /// </summary>
    public class QueryCinemaListReplyCinemas
    {
        /// <summary>
        /// 影院数量
        /// </summary>
        [XmlAttribute]
        public string CinemaCount { get; set; }

        /// <summary>
        /// 影院列表
        /// </summary>
        [XmlElement]
        public List<QueryCinemaListReplyCinema> Cinema { get; set; }
    }

    /// <summary>
    /// 影院信息
    /// </summary>
    public class QueryCinemaListReplyCinema
    {
        /// <summary>
        /// 影院编码
        /// </summary>
        [XmlElement]
        public string Code { get; set; }

        /// <summary>
        /// 影院名称
        /// </summary>
        [XmlElement]
        public string Name { get; set; }

        /// <summary>
        /// 影院类型
        /// </summary>
        [XmlElement]
        public CinemaTypeEnum Type { get; set; }

        /// <summary>
        /// 影院地址
        /// </summary>
        [XmlElement]
        public string Address { get; set; }
    }
}