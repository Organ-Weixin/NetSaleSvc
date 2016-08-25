using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace NetSaleSvc.Admin.Controllers
{
    [RoutePrefix("")]
    public class LoginController : RootBaseController
    {
        [Route("login")]
        [HttpGet]
        public async Task<ActionResult> Login()
        {
            return View();
        }
    }
}