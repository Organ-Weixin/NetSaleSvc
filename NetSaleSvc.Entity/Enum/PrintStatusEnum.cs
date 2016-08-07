using System.Xml.Serialization;

namespace NetSaleSvc.Entity.Enum
{
    public enum PrintStatusEnum : byte
    {
        /// <summary>
        /// 未出票
        /// </summary>
        [XmlEnum("No")]
        No = 0,

        /// <summary>
        /// 已出票
        /// </summary>
        [XmlEnum("Yes")]
        Yes = 1
    }
}
