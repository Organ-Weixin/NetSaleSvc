using NetSaleSvc.Entity.Models;
using System.Collections.Generic;

namespace NetSaleSvc.Api.CTMS.Models
{
    public class CTMSQueryFilmReply : CTMSBaseReply
    {
        /// <summary>
        /// 影片列表
        /// </summary>
        public IEnumerable<FilmInfoEntity> films { get; set; }
    }
}
