using System.Collections.Generic;

namespace NetSaleSvc.Api.CTMS.DingXin.Models
{
    public class DxQueryHallSeatsReply
    {
        public DxQueryHallSeatsReplyRes res { get; set; }
    }

    public class DxQueryHallSeatsReplyRes : DxBaseReplyRes
    {
        public List<DxQueryHallSeatsReplySeat> data { get; set; }
    }

    public class DxQueryHallSeatsReplySeat
    {
        /// <summary>
        /// 影院座位编号
        /// </summary>
        public string cineSeatId { get; set; }

        /// <summary>
        /// 影院Id
        /// </summary>
        public string cinemaId { get; set; }

        /// <summary>
        /// 座位横座标
        /// </summary>
        public int xCoord { get; set; }

        /// <summary>
        /// 座位纵座标
        /// </summary>
        public int yCoord { get; set; }

        /// <summary>
        /// 情侣座标示
        /// </summary>
        public string loveseats { get; set; }

        /// <summary>
        /// 座位排号 rowValue=0,columnValue =0表示走廊或过道。
        /// </summary>
        public string row { get; set; }

        /// <summary>
        /// 座位列号
        /// </summary>
        public string column { get; set; }

        /// <summary>
        /// 座位状态 ok:正常 repair:维修中
        /// </summary>
        public string status { get; set; }

        /// <summary>
        /// 座位类型 成人: chengren,情侣: shuangren, 单人: danren, 贵宾: vip
        /// </summary>
        public string type { get; set; }
    }
}
