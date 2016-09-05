using System.Web.Mvc;

namespace NetSaleSvc.Admin.Models
{
    public class UpdateUserViewModel : UserBaseViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
    }
}