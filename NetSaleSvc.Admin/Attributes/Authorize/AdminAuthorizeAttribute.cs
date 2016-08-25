using System;
using System.Web;
using System.Web.Mvc;

namespace NetSaleSvc.Admin.Attributes.Authorize
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class AdminAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return base.AuthorizeCore(httpContext) && false;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var employeeId = 0;
            int.TryParse(filterContext.HttpContext.User.Identity.Name, out employeeId);

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