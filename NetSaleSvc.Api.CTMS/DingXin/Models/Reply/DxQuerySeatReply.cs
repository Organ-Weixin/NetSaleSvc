using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace NetSaleSvc.Api.CTMS.DingXin.Models
{
    [XmlRoot("root")]
    public class DxQuerySeatReply:DxBaseReply
    {
        [XmlElement]
        public DxQuerySeatReplydata data { get; set; }
    }
    public class DxQuerySeatReplydata
    {
        [XmlElement]
        public List<DxQuerySeatReplyItem> item { get; set; }
    }
    public class DxQuerySeatReplyItem
    {
        /// <summary>
        /// 影院座位编号
        /// </summary>
        [XmlElement]
        public string cineSeatId { get; set; }
        /// <summary>
        /// 影院Id
        /// </summary>
        [XmlElement]
        public string cinemaId { get; set; }
        /// <summary>
        /// 座位横座标
        /// </summary>
        [XmlElement]
        public int xCoord { get; set; }
        /// <summary>
        /// 座位纵座标
        /// </summary>
        [XmlElement]
        public int yCoord { get; set; }
        /// <summary>
        /// 情侣座标示
        /// </summary>
        [XmlElement]
        public string loveseats { get; set; }
        /// <summary>
        /// 座位排号 rowValue=0,columnValue =0表示走廊或过道。
        /// </summary>
        [XmlElement]
        public string row { get; set; }
        /// <summary>
        /// 座位列号
        /// </summary>
        [XmlElement]
        public string column { get; set; }
        /// <summary>
        /// 座位状态 ok:正常 repair:维修中
        /// </summary>
        [XmlElement]
        public string status { get; set; }
        /// <summary>
        /// 座位类型 成人: chengren,情侣: shuangren, 单人: danren, 贵宾: vip
        /// </summary>
        [XmlElement]
        public string type { get; set; }
    }
}
