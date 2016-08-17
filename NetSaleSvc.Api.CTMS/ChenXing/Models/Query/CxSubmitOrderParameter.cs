using System.Collections.Generic;
using System.Xml.Serialization;

namespace NetSaleSvc.Api.CTMS.ChenXing.Models
{
    [XmlRoot("SubmitOrderParameter")]
    public class CxSubmitOrderParameter
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
        public string CinemaCode { get; set; }

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
        /// 手机号码
        /// </summary>
        [XmlElement]
        public string MobilePhone { get; set; }

        /// <summary>
        /// 座位信息
        /// </summary>
        [XmlElement]
        public CxSubmitOrderParameterSeatInfos SeatInfos { get; set; }

        //套餐忽略

        /// <summary>
        /// 是否压缩
        /// </summary>
        [XmlElement]
        public string Compress { get; set; }

        /// <summary>
        /// 校验信息
        /// </summary>
        [XmlElement]
        public string VerifyInfo { get; set; }
    }

    public class CxSubmitOrderParameterSeatInfos
    {
        /// <summary>
        /// 座位列表
        /// </summary>
        [XmlElement]
        public List<CxSubmitOrderParameterSeatInfo> SeatInfo { get; set; }
    }

    public class CxSubmitOrderParameterSeatInfo
    {
        /// <summary>
        /// 座位编码
        /// </summary>
        [XmlElement]
        public string SeatCode { get; set; }

        /// <summary>
        /// 价格（包含服务费）
        /// </summary>
        [XmlElement]
        public string Price { get; set; }
    }
}
