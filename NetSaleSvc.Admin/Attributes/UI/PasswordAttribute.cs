using System.ComponentModel.DataAnnotations;

namespace NetSaleSvc.Admin.Attributes.UI
{
    public class PasswordAttribute : UIHintAttribute
    {
        public PasswordAttribute() : base("password")
        { }
    }
}