using System;
using System.Threading;

namespace NetSaleSvc.Api.CTMS.ChenXing.Models
{
    class QueryInfoSyncModel
    {
        public DateTime CurrentDate { get; set; }
        public ManualResetEvent Mre { get; set; }
    }
}
