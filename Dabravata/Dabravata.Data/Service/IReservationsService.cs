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

        bool IsRoomAvailable(CreateReservationInputModel inputModel);

        void ToggleReservationConfirmation(int reservationId, bool isReservationConfirmed);

        bool ReservationExists(int id);

        CreateReservationInputModel GetReservationInputModelById(int id);

        List<int> GetSelectedRoomIds(int id);

        bool UpdateReservation(int id, CreateReservationInputModel inputModel);
    }
}
