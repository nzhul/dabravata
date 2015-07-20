using Dabravata.Data;
using Dabravata.Data.Service;
using Dabravata.Models.InputModels;
using Dabravata.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dabravata.Web.Areas.Administration.Controllers
{
    public class RoomCategoriesController : Controller
    {
        private readonly IRoomsService roomsService;
        private readonly IUoWData uoWData;
        public RoomCategoriesController()
        {
            this.uoWData = new UoWData();
            this.roomsService = new RoomsService(this.uoWData);
        }

        // GET: Administration/RoomCategories
        public ActionResult Index()
        {
            IEnumerable<RoomCategoryViewModel> model = this.roomsService.GetRoomCategories(true);
            return View(model);
        }

        // GET: Administration/RoomCategories/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Administration/RoomCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administration/RoomCategories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateRoomCategoryInputModel categoryInput)
        {
            if (ModelState.IsValid)
            {

            }

            //room.Categories = GetCategories();
            TempData["message"] = "Невалидни данни за категорията!<br/> Моля попълнете <strong>всички</strong> задължителни полета!";
            TempData["messageType"] = "danger";
            return View(categoryInput);
        }

        // GET: Administration/RoomCategories/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Administration/RoomCategories/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Administration/RoomCategories/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Administration/RoomCategories/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
