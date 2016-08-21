using System.Collections.Generic;

namespace NetSaleSvc.Api.CTMS.DingXin.Models
{
    public class DxQueryCinemaHallsReply
    {
        public DxQueryCinemaHallsReplyRes res { get; set; }
    }


    public class DxQueryCinemaHallsReplyRes : DxBaseReplyRes
    {
        public List<DxQueryCinemaHallsReplyHall> data { get; set; }
    }

    public class DxQueryCinemaHallsReplyHall
    {
        /// <summary>
        /// 影厅序号
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// 影厅名称
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 座位总数
        /// </summary>
        public int seatNum { get; set; }

        /// <summary>
        /// 影厅类型，如3D影厅,IMAX影厅
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// 声响类型
        /// </summary>
        public string audioType { get; set; }
    }
}
