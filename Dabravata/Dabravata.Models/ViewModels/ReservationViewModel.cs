using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dabravata.Models.ViewModels
{
    public class ReservationViewModel
    {
        private ICollection<Room> occupiedRooms;
        public ReservationViewModel()
        {
            this.occupiedRooms = new HashSet<Room>();
        }

        public int Id { get; set; }

        public DateTime ArrivalDate { get; set; }

        public DateTime DepartureDate { get; set; }

        public bool IsConfirmed { get; set; }

        public string CustomerName { get; set; }

        public string CustomerPhone { get; set; }

        public virtual ICollection<Room> OccupiedRooms
        {
            get { return this.occupiedRooms; }
            set { this.occupiedRooms = value; }
        }
    }
}
