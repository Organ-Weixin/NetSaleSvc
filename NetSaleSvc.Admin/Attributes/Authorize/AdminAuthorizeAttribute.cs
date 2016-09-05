using NetSaleSvc.Entity.Models;
using NetSaleSvc.Service;
using System;
using System.Web;
using System.Web.Mvc;

namespace NetSaleSvc.Admin.Attributes.Authorize
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class AdminAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly SystemUserService _systemUserService = new SystemUserService();
        private readonly RoleService _roleService = new RoleService();

        private SystemUserEntity _sysUser;
        private RoleEntity _role;

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return base.AuthorizeCore(httpContext) && _sysUser != null;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var sysUserId = 0;
            if (int.TryParse(filterContext.HttpContext.User.Identity.Name, out sysUserId))
            {
                _sysUser = _systemUserService.Get(sysUserId);

                if (_sysUser != null)
                {
                    _role = _roleService.Get(_sysUser.RoleId);

                    filterContext.Controller.ViewBag.Role = _role;
                    filterContext.Controller.ViewBag.SysUser = _sysUser;
                }
            }

            base.OnAuthorization(filterContext);
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            var returnUrl = filterContext.HttpContext.Request.Url.PathAndQuery;
            filterContext.Result = new RedirectResult("~/login" +
                (!string.IsNullOrEmpty(returnUrl.TrimStart('/')) ? "?returnUrl=" + HttpUtility.UrlEncode(returnUrl) : string.Empty));
        }
    }
}