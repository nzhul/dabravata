using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dabravata.Models.ViewModels
{
    public class AllReservationsViewModel
    {
        public AllReservationsViewModel()
        {
            this.ConfirmedReservations = new List<ReservationViewModel>();

            this.RequestedReservations = new List<ReservationViewModel>();

            this.PassedReservations = new List<ReservationViewModel>();
        }

        public IEnumerable<ReservationViewModel> ConfirmedReservations { get; set; }

        public IEnumerable<ReservationViewModel> RequestedReservations { get; set; }

        public IEnumerable<ReservationViewModel> PassedReservations { get; set; }
    }
}
