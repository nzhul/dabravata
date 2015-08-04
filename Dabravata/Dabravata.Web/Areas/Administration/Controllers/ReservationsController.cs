using Dabravata.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dabravata.Web.Areas.Administration.Controllers
{
    public class ReservationsController : Controller
    {
        public ActionResult Index()
        {
            AllReservationsViewModel model = new AllReservationsViewModel();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}