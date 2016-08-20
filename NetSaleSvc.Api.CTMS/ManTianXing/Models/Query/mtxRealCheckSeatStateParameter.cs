using System.Collections.Generic;
using System.Xml.Serialization;

namespace NetSaleSvc.Api.CTMS.ManTianXing.Models
{
    [XmlRoot("RealCheckSeatStateParameter")]
    public class mtxRealCheckSeatStateParameter
    {
        /// <summary>
        /// 应用编码
        /// </summary>
        [XmlElement]
        public string AppCode { get; set; }

        /// <summary>
        /// 影院编码
        /// </summary>
        [XmlElement]
        public string CinemaId { get; set; }

        /// <summary>
        /// 排期应用号
        /// </summary>
        [XmlElement]
        public string FeatureAppNo { get; set; }

        /// <summary>
        /// 流水号
        /// </summary>
        [XmlElement]
        public string SerialNum { get; set; }

        /// <summary>
        /// 座位信息
        /// </summary>
        [XmlElement]
        public mtxRealCheckSeatStateParameterSeatInfos SeatInfos { get; set; }

        /// <summary>
        /// 付费类型
        /// </summary>
        [XmlElement]
        public string PayType { get; set; }

        /// <summary>
        /// 接收二维码手机号
        /// </summary>
        [XmlElement]
        public string RecvMobilePhone { get; set; }

        /// <summary>
        /// 令牌Id
        /// </summary>
        [XmlElement]
        public string TokenID { get; set; }

        /// <summary>
        /// 校验信息
        /// </summary>
        [XmlElement]
        public string VerifyInfo { get; set; }
    }

    public class mtxRealCheckSeatStateParameterSeatInfos
    {
        /// <summary>
        /// 座位列表
        /// </summary>
        [XmlElement]
        public List<mtxRealCheckSeatStateParameterSeatInfo> SeatInfo { get; set; }
    }

    public class mtxRealCheckSeatStateParameterSeatInfo
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
        /// 手续费
        /// </summary>
        [XmlElement]
        public decimal Handlingfee { get; set; }
    }
}
