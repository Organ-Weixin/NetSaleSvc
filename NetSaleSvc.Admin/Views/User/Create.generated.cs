﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Optimization;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    using NetSaleSvc.Admin;
    using NetSaleSvc.Admin.Models;
    using NetSaleSvc.Admin.Properties;
    using NetSaleSvc.Entity.Enum;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/User/Create.cshtml")]
    public partial class _Views_User_Create_cshtml : System.Web.Mvc.WebViewPage<CreateUserViewModel>
    {
        public _Views_User_Create_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\User\Create.cshtml"
  
    ViewBag.System = "active";
    ViewBag.User = "active";
    ViewBag.Title = "新建用户";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<!-- Content Header (Page header) -->\r\n<section");

WriteLiteral(" class=\"content-header\"");

WriteLiteral(">\r\n    <h1>\r\n        新建用户\r\n        <small>用户管理</small>\r\n    </h1>\r\n    <ol");

WriteLiteral(" class=\"breadcrumb\"");

WriteLiteral(">\r\n        <li><a");

WriteLiteral(" href=\"javascript:;\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-cog\"");

WriteLiteral("></i> 系统管理</a></li>\r\n        <li><a");

WriteAttribute("href", Tuple.Create(" href=\"", 386), Tuple.Create("\"", 425)
            
            #line 17 "..\..\Views\User\Create.cshtml"
, Tuple.Create(Tuple.Create("", 393), Tuple.Create<System.Object, System.Int32>(Url.Action(MvcNames.User.Index)
            
            #line default
            #line hidden
, 393), false)
);

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-user\"");

WriteLiteral("></i> 用户管理</a></li>\r\n        <li");

WriteLiteral(" class=\"active\"");

WriteLiteral(">新建用户</li>\r\n    </ol>\r\n</section>\r\n\r\n");

            
            #line 22 "..\..\Views\User\Create.cshtml"
 using (Ajax.BeginForm(null, null, null, new AjaxOptions
{
    HttpMethod = "POST",
    OnSuccess = "App.onOperationSuccessSimple",
    OnBegin = "App.onFormCommitBegin",
    OnComplete = "App.onFormCommitComplete"
}, new { @class = "form-horizontal" }))
{

            
            #line default
            #line hidden
WriteLiteral("    <!-- Main content -->\r\n");

WriteLiteral("    <section");

WriteLiteral(" class=\"content\"");

WriteLiteral(">\r\n        <!-- Your Page Content Here -->\r\n\r\n        <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"col-xs-12\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"box box-default\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"box-header with-border\"");

WriteLiteral(">\r\n                        <h3");

WriteLiteral(" class=\"box-title\"");

WriteLiteral(">基础信息</h3>\r\n                    </div>\r\n                    <div");

WriteLiteral(" class=\"modal-body\"");

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 41 "..\..\Views\User\Create.cshtml"
                   Write(Html.EditorFor(x => x.Username));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                        ");

            
            #line 42 "..\..\Views\User\Create.cshtml"
                   Write(Html.EditorFor(x => x.Password));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                        ");

            
            #line 43 "..\..\Views\User\Create.cshtml"
                   Write(Html.EditorFor(x => x.ConfirmPassword));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                        ");

            
            #line 44 "..\..\Views\User\Create.cshtml"
                   Write(Html.EditorFor(x => x.CinemaCode));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                        ");

            
            #line 45 "..\..\Views\User\Create.cshtml"
                   Write(Html.EditorFor(x => x.RealName));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </div>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"box box-default\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"box-header with-border\"");

WriteLiteral(">\r\n                        <h3");

WriteLiteral(" class=\"box-title\"");

WriteLiteral(">角色信息</h3>\r\n                    </div>\r\n                    <div");

WriteLiteral(" class=\"modal-body\"");

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 53 "..\..\Views\User\Create.cshtml"
                   Write(Html.EditorFor(x => x.RoleId));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </div>\r\n                </div>\r\n                <fieldset>\r" +
"\n                    <button");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" class=\"btn btn-primary col-xs-2 col-xs-offset-3\"");

WriteLiteral(">保存</button>\r\n                    <a");

WriteLiteral(" class=\"btn btn-default col-xs-2 col-xs-offset-1\"");

WriteAttribute("href", Tuple.Create(" href=\"", 2096), Tuple.Create("\"", 2135)
            
            #line 58 "..\..\Views\User\Create.cshtml"
, Tuple.Create(Tuple.Create("", 2103), Tuple.Create<System.Object, System.Int32>(Url.Action(MvcNames.User.Index)
            
            #line default
            #line hidden
, 2103), false)
);

WriteLiteral(">取消</a>\r\n                </fieldset>\r\n            </div>\r\n        </div>\r\n    </s" +
"ection>\r\n");

            
            #line 63 "..\..\Views\User\Create.cshtml"
}
            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591
