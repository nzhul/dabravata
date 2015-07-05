using Dabravata.Data;
using Dabravata.Data.Service;
using Dabravata.Models.InputModels;
using Dabravata.Models.ViewModels;
using Dabravata.Web.Areas.Administration.Models.ViewModels;
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

        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<RoomViewModel> roomsCollection = this.roomsService.GetRooms(true, true);

            HomeViewModel homeModel = new HomeViewModel();
            homeModel.AvailableRooms = roomsCollection;
            homeModel.OccupiedRooms = roomsCollection;

            return View(homeModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            CreateRoomInputModel model = new CreateRoomInputModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateRoomInputModel room)
        {
            if (ModelState.IsValid)
            {
                int result = this.roomsService.CreateRoom(room);
            }

            room.Categories = GetCategories();
            TempData["message"] = "Невалидни данни за продукта!<br/> Моля попълнете <strong>всички</strong> полета в червено!";
            TempData["messageType"] = "danger";
            return View(room);
        }

        private IEnumerable<SelectListItem> GetCategories()
        {
            throw new NotImplementedException();
        }
    }
}