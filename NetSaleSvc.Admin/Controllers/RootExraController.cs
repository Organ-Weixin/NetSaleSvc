using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NetSaleSvc.Admin.Attributes.Authorize;

namespace NetSaleSvc.Admin.Controllers
{
    [AdminAuthorize]
    public class RootExraController : RootBaseController
    {
        
    }
}