namespace NetSaleSvc.Api.CTMS.DingXin.Models
{
    public class DxBaseReplyRes
    {
        /// <summary>
        /// 返回状态值
        /// </summary>
        public int status { get; set; }
        /// <summary>
        /// 错误描述
        /// </summary>
        public string errorMessage { get; set; }
        /// <summary>
        /// 错误代码
        /// </summary>
        public string errorCode { get; set; }
    }
}
