using Dabravata.Data;
using Dabravata.Data.Service;
using Dabravata.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dabravata.Web.Areas.Administration.Controllers
{
    public class PagesController : BaseController
    {
        private readonly IPagesService pagesService;
        private readonly IUoWData data;

        public PagesController()
        {
            this.data = new UoWData();
            this.pagesService = new PagesService(data);
        }

        public ActionResult Index()
        {
            IEnumerable<PageViewModel> model = this.pagesService.GetPages();
            return View(model);
        }
    }
}
