using Dabravata.Data;
using Dabravata.Data.Service;
using Dabravata.Models;
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
        private readonly IImagesService imagesService;
        private readonly IUoWData uoWData;
        public RoomsController()
        {
            this.uoWData = new UoWData();
            this.roomsService = new RoomsService(this.uoWData);
            this.imagesService = new ImagesService(this.uoWData);
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
            model.Categories = this.roomsService.GetCategories();
            model.AvailableRoomFeatures = this.roomsService.GetAvailableRoomFeatures();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateRoomInputModel inputModel)
        {
            if (ModelState.IsValid)
            {
                bool IsCreateRoomSuccessfull = this.roomsService.CreateRoom(inputModel);
                if (IsCreateRoomSuccessfull)
                {
                    TempData["message"] = "Стаята беше добавена успешно!";
                    TempData["messageType"] = "success";
                    return RedirectToAction("Index");
                }
            }

            inputModel.Categories = this.roomsService.GetCategories();
            TempData["message"] = "Невалидни данни за стаята!<br/> Моля попълнете <strong>всички</strong> задължителни полета!";
            TempData["messageType"] = "danger";
            return View(inputModel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            CreateRoomInputModel model = new CreateRoomInputModel();

            if (this.roomsService.RoomExists(id))
            {
                model = this.roomsService.GetRoomInputModelById(id);
                model.Categories = this.roomsService.GetCategories();
                model.AvailableRoomFeatures = this.roomsService.GetAvailableRoomFeatures();
                model.SelectedRoomFeatureIds = this.roomsService.GetSelectedRoomFeatureIds(id);
            }
            else
            {
                return HttpNotFound();
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(int id, CreateRoomInputModel inputModel)
        {
            if (ModelState.IsValid)
            {
                bool IsUpdateSuccessfull = this.roomsService.UpdateRoom(id, inputModel);
                if (IsUpdateSuccessfull)
                {
                    TempData["message"] = "Стаята беше редактирана успешно!";
                    TempData["messageType"] = "success";
                    return RedirectToAction("Index");
                }
            }

            inputModel.Categories = this.roomsService.GetCategories();
            inputModel.AvailableRoomFeatures = this.roomsService.GetAvailableRoomFeatures();
            TempData["message"] = "Невалидни данни за стаята!<br/> Моля попълнете <strong>всички</strong> задължителни полета!";
            TempData["messageType"] = "danger";
            return View(inputModel);
        }

        [HttpPost]
        public ActionResult UploadPhotos(UploadPhotoModel uploadData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    this.imagesService.UploadImages(uploadData);
                }

                TempData["message"] = "Снимката беше <strong>добавена</strong> успешно!";
                TempData["messageType"] = "success";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["message"] = "Неуспешно качване на снимка!<br/> Моля свържете се с администратор!";
                TempData["messageType"] = "danger";
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult MakePrimary(int imageId, int productId)
        {
            bool IsSuccessfull = this.imagesService.MakePrimary(imageId, productId);

            if (IsSuccessfull)
            {
                return RedirectToAction("Edit", new { id = productId });
            }
            else
            {
                return HttpNotFound();
            }
            
        }

        private IEnumerable<SelectListItem> GetCategories()
        {
            throw new NotImplementedException();
        }
    }
}