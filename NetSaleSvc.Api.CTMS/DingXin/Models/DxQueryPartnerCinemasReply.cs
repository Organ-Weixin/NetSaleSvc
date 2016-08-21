using System.Collections.Generic;

namespace NetSaleSvc.Api.CTMS.DingXin.Models
{
    public class DxQueryPartnerCinemasReply
    {
        public DxQueryPartnerCinemasReplyRes res { get; set; }
    }

    public class DxQueryPartnerCinemasReplyRes : DxBaseReplyRes
    {
        public List<DxQueryPartnerCinemasReplyCinema> data { get; set; }
    }

    public class DxQueryPartnerCinemasReplyCinema
    {
        /// <summary>
        /// 鼎新影院Id
        /// </summary>
        public int cinemaId { get; set; }

        /// <summary>
        /// 影院名称
        /// </summary>
        public string cinemaName { get; set; }

        /// <summary>
        /// 授权有效期限
        /// </summary>
        public string validPeriod { get; set; }

        /// <summary>
        /// 广电总局8位影院编码
        /// </summary>
        public string cinemaNumber { get; set; }
    }
}
