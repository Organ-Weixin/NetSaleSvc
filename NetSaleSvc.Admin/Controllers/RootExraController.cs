using System.Web.Mvc;
using NetSaleSvc.Admin.Attributes.Authorize;
using NetSaleSvc.Entity.Models;
using System.Collections.Generic;
using System.Linq;
using NetSaleSvc.Entity.Enum;
using NetSaleSvc.Util;

namespace NetSaleSvc.Admin.Controllers
{
    /// <summary>
    /// 后台中所有页面控制器的基类
    /// </summary>
    [AdminAuthorize]
    public class RootExraController : RootBaseController
    {
        #region protected Property
        /// <summary>
        /// 当前用户
        /// </summary>
        protected SystemUserEntity CurrentUser
        {
            get
            {
                return ViewBag.SysUser;
            }
        }

        /// <summary>
        /// 当前用户所属角色
        /// </summary>
        protected RoleEntity CurrentRole
        {
            get
            {
                return ViewBag.Role;
            }
        }

        /// <summary>
        /// 当前用户拥有的权限
        /// </summary>
        protected List<SystemPermissionEnum> CurrentPermissions
        {
            get
            {
                try
                {
                    return CurrentRole.Permissions.Split(',').Select(x => short.Parse(x).CastToEnum<SystemPermissionEnum>()).ToList();
                }
                catch
                {
                    return new List<SystemPermissionEnum>();
                }
            }
        }
        #endregion

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ViewBag.SysUserName = string.IsNullOrEmpty(CurrentUser.RealName) ? CurrentUser.Username : CurrentUser.RealName;
            ViewBag.CurrentPermissions = CurrentPermissions;
            ViewBag.IsAdmin = CurrentRole == null ? false : CurrentRole.Type == RoleTypeEnum.SystemAdmin;

            base.OnActionExecuting(filterContext);
        }
    }
}