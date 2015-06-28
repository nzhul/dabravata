using Dabravata.Data;
using Dabravata.Data.Service;
using Dabravata.Models.ViewModels;
using Dabravata.Models.ViewModels.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dabravata.Web.Areas.Administration.Controllers
{
    public class RoomsController : BaseController
    {
        private readonly IRoomsService roomsService;
        private readonly IUoWData uoWData;
        public RoomsController()
        {
            this.uoWData = new UoWData();
            this.roomsService = new RoomsService(this.uoWData);
        }

        // GET: Administration/Home
        public ActionResult Index()
        {
            IEnumerable<RoomViewModel> roomsCollection = this.roomsService.GetRooms(true, true);

            HomeViewModel homeModel = new HomeViewModel();
            homeModel.AvailableRooms = roomsCollection;
            homeModel.OccupiedRooms = roomsCollection;

            return View(homeModel);
        }
    }
}