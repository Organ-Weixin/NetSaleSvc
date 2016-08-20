using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace NetSaleSvc.Api.CTMS.DingXin.Models
{
    [XmlRoot("root")]
    public class DxQueryCinemaReply:DxBaseReply
    {
        [XmlElement]
        public DxQueryCinemaReplydata data { get; set; }
    }
    public class DxQueryCinemaReplydata
    {
        [XmlElement]
        public List<DxQueryCinemaReplyItem> item { get; set; }
    }
    public class DxQueryCinemaReplyItem
    {
        /// <summary>
        /// 影厅序号
        /// </summary>
        [XmlElement]
        public string id { get; set; }
        /// <summary>
        /// 影厅名称
        /// </summary>
        [XmlElement]
        public string name { get; set; }
        /// <summary>
        /// 座位总数
        /// </summary>
        [XmlElement]
        public int seatNum { get; set; }
        /// <summary>
        /// 影厅类型，如3D影厅,IMAX影厅
        /// </summary>
        [XmlElement]
        public string type { get; set; }
        /// <summary>
        /// 声响类型
        /// </summary>
        [XmlElement]
        public string audioType { get; set;}
    }
}
