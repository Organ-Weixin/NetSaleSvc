using NetSaleSvc.Entity.Enum;

namespace NetSaleSvc.Api.CTMS.Models
{
    public class CTMSBaseReply
    {
        /// <summary>
        /// 返回状态
        /// </summary>
        public StatusEnum Status { get; set; }

        /// <summary>
        /// 返回错误代码
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// 返回错误信息
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}
