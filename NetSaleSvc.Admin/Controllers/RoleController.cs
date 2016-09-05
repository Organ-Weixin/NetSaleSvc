using NetSaleSvc.Admin.Models;
using NetSaleSvc.Admin.Models.Role;
using NetSaleSvc.Admin.Utils;
using NetSaleSvc.Entity.Enum;
using NetSaleSvc.Entity.Models;
using NetSaleSvc.Service;
using NetSaleSvc.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace NetSaleSvc.Admin.Controllers
{
    public class RoleController : RootExraController
    {
        private RoleService _roleService;

        #region ctor
        public RoleController()
        {
            _roleService = new RoleService();
        }
        #endregion

        /// <summary>
        /// 角色管理首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 角色列表
        /// </summary>
        /// <param name="pageModel"></param>
        /// <returns></returns>
        public async Task<ActionResult> List(DynatablePageModel<DynatablePageQueryModel> pageModel)
        {
            var roles = await _roleService.GetRolesByUserIdAsync(CurrentUser.Id,
                 pageModel.Offset,
                 pageModel.PerPage,
                 pageModel.Query.Search);

            return DynatableResult(roles.ToDynatableModel(
                roles.TotalCount,
                pageModel.Offset,
                x => x.ToDynatableItem()));
        }

        /// <summary>
        /// 添加角色
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            CreateOrUpdateRoleViewModel model = new CreateOrUpdateRoleViewModel();

            PreparyCreateOrEditViewData();

            return CreateOrUpdate(model);
        }

        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> Update(int id)
        {
            var role = await _roleService.GetAsync(id);
            if (role == null)
            {
                return HttpBadRequest();
            }

            CreateOrUpdateRoleViewModel model = new CreateOrUpdateRoleViewModel();

            model.MapFrom(role);

            PreparyCreateOrEditViewData();

            return CreateOrUpdate(model);
        }

        /// <summary>
        /// 添加或修改角色
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult CreateOrUpdate(CreateOrUpdateRoleViewModel model)
        {
            return View(nameof(CreateOrUpdate), model);
        }

        /// <summary>
        /// 添加或修改角色
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> _CreateOrUpdate(CreateOrUpdateRoleViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errorMessages = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage);
                return ErrorObject(string.Join("/n", errorMessages));
            }

            RoleEntity role = new RoleEntity();
            if (model.Id > 0)
            {
                role = await _roleService.GetAsync(model.Id);
            }

            role.MapFrom(model);

            if (role.Id == 0)
            {
                role.Type = RoleTypeEnum.Customized;
                role.CreateUserId = CurrentUser.Id;
                role.Created = DateTime.Now;
                await _roleService.InsertAsync(role);
            }
            else
            {
                role.Updated = DateTime.Now;
                await _roleService.UpdateAsync(role);
            }

            return RedirectObject(Url.Action(nameof(Index)));
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> Delete(int id)
        {
            var role = await _roleService.GetAsync(id);

            if (role != null && role.Type == RoleTypeEnum.Customized)
            {
                role.Deleted = true;
                role.Updated = DateTime.Now;
                await _roleService.UpdateAsync(role);
            }

            return Object();
        }

        /// <summary>
        /// 添加或修改角色时，权限选择下拉框数据
        /// </summary>
        /// <returns></returns>
        private void PreparyCreateOrEditViewData()
        {
            IEnumerable<SelectListItem> permissionList;

            if (CurrentRole.Type == RoleTypeEnum.SystemAdmin)
            {
                permissionList = EnumUtil.GetSelectList<SystemPermissionEnum>();
            }
            else
            {
                try
                {
                    permissionList = CurrentRole.Permissions?.Split(',')
                        .Select(x => short.Parse(x).CastToEnum<SystemPermissionEnum>()).ToEnumSelectList();
                }
                catch
                {
                    permissionList = new List<SelectListItem>();
                }
            }
            ViewBag.Permissions_dd = permissionList;
        }
    }
}