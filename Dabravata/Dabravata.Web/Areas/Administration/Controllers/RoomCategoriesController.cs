﻿using Dabravata.Data;
using Dabravata.Data.Service;
using Dabravata.Models.InputModels;
using Dabravata.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Dabravata.Web.Areas.Administration.Controllers
{
    public class RoomCategoriesController : BaseController
    {
        private readonly IRoomsService roomsService;
        private readonly IUoWData uoWData;
        public RoomCategoriesController()
        {
            this.uoWData = new UoWData();
            this.roomsService = new RoomsService(this.uoWData);
        }

        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<RoomCategoryViewModel> model = this.roomsService.GetRoomCategories(true);
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateRoomCategoryInputModel categoryInput)
        {
            if (ModelState.IsValid)
            {
                int result = this.roomsService.CreateRoomCategory(categoryInput);
                if (result > 0)
                {
                    TempData["message"] = "Успешно добавихте нова категория!";
                    TempData["messageType"] = "success";
                    return RedirectToAction("Index");
                }
            }

            TempData["message"] = "Невалидни данни за категорията!<br/> Моля попълнете <strong>всички</strong> задължителни полета!";
            TempData["messageType"] = "danger";
            return View(categoryInput);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            CreateRoomCategoryInputModel model = this.roomsService.GetRoomCategoryInputModelById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(int id, CreateRoomCategoryInputModel roomCategory)
        {
            if (ModelState.IsValid)
            {
                bool result = this.roomsService.UpdateRoomCategory(id, roomCategory);

                if (result == true)
                {
                    TempData["message"] = "Редактирахте успешно категорията!";
                    TempData["messageType"] = "success";
                    return RedirectToAction("Index");
                }
                else
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            }

            TempData["message"] = "Невалидни данни за категорията!<br/> Моля попълнете <strong>всички</strong> полета в червено!";
            TempData["messageType"] = "danger";
            return View(roomCategory);
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

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
