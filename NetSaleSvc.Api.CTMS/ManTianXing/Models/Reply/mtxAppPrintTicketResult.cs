using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NetSaleSvc.Api.CTMS.ManTianXing.Models
{
    [XmlRoot("AppPrintTicketResult")]
    public class mtxAppPrintTicketResult : mtxBaseReply
    {
        /// <summary>
        /// 返回结果号描述
        /// </summary>
        [XmlElement]
        public string ResultDesc { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        [XmlElement]
        public string OrderNo { get; set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        [XmlElement]
        public string OrderStatus { get; set; }

        /// <summary>
        /// 订单日期
        /// </summary>
        [XmlElement]
        public string OrderDate { get; set; }

        /// <summary>
        /// 订单时间
        /// </summary>
        [XmlElement]
        public string OrderTime { get; set; }

        /// <summary>
        /// 排期日期
        /// </summary>
        [XmlElement]
        public string FeatureDate { get; set; }

        /// <summary>
        /// 排期时间
        /// </summary>
        [XmlElement]
        public string FeatureTime { get; set; }

        /// <summary>
        /// 影片名称
        /// </summary>
        [XmlElement]
        public string FilmName { get; set; }

        /// <summary>
        /// 影厅名
        /// </summary>
        [XmlElement]
        public string HallName { get; set; }

        /// <summary>
        /// 打印类型0：未打印 1：已打印
        /// </summary>
        [XmlElement]
        public string PrintType { get; set; }

        /// <summary>
        /// 票类
        /// </summary>
        [XmlElement]
        public string TicketKindName { get; set; }

        /// <summary>
        /// 影院编码
        /// </summary>
        [XmlElement]
        public string PlaceNo { get; set; }

        /// <summary>
        /// 影院名称
        /// </summary>
        [XmlElement]
        public string PlaceName { get; set; }

        /// <summary>
        /// 影票座位信息
        /// </summary>
        [XmlElement]
        public mtxAppPrintTicketResultSeatInfos SeatInfos { get; set; }
    }

    public class mtxAppPrintTicketResultSeatInfos
    {
        /// <summary>
        /// 影票座位列表
        /// </summary>
        [XmlElement]
        public List<mtxAppPrintTicketResultSeatInfo> SeatInfo { get; set; }
    }

    public class mtxAppPrintTicketResultSeatInfo
    {
        /// <summary>
        /// 合作券名称
        /// </summary>
        [XmlElement]
        public string CpnName { get; set; }

        /// <summary>
        /// 结算价
        /// </summary>
        [XmlElement]
        public string StPrice { get; set; }

        /// <summary>
        /// 手续费
        /// </summary>
        [XmlElement]
        public string PayPrice { get; set; }

        /// <summary>
        /// 座位列
        /// </summary>
        [XmlElement]
        public string SeatCol { get; set; }

        /// <summary>
        /// 座位行
        /// </summary>
        [XmlElement]
        public string SeatRow { get; set; }

        /// <summary>
        /// 座区名
        /// </summary>
        [XmlElement]
        public string SeatPieceName { get; set; }

        /// <summary>
        /// 电影票信息码
        /// </summary>
        [XmlElement]
        public string TicketNo { get; set; }

        /// <summary>
        /// 电影票编码
        /// </summary>
        [XmlElement]
        public string TicketNo2 { get; set; }
    }
}
