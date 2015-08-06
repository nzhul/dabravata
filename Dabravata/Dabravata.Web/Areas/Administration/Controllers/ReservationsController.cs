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
    public class ReservationsController : Controller
    {
        private readonly IReservationsService reservationsService;
        private readonly IUoWData data;

        public ReservationsController()
        {
            this.data = new UoWData();
            this.reservationsService = new ReservationsService(data);
        }

        public ActionResult Index()
        {
            AllReservationsViewModel model = new AllReservationsViewModel();
            model.ActiveReservations = this.reservationsService.GetActiveReservations();
            model.ConfirmedReservations = this.reservationsService.GetConfirmedReservations();
            model.RequestedReservations = this.reservationsService.GetRequestedReservations();
            model.PassedReservations = this.reservationsService.GetPassedReservations();
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            CreateReservationInputModel model = new CreateReservationInputModel();
            model.AvailableRooms = this.reservationsService.GetAvailableRooms();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CreateReservationInputModel inputModel)
        {
            if (ModelState.IsValid)
            {
                if (inputModel.ArrivalDate > inputModel.DepartureDate)
                {
                    inputModel.AvailableRooms = this.reservationsService.GetAvailableRooms();
                    TempData["message"] = "Невалидни данни за резервацията!<br/> Датата на пристигане трябва да е преди датата на заминаване!";
                    TempData["messageType"] = "danger";
                    return View(inputModel);
                }

                bool IsCreateRoomSuccessfull = this.reservationsService.CreateReservation(inputModel);
                if (IsCreateRoomSuccessfull)
                {
                    TempData["message"] = "Резервацията беше направена успешно!";
                    TempData["messageType"] = "success";
                    return RedirectToAction("Index");
                }
            }

            inputModel.AvailableRooms = this.reservationsService.GetAvailableRooms();
            TempData["message"] = "Невалидни данни за резервацията!<br/> Моля попълнете <strong>всички</strong> задължителни полета!";
            TempData["messageType"] = "danger";
            return View(inputModel);
        }
    }
}