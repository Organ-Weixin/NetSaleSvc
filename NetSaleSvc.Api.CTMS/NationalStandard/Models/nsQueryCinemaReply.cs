using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NetSaleSvc.Api.CTMS.NationalStandard.Models
{
    [XmlType("QueryCinemaReply")]
    public class nsQueryCinemaReply : nsBaseReply
    {
        [XmlElement]
        public nsQueryCinemaReplyCinema Cinema { get; set; }
    }

    /// <summary>
    /// Cinema节点
    /// </summary>
    public class nsQueryCinemaReplyCinema
    {
        /// <summary>
        /// 影院编码
        /// </summary>
        [XmlAttribute]
        public string Code { get; set; }

        /// <summary>
        /// 影院名称
        /// </summary>
        [XmlAttribute]
        public string Name { get; set; }

        /// <summary>
        /// 影院地址
        /// </summary>
        [XmlAttribute]
        public string Address { get; set; }

        /// <summary>
        /// 影院影厅数量
        /// </summary>
        [XmlAttribute]
        public string ScreenCount { get; set; }

        /// <summary>
        /// 影厅列表
        /// </summary>
        [XmlElement]
        public List<nsQueryCinemaReplyScreen> Screen { get; set; }
    }

    /// <summary>
    /// 影厅实体
    /// </summary>
    public class nsQueryCinemaReplyScreen
    {
        /// <summary>
        /// 影厅编码
        /// </summary>
        [XmlElement]
        public string Code { get; set; }

        /// <summary>
        /// 影厅名称
        /// </summary>
        [XmlElement]
        public string Name { get; set; }

        /// <summary>
        /// 影厅座位数量
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
