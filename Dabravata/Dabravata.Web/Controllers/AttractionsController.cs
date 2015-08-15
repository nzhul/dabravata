using Dabravata.Data;
using Dabravata.Data.Service;
using Dabravata.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dabravata.Web.Controllers
{
    public class AttractionsController : BaseController
    {
        private readonly IUoWData data;
        private readonly IAttractionsService attractionsService;

        public AttractionsController()
        {
            this.data = new UoWData();
            this.attractionsService = new AttractionsService(this.data);
        }

        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<AttractionViewModel> model = new List<AttractionViewModel>();
            model = this.attractionsService.GetAttractions();
            return View(model);
        }
    }
}