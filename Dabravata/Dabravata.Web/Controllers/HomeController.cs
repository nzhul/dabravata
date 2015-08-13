using Dabravata.Data;
using Dabravata.Data.Service;
using Dabravata.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dabravata.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUoWData data;
        private readonly IRoomsService roomsService;
        private readonly IPagesService pagesService;
        private readonly IAttractionsService attractionsService;

        public HomeController()
        {
            this.data = new UoWData();
            this.roomsService = new RoomsService(this.data);
            this.attractionsService = new AttractionsService(this.data);
            this.pagesService = new PagesService(this.data);
        }

        public ActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();
            model.Attractions = this.attractionsService.GetAttractions().Take(2);
            model.RoomFeatures = this.roomsService.GetRoomFeatures().Take(4);
            model.FeaturedRooms = this.roomsService.GetRooms().Take(3);
            int featuredCustomPageId = int.Parse(ConfigurationManager.AppSettings["FeaturedCustomPageId"]);
            model.FeaturedCustomPage = this.pagesService.GetFeaturedCustomPage(featuredCustomPageId);

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}