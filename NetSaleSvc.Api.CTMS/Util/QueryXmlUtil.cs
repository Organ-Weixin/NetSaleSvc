using NetSaleSvc.Util;

namespace NetSaleSvc.Api.CTMS.Util
{
    public static class QueryXmlUtil
    {
        public static string ToXml<T>(T t)
        {
            return t.Serialize();
        }
    }
}
