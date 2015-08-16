using Dabravata.Models;
using Dabravata.Models.InputModels;
using Dabravata.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dabravata.Data.Service.Mappers
{
    public class Mapper
    {
        public RoomViewModel MapRoomViewModel(Room room)
        {
            RoomViewModel model = new RoomViewModel();
            model.Id = room.Id;
            model.Name = room.Name;
            model.Price = room.Price;
            model.RoomNumber = room.RoomNumber;
            model.Summary = room.Summary;
            model.RoomFeature = room.RoomFeatures;
            model.PrimaryImage = room.Images.FirstOrDefault(i => i.IsPrimary);
            model.Images = room.Images;
            model.Description = room.Description;
            model.RoomCategoryId = room.RoomCategoryId;

            return model;
        }

        public ReservationViewModel MapReservationViewModel(Reservation reservation)
        {
            ReservationViewModel model = new ReservationViewModel();
            model.Id = reservation.Id;
            model.ArrivalDate = reservation.ArrivalDate;
            model.DepartureDate = reservation.DepartureDate;
            model.IsConfirmed = reservation.IsConfirmed;
            model.OccupiedRooms = reservation.OccupiedRooms;
            model.CustomerName = reservation.CustomerName;
            model.CustomerPhone = reservation.CustomerPhone;

            return model;
        }

        public CreateReservationInputModel MapReservationInputModel(Reservation dbReservation)
        {
            CreateReservationInputModel model = new CreateReservationInputModel();
            model.Id = dbReservation.Id;
            model.ArrivalDate = dbReservation.ArrivalDate;
            model.DepartureDate = dbReservation.DepartureDate;
            model.IsConfirmed = dbReservation.IsConfirmed;
            model.CustomerName = dbReservation.CustomerName;
            model.CustomerPhone = dbReservation.CustomerPhone;
            model.RoomsCount = dbReservation.RoomsCount;
            model.Adults = dbReservation.Adults;
            model.Childs = dbReservation.Childs;

            return model;
        }
    }
}
