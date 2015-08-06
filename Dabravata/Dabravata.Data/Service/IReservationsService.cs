using Dabravata.Models.InputModels;
using Dabravata.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dabravata.Data.Service
{
    public interface IReservationsService
    {

        IEnumerable<RoomViewModel> GetAvailableRooms();

        bool CreateReservation(CreateReservationInputModel inputModel);

        IEnumerable<ReservationViewModel> GetActiveReservations();

        IEnumerable<ReservationViewModel> GetConfirmedReservations();

        IEnumerable<ReservationViewModel> GetRequestedReservations();

        IEnumerable<ReservationViewModel> GetPassedReservations();
    }
}
