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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Role/Index.cshtml")]
    public partial class _Views_Role_Index_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Views_Role_Index_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 2 "..\..\Views\Role\Index.cshtml"
  
    ViewBag.System = "active";
    ViewBag.Role = "active";
    ViewBag.Title = "角色管理";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<!-- Content Header (Page header) -->\r\n<section");

WriteLiteral(" class=\"content-header\"");

WriteLiteral(">\r\n    <h1>\r\n        角色管理\r\n        <small>管理系统角色并分配权限</small>\r\n    </h1>\r\n    <ol" +
"");

WriteLiteral(" class=\"breadcrumb\"");

WriteLiteral(">\r\n        <li><a");

WriteLiteral(" href=\"javascript:;\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-cog\"");

WriteLiteral("></i> 系统管理</a></li>\r\n        <li");

WriteLiteral(" class=\"active\"");

WriteLiteral(">角色管理</li>\r\n    </ol>\r\n</section>\r\n\r\n<!-- Main content -->\r\n<section");

WriteLiteral(" class=\"content\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"col-md-12\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"dataTables_wrapper table-responsive no-padding\"");

WriteLiteral(">\r\n                <table");

WriteLiteral(" id=\"DataTable\"");

WriteLiteral(" class=\"table table-bordered-edge table-hover dataTable\"");

WriteLiteral("\r\n                       data-toggle=\"dynatable-paged\"");

WriteLiteral("\r\n                       data-url=\"");

            
            #line 27 "..\..\Views\Role\Index.cshtml"
                            Write(Url.Action(MvcNames.Role.List));

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteLiteral("\r\n                       data-row-template=\"role-row-template\"");

WriteLiteral(">\r\n                    <thead>\r\n                        <tr>\r\n                   " +
"         <th");

WriteLiteral(" data-dynatable-no-sort=\"true\"");

WriteLiteral(">#</th>\r\n                            <th");

WriteLiteral(" data-dynatable-no-sort=\"true\"");

WriteLiteral(">角色名</th>\r\n                            <th");

WriteLiteral(" data-dynatable-no-sort=\"true\"");

WriteLiteral(">角色描述</th>\r\n                            <th");

WriteLiteral(" data-dynatable-no-sort=\"true\"");

WriteLiteral(">创建时间</th>\r\n                            <th");

WriteLiteral(" data-dynatable-no-sort=\"true\"");

WriteLiteral(" width=\"180px\"");

WriteLiteral(">操作</th>\r\n                        </tr>\r\n                    </thead>\r\n          " +
"          <tbody></tbody>\r\n                </table>\r\n                <div");

WriteLiteral(" class=\"dynatable-custom-filter\"");

WriteLiteral(">\r\n                    <div>\r\n\r\n                    </div>\r\n                </div" +
">\r\n                <div");

WriteLiteral(" class=\"dynatable-operation\"");

WriteLiteral(">\r\n                    <a");

WriteLiteral(" class=\"btn btn-success btn-sm\"");

WriteAttribute("href", Tuple.Create(" href=\"", 1669), Tuple.Create("\"", 1709)
            
            #line 46 "..\..\Views\Role\Index.cshtml"
, Tuple.Create(Tuple.Create("", 1676), Tuple.Create<System.Object, System.Int32>(Url.Action(MvcNames.Role.Create)
            
            #line default
            #line hidden
, 1676), false)
);

WriteLiteral(">\r\n                        <i");

WriteLiteral(" class=\"fa fa-plus\"");

WriteLiteral("></i>\r\n                        新建角色\r\n                    </a>\r\n                </" +
"div>\r\n            </div>\r\n\r\n            <script");

WriteLiteral(" type=\"text/x-handlebars-template\"");

WriteLiteral(" id=\"role-row-template\"");

WriteLiteral(@">
                <tr>
                    <td style=""text-align: left;"">{{row}}</td>
                    <td style=""text-align: left; vertical-align: top;"">
                        {{name}}
                    </td>
                    <td style=""text-align: left;"">{{description}}</td>
                    <td>
                        {{created}}
                    </td>
                    <td style=""text-align: left;"">
                        {{#if canedit}}
                        <a href=""");

            
            #line 65 "..\..\Views\Role\Index.cshtml"
                            Write(Url.Action(MvcNames.Role.Update));

            
            #line default
            #line hidden
WriteLiteral("/{{id}}\">编辑</a>\r\n                        {{/if}}\r\n                        \r\n     " +
"                   {{#if candelete}}\r\n                        |\r\n               " +
"         <a href=\"javascript:void(0)\"\r\n                           data-href=\"");

            
            #line 71 "..\..\Views\Role\Index.cshtml"
                                 Write(Url.Action(MvcNames.Role.Delete));

            
            #line default
            #line hidden
WriteLiteral(@"/{{id}}"" data-toggle=""popover""
                           data-ajaxsuccess=""App.onOperationSuccessWithinPagedList""
                           data-message=""确认删除?"" data-type=""confirm"" data-placement=""left"" 
                           data-content-template=""#delete-confirm-template"">删除
                        </a>
                        {{/if}}
                    </td>
                </tr>
            </script>

        </div>
    </div>
</section>");

        }
    }
}
#pragma warning restore 1591
