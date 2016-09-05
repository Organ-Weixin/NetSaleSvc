using System.Web.Mvc;

namespace NetSaleSvc.Admin.Controllers
{
    public class ErrorController : Controller
    {
        [Route("ErrorDefault")]
        public ActionResult ErrorDefault()
        {
            return View();
        }

        [Route("Error404")]
        public ActionResult Error404(string aspxerrorpath)
        {
            ViewBag.ErrorPath = aspxerrorpath;
            return View();
        }

        [Route("Error500")]
        public ActionResult Error500()
        {
            return View();
        }
    }
}