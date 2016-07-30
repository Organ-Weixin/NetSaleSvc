using NetSaleSvc.Entity.Enum;
using NetSaleSvc.Entity.Models;
using System.Collections.Generic;

namespace NetSaleSvc.Api.CTMS.Models
{
    public class CTMSQuerySessionSeatReply : CTMSBaseReply
    {
        /// <summary>
        /// 座位状态列表
        /// </summary>
        public IEnumerable<SessionSeatEntity> SessionSeats { get; set; }
    }
}
