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
    public class RoomFeaturesController : BaseController
    {
        private readonly IRoomsService roomsService;
        private readonly IUoWData uoWData;
        public RoomFeaturesController()
        {
            this.uoWData = new UoWData();
            this.roomsService = new RoomsService(this.uoWData);
        }


        public ActionResult Index()
        {
            IEnumerable<RoomFeatureViewModel> model = this.roomsService.GetRoomFeatures(true);
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateRoomFeatureInputModel featureInput)
        {
            if (ModelState.IsValid)
            {
                int result = this.roomsService.CreateRoomFeature(featureInput);
                if (result > 0)
                {
                    TempData["message"] = "Успешно добавихте ново удобство!";
                    TempData["messageType"] = "success";
                    return RedirectToAction("Index");
                }
            }

            TempData["message"] = "Невалидни данни за удобството!<br/> Моля попълнете <strong>всички</strong> задължителни полета!";
            TempData["messageType"] = "danger";
            return View(featureInput);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            CreateRoomFeatureInputModel model = this.roomsService.GetRoomFeatureInputModelById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(int id, CreateRoomFeatureInputModel roomFeature)
        {
            if (ModelState.IsValid)
            {
                bool result = this.roomsService.UpdateRoomFeature(id, roomFeature);

                if (result == true)
                {
                    TempData["message"] = "Редактирахте успешно удобството!";
                    TempData["messageType"] = "success";
                    return RedirectToAction("Index");
                }
                else
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            }

            TempData["message"] = "Невалидни данни за удобството!<br/> Моля попълнете <strong>всички</strong> полета в червено!";
            TempData["messageType"] = "danger";
            return View(roomFeature);
        }

        public ActionResult Delete(int id)
        {

            bool isSuccessfull = this.roomsService.DeleteRoomFeature(id);
            if (isSuccessfull)
            {
                TempData["message"] = "Успешно изтрихте удобството!";
                TempData["messageType"] = "success";
                return RedirectToAction("Index");
            }
            else
            {
                return HttpNotFound();
            }
        }
    }
}