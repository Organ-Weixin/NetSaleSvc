using System.Collections.Generic;
using System.Xml.Serialization;

namespace NetSaleSvc.Api.CTMS.ManTianXing.Models
{
    [XmlRoot("GetHallResult")]
    public class mtxGetHallResult : mtxBaseReply
    {
        /// <summary>
        /// 影厅信息
        /// </summary>
        [XmlElement]
        public mtxGetHallResultHalls Halls { get; set; }
    }

    public class mtxGetHallResultHalls
    {
        /// <summary>
        /// 影厅列表
        /// </summary>
        [XmlElement]
        public List<mtxGetHallResultHall> Hall { get; set; }
    }

    public class mtxGetHallResultHall
    {
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
    }
}
