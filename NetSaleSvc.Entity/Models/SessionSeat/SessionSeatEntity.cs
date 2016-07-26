using NetSaleSvc.Entity.Enum;

namespace NetSaleSvc.Entity.Models
{
    /// <summary>
    /// 排期
    /// </summary>
    public class SessionSeatEntity
    {
        /// <summary>
        /// 座位编码
        /// </summary>
        public string SeatCode { get; set; }

        /// <summary>
        /// 座位行号
        /// </summary>
        public string RowNum { get; set; }

        /// <summary>
        /// 座位列号
        /// </summary>
        public string ColumnNum { get; set; }

        /// <summary>
        /// 座位售出状态
        /// </summary>
        public SessionSeatStatusEnum Status { get; set; }
    }
}
