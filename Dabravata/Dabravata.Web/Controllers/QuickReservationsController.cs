using Dabravata.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dabravata.Web.Controllers
{
    public class QuickReservationsController : Controller
    {
        private readonly IUoWData data;
        public QuickReservationsController()
        {
            this.data = new UoWData();
        }

        public JsonResult GetInitialRoomCategories()
        {
            var roomCategories = this.data.RoomCategories
                .All()
                .OrderBy(x => x.DisplayOrder)
                .Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }).ToList();


            return Json(new SelectList(roomCategories, "Value", "Text"));
        }

        public JsonResult GetInitialRooms()
        {
            var rooms = this.data.Rooms
                .All()
                .OrderBy(x => x.DisplayOrder)
                .AsEnumerable()
                .Select(x => new SelectListItem
                {
                    Text = string.Format("{0}: {1}", x.RoomNumber, x.Name),
                    Value = x.Id.ToString()
                }).ToList();


            return Json(new SelectList(rooms, "Value", "Text"));
        }



        public JsonResult GetRoomsFromSelectedCategory(string id)
        {
            var categoryId = int.Parse(id);
            var subcategories = this.data.Rooms
                .All()
                .OrderBy(x => x.DisplayOrder)
                .Where(x => x.RoomCategoryId == categoryId)
                .AsEnumerable()
                .Select(x => new SelectListItem
                {
                    Text = string.Format("{0}: {1}", x.RoomNumber, x.Name),
                    Value = x.Id.ToString()
                }).ToList();


            return Json(new SelectList(subcategories, "Value", "Text"));
        }
    }
}