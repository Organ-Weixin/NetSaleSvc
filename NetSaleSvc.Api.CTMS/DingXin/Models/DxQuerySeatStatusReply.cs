using System.Collections.Generic;

namespace NetSaleSvc.Api.CTMS.DingXin.Models
{
    public class DxQuerySeatStatusReply
    {
        public DxQuerySeatStatusReplyRes res { get; set; }
    }

    public class DxQuerySeatStatusReplyRes : DxBaseReplyRes
    {
        /// <summary>
        /// 座位列表
        /// </summary>
        public List<DxQuerySeatStatusReplySeat> data { get; set; }
    }

    public class DxQuerySeatStatusReplySeat
    {
        /// <summary>
        /// 座位横坐标
        /// </summary>
        public int x { get; set; }

        /// <summary>
        /// 座位纵坐标
        /// </summary>
        public int y { get; set; }

        /// <summary>
        /// 座位排号
        /// </summary>
        public string rowValue { get; set; }

        /// <summary>
        /// 座位列号
        /// </summary>
        public string columnValue { get; set; }

        /// <summary>
        /// 影院座位id
        /// </summary>
        public string cineSeatId { get; set; }

        /// <summary>
        /// 座位状态(可购买 : ok, 已锁定 : locked,已预订: booked, 已出售 : selled, 不可用: repair)
        /// </summary>
        public string seatStatus { get; set; }

        /// <summary>
        /// 座位类型（road：过道，danren：单人，shuangren：双人，baoliu：保留座，canji：残疾人座，vip：VIP会员座，zhendong：震动座）
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// 情侣座标识
        /// </summary>
        public string pairValue { get; set; }
    }
}
