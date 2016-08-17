using System.Collections.Generic;
using System.Xml.Serialization;

namespace NetSaleSvc.Api.CTMS.ChenXing.Models
{
    [XmlRoot("SubmitOrderResult")]
    public class CxSubmitOrderResult : CxBaseReply
    {
        /// <summary>
        /// 订单编码
        /// </summary>
        [XmlElement]
        public string OrderCode { get; set; }

        /// <summary>
        /// 排期编码
        /// </summary>
        [XmlElement]
        public string FeatureAppNo { get; set; }

        /// <summary>
        /// 取票序号
        /// </summary>
        [XmlElement]
        public string PrintNo { get; set; }

        /// <summary>
        /// 取票验证码
        /// </summary>
        [XmlElement]
        public string VerifyCode { get; set; }

        /// <summary>
        /// 座位信息
        /// </summary>
        [XmlElement]
        public CxSubmitOrderResultSeatInfos SeatInfos { get; set; }
    }

    public class CxSubmitOrderResultSeatInfos
    {
        /// <summary>
        /// 座位列表
        /// </summary>
        [XmlElement]
        public List<CxSubmitOrderResultSeatInfo> SeatInfo { get; set; }
    }

    public class CxSubmitOrderResultSeatInfo
    {
        /// <summary>
        /// 座位编码
        /// </summary>
        [XmlElement]
        public string SeatCode { get; set; }

        /// <summary>
        /// 电影票编码
        /// </summary>
        [XmlElement]
        public string FilmTicketCode { get; set; }
    }
}
