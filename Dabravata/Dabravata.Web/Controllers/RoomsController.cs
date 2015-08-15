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
    public class RoomsController : BaseController
    {
        private readonly IRoomsService roomsService;
        private readonly IUoWData data;


        public RoomsController()
        {
            this.data = new UoWData();
            this.roomsService = new RoomsService(this.data);
        }

        [HttpGet]
        public ActionResult Index(int? categoryId)
        {
            IEnumerable<RoomViewModel> model = new List<RoomViewModel>();
            model = this.roomsService.GetRooms(categoryId);

            return View(model);
        }


        [HttpGet]
        public ActionResult Details(int id)
        {
            RoomViewModel model = this.roomsService.GetRoomById(id);
            return View(model);
        }
    }
}