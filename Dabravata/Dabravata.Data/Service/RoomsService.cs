using Dabravata.Models;
using Dabravata.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dabravata.Data.Service
{
    public class RoomsService : IRoomsService
    {
        private readonly IUoWData Data;

        public RoomsService(IUoWData data)
        {
            this.Data = data;
        }

        public RoomViewModel GetRoomById(int id)
        {
            Room room = this.Data.Rooms.Find(id);
            return CreateRoomViewModel(room);
        }

        private RoomViewModel CreateRoomViewModel(Room room)
        {
            RoomViewModel model = new RoomViewModel();
            model.Id = room.Id;
            model.Name = room.Name;
            model.Price = room.Price;
            model.RoomNumber = room.RoomNumber;

            return model;
        }

        public IEnumerable<RoomViewModel> GetRooms(bool getAll, bool isAvailable)
        {
            IEnumerable<RoomViewModel> rooms = this.Data.Rooms.All().Select(CreateRoomViewModel);
            return rooms;
        }

        public int CreateRoom()
        {
            throw new NotImplementedException();
        }
    }
}
