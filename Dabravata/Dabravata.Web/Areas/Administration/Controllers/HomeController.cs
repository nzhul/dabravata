using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dabravata.Web.Areas.Administration.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Administration/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}