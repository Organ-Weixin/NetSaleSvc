using NetSaleSvc.Util;
using System.Xml;

namespace NetSaleSvc.Api.CTMS.ChenXing.Models
{
    public static class QueryXmlUtil
    {
        public static string ToXml<T>(T t)
        {
            return t.Serialize();
        }
    }
}
