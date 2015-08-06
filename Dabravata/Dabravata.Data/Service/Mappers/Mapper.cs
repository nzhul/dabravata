using Dabravata.Models;
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

            return model;
        }
    }
}
