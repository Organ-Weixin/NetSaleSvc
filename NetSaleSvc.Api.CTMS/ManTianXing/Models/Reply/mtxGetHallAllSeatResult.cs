using System.Collections.Generic;

namespace NetSaleSvc.Api.CTMS.ManTianXing.Models
{
    public class mtxGetHallAllSeatResult : mtxBaseReply
    {
        /// <summary>
        /// 座位信息
        /// </summary>
        public List<mtxGetHallAllSeatHallSeat> hallSeats { get; set; }
    }

    public class mtxGetHallAllSeatHallSeat
    {
        /// <summary>
        /// 座位编码
        /// </summary>
        public string SeatNo { get; set; }

        /// <summary>
        /// 行号
        /// </summary>
        public string SeatRow { get; set; }

        /// <summary>
        /// 列号
        /// </summary>
        public string SeatCol { get; set; }

        /// <summary>
        /// y坐标
        /// </summary>
        public int GraphRow { get; set; }

        /// <summary>
        /// x坐标
        /// </summary>
        public int GraphCol { get; set; }

        /// <summary>
        /// 左连数
        /// </summary>
        public int leftCount { get; set; }

        /// <summary>
        /// 右连数
        /// </summary>
        public int rightCount { get; set; }

        /// <summary>
        /// 座区编号
        /// </summary>
        public string SeatPieceNo { get; set; }

        /// <summary>
        /// 座区名称
        /// </summary>
        public string seatPieceName { get; set; }
    }
}
