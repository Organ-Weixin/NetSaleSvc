using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NetSaleSvc.Admin.Controllers
{
    [RoutePrefix("")]
    public class OrderController : RootExraController
    {
        [Route("Order")]
        public ActionResult Index()
        {
            return View();
        }
    }
}