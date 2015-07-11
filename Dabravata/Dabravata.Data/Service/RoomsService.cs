using Dabravata.Models;
using Dabravata.Models.InputModels;
using Dabravata.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

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

        public int CreateRoom(CreateRoomInputModel room)
        {
            //var selectedCategory = this.Data.RoomCategories.Find(room.SelectedCategoryId);
            Room newRoom = new Room();
            newRoom.Name = room.Name;
            newRoom.IsFeatured = room.IsFeatured;
            newRoom.RoomNumber = room.RoomNumber;
            newRoom.Price = room.Price;
            newRoom.DateAdded = DateTime.Now;
            newRoom.ShortDescription = room.ShortDescription;
            newRoom.LongDescription = room.LongDescription;
            newRoom.DisplayOrder = room.DisplayOrder;
            newRoom.IsAvailable = true;
            newRoom.IsPriceVisible = room.IsPriceVisible;
            newRoom.RoomCategoryId = 1;

            this.Data.Rooms.Add(newRoom);
            this.Data.SaveChanges();

            return newRoom.Id;
        }
    }
}
