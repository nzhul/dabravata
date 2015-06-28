using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dabravata.Models.ViewModels.Administration
{
    public class HomeViewModel
    {
        private IEnumerable<RoomViewModel> availableRooms;
        private IEnumerable<RoomViewModel> occupiedRooms;

        public HomeViewModel()
        {
            this.availableRooms = new List<RoomViewModel>();
            this.occupiedRooms = new List<RoomViewModel>();
        }


        public IEnumerable<RoomViewModel> AvailableRooms
        {
            get { return this.availableRooms; }
            set { this.availableRooms = value; }
        }

        public IEnumerable<RoomViewModel> OccupiedRooms
        {
            get { return this.occupiedRooms; }
            set { this.occupiedRooms = value; }
        }
    }
}
