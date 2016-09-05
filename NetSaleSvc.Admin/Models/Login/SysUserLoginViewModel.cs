using System.ComponentModel.DataAnnotations;

namespace NetSaleSvc.Admin.Models
{
    public class SysUserLoginViewModel
    {
        [Required(ErrorMessage = "用户名不能为空")]
        public string Username { get; set; }

        [Required(ErrorMessage = "密码不能为空")]
        public string Password { get; set; }
    }
}