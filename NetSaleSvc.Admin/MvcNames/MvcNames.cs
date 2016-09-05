using NetSaleSvc.Admin.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetSaleSvc.Admin
{
    public static class MvcNames
    {
        /// <summary>
        /// 登陆页
        /// </summary>
        public static class Login
        {
            public static string Name { get { return nameof(Login); } }
            public static string Index { get { return nameof(LoginController.Index); } }
            public static string LogOut { get { return nameof(LoginController.LogOut); } }
        }

        /// <summary>
        /// 首页
        /// </summary>
        public static class Home
        {
            public static string Name { get { return nameof(Home); } }
            public static string Index { get { return nameof(HomeController.Index); } }
        }

        /// <summary>
        /// 用户
        /// </summary>
        public static class User
        {
            public static string Name { get { return nameof(User); } }
            public static string Index { get { return nameof(UserController.Index); } }
            public static string List { get { return nameof(UserController.List); } }
            public static string Create { get { return nameof(UserController.Create); } }
            public static string Update { get { return nameof(UserController.Update); } }
            public static string Delete { get { return nameof(UserController.Delete); } }
            public static string ModifyPassword { get { return nameof(UserController.ModifyPassword); } }
            public static string ChangePassword { get { return nameof(UserController.ChangePassword); } }
        }

        /// <summary>
        /// 角色
        /// </summary>
        public static class Role
        {
            public static string Name { get { return nameof(Role); } }
            public static string Index { get { return nameof(RoleController.Index); } }
            public static string List { get { return nameof(RoleController.List); } }
            public static string Create { get { return nameof(RoleController.Create); } }
            public static string Update { get { return nameof(RoleController.Update); } }
            public static string Delete { get { return nameof(RoleController.Delete); } }
            public static string _CreateOrUpdate { get { return nameof(RoleController._CreateOrUpdate); } }
        }

        /// <summary>
        /// 订单
        /// </summary>
        public static class Order
        {
            public static string Name { get { return nameof(Order); } }
            public static string Index { get { return nameof(OrderController.Index); } }
        }
    }
}