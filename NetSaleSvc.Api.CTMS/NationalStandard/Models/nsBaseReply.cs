using System.Xml.Serialization;

namespace NetSaleSvc.Api.CTMS.NationalStandard.Models
{
    public class nsBaseReply
    {
        [XmlAttribute]
        public string Status { get; set; }

        [XmlAttribute]
        public string ErrorCode { get; set; }

        [XmlAttribute]
        public string ErrorMessage { get; set; }

        [XmlAttribute]
        public string Id { get; set; }
    }
}
