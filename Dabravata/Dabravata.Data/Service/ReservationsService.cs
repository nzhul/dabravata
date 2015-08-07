using Dabravata.Data.Service.Mappers;
using Dabravata.Models;
using Dabravata.Models.InputModels;
using Dabravata.Models.ViewModels;
using Itenso.TimePeriod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dabravata.Data.Service
{
    public class ReservationsService : IReservationsService
    {
        private readonly IUoWData Data;
        private readonly Mapper Mapper;

        public ReservationsService(IUoWData data)
        {
            this.Data = data;
            this.Mapper = new Mapper();
        }



        public IEnumerable<RoomViewModel> GetAvailableRooms()
        {
            return this.Data.Rooms.All().Select(this.Mapper.MapRoomViewModel);
        }


        public bool CreateReservation(CreateReservationInputModel inputModel)
        {
            Reservation newReservation = new Reservation();
            newReservation.ArrivalDate = inputModel.ArrivalDate;
            newReservation.DepartureDate = inputModel.DepartureDate;
            newReservation.RoomsCount = inputModel.RoomsCount;
            newReservation.Adults = inputModel.Adults;
            newReservation.Childs = inputModel.Childs;
            newReservation.IsConfirmed = inputModel.IsConfirmed;
            newReservation.CustomerName = inputModel.CustomerName;
            newReservation.CustomerPhone = inputModel.CustomerPhone;

            if (inputModel.SelectedRoomIds != null && inputModel.SelectedRoomIds.Count > 0)
            {
                for (int i = 0; i < inputModel.SelectedRoomIds.Count; i++)
                {
                    Room theRoom = this.Data.Rooms.Find(inputModel.SelectedRoomIds[i]);
                    newReservation.OccupiedRooms.Add(theRoom);
                }
            }

            this.Data.Reservations.Add(newReservation);
            this.Data.SaveChanges();

            return true;
        }


        public IEnumerable<ReservationViewModel> GetActiveReservations()
        {
            return this.Data.Reservations.All()
                .Where(r => r.IsConfirmed == true && (DateTime.Now > r.ArrivalDate && DateTime.Now < r.DepartureDate))
                .Select(this.Mapper.MapReservationViewModel);
        }

        public IEnumerable<ReservationViewModel> GetConfirmedReservations()
        {
            return this.Data.Reservations.All()
                .Where(r => r.IsConfirmed == true && DateTime.Now < r.ArrivalDate)
                .Select(this.Mapper.MapReservationViewModel);
        }

        public IEnumerable<ReservationViewModel> GetRequestedReservations()
        {
            return this.Data.Reservations.All()
                .Where(r => r.IsConfirmed == false)
                .Select(this.Mapper.MapReservationViewModel);
        }

        public IEnumerable<ReservationViewModel> GetPassedReservations()
        {
            return this.Data.Reservations.All()
                .Where(r => r.IsConfirmed == true && DateTime.Now > r.DepartureDate)
                .Select(this.Mapper.MapReservationViewModel);
        }


        public bool IsRoomAvailable(CreateReservationInputModel inputModel)
        {
            foreach (var roomId in inputModel.SelectedRoomIds)
            {
                Room currentSelectedRoom = this.Data.Rooms.Find(roomId);
                IEnumerable<Reservation> reservationsWithThatRoom = this.Data.Reservations.All().Where(r => r.OccupiedRooms.Select(or => or.Id).Contains(currentSelectedRoom.Id));

                if (reservationsWithThatRoom.Count() > 0)
                {
                    foreach (var reservation in reservationsWithThatRoom)
                    {
                        TimeRange inputTimeRange = new TimeRange(inputModel.ArrivalDate, inputModel.DepartureDate);
                        TimeRange dbTimeRange = new TimeRange(reservation.ArrivalDate, reservation.DepartureDate);

                        if (inputTimeRange.OverlapsWith(dbTimeRange))
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }
    }
}
