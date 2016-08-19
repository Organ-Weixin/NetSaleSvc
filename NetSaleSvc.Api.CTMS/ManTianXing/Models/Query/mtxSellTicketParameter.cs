using System.Xml.Serialization;

namespace NetSaleSvc.Api.CTMS.ManTianXing.Models
{
    [XmlRoot("SellTicketParameter")]
    class mtxSellTicketParameter
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
        /// 取票密码
        /// </summary>
        [XmlElement]
        public string Printpassword { get; set; }

        /// <summary>
        /// 需要再支付的余额
        /// </summary>
        [XmlElement]
        public string Balance { get; set; }

        /// <summary>
        /// 付费类型
        /// </summary>
        [XmlElement]
        public string PayType { get; set; }

        /// <summary>
        /// 接收二唯码手机号码
        /// </summary>
        [XmlElement]
        public string RecvMobilePhone { get; set; }

        /// <summary>
        /// 接收二唯码的方式
        /// </summary>
        [XmlElement]
        public string SendType { get; set; }

        /// <summary>
        /// 支付结果(0成功1失败)
        /// </summary>
        [XmlElement]
        public string PayResult { get; set; }

        /// <summary>
        /// 是否由满天星负责扣费
        /// </summary>
        [XmlElement]
        public string IsCmtsPay { get; set; }

        /// <summary>
        /// 是否由满天星负责发送二维码
        /// </summary>
        [XmlElement]
        public string IsCmtsSendCode { get; set; }

        /// <summary>
        /// 支付手机号码
        /// </summary>
        [XmlElement]
        public string PayMobile { get; set; }

        /// <summary>
        /// 0全额支付  1预定金方式
        /// </summary>
        [XmlElement]
        public string BookSign { get; set; }

        /// <summary>
        /// 总票款+总手续费
        /// </summary>
        [XmlElement]
        public string Payed { get; set; }

        /// <summary>
        /// 满天星发送二唯码的模板编号
        /// </summary>
        [XmlElement]
        public string SendModeID { get; set; }

        /// <summary>
        /// 影院会员卡支付交易流水号
        /// </summary>
        [XmlElement]
        public string PaySeqNo { get; set; }

        /// <summary>
        /// 令牌id
        /// </summary>
        [XmlElement]
        public string TokenID { get; set; }

        /// <summary>
        /// 检验信息
        /// </summary>
        [XmlElement]
        public string VerifyInfo { get; set; }
    }
}
