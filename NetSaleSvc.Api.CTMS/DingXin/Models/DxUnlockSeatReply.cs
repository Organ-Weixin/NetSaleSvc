namespace NetSaleSvc.Api.CTMS.DingXin.Models
{
    public class DxUnlockSeatReply
    {
        public DxUnlockSeatReplyRes res { get; set; }
    }

    public class DxUnlockSeatReplyRes : DxBaseReplyRes
    {
        public DxUnlockSeatReplyData data { get; set; }
    }

    public class DxUnlockSeatReplyData
    {
        /// <summary>
        /// 解锁状态（1表成功，0表失败）
        /// </summary>
        public bool unlock { get; set; }
    }
}
