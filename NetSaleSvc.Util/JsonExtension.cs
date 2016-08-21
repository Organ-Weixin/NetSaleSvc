using Newtonsoft.Json;

namespace NetSaleSvc.Util
{
    public static class JsonExtension
    {
        /// <summary>
        /// 将json字符串反序列化为实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T JsonDeserialize<T>(this string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
