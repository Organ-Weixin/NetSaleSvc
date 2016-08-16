using System;
using System.Threading;

namespace NetSaleSvc.Api.CTMS.ChenXing.Models
{
    class QueryFilmInfoSyncModel
    {
        public DateTime CurrentDate { get; set; }
        public ManualResetEvent Mre { get; set; }
    }
}
