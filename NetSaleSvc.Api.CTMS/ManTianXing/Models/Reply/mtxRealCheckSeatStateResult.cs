using System.Collections.Generic;
using System.Xml.Serialization;

namespace NetSaleSvc.Api.CTMS.ManTianXing.Models
{
    [XmlRoot("RealCheckSeatStateResult")]
    public class mtxRealCheckSeatStateResult : mtxBaseReply
    {
        /// <summary>
        /// 订单编码
        /// </summary>
        [XmlElement]
        public string OrderNo { get; set; }

        /// <summary>
        /// 座位信息
        /// </summary>
        [XmlElement]
        public mtxRealCheckSeatStateResultSeatInfos SeatInfos { get; set; }
    }

    public class mtxRealCheckSeatStateResultSeatInfos
    {
        /// <summary>
        /// 座位列表
        /// </summary>
        [XmlElement]
        public List<mtxRealCheckSeatStateResultSeatInfo> SeatInfo { get; set; }
    }

    public class mtxRealCheckSeatStateResultSeatInfo
    {
        /// <summary>
        /// 座位编码
        /// </summary>
        [XmlElement]
        public string SeatNo { get; set; }

        /// <summary>
        /// 票价
        /// </summary>
        [XmlElement]
        public decimal TicketPrice { get; set; }

        /// <summary>
        /// 行
        /// </summary>
        [XmlElement]
        public string SeatRow { get; set; }

        /// <summary>
        /// 列
        /// </summary>
        [XmlElement]
        public string SeatCol { get; set; }

        /// <summary>
        /// 座区编号
        /// </summary>
        [XmlElement]
        public string SeatPieceNo { get; set; }
    }
}
