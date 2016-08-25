using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NetSaleSvc.Admin.Controllers
{
    public class HomeController : RootExraController
    {
        /// <summary>
        /// 登陆后的首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}