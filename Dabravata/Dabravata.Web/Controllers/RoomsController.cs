﻿using Dabravata.Data;
using Dabravata.Data.Service;
using Dabravata.Models;
using Dabravata.Models.ViewModels;
using Dabravata.Web.Models;
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
            RoomDetailsViewModel model = new RoomDetailsViewModel();

            model.TheRoom = this.roomsService.GetRoomById(id);
            model.SimilarRooms = this.roomsService.GetRooms(model.TheRoom.RoomCategoryId).Where(r => r.Id != id);

            List<Image> images = model.TheRoom.Images.ToList();
            Image defaultImage = images.Where(i => i.ImagePath.Contains("no-image")).FirstOrDefault();
            images.Remove(defaultImage);
            model.TheRoom.Images = images;

            return View(model);
        }
    }
}