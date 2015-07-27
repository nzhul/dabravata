﻿using Dabravata.Models;
using Dabravata.Models.InputModels;
using Dabravata.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;

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
            return MapRoomViewModel(room);
        }

        private RoomViewModel MapRoomViewModel(Room room)
        {
            RoomViewModel model = new RoomViewModel();
            model.Id = room.Id;
            model.Name = room.Name;
            model.Price = room.Price;
            model.RoomNumber = room.RoomNumber;

            return model;
        }

        public CreateRoomInputModel GetRoomInputModelById(int id)
        {
            Room room = this.Data.Rooms.Find(id);
            return MapRoomInputModel(room);
        }

        private CreateRoomInputModel MapRoomInputModel(Room room)
        {
            CreateRoomInputModel model = new CreateRoomInputModel();
            model.Id = room.Id;
            model.Name = room.Name;
            model.IsFeatured = room.IsFeatured;
            model.RoomNumber = room.RoomNumber;
            model.Price = room.Price;
            model.ShortDescription = room.ShortDescription;
            model.LongDescription = room.LongDescription;
            model.DisplayOrder = room.DisplayOrder;
            model.IsAvailable = room.IsAvailable;
            model.IsPriceVisible = room.IsPriceVisible;
            model.SelectedCategoryId = room.RoomCategoryId;
            model.Images = room.Images;

            return model;
        }

        public IEnumerable<RoomViewModel> GetRooms(bool getAll, bool isAvailable)
        {
            IEnumerable<RoomViewModel> rooms = this.Data.Rooms.All().Select(MapRoomViewModel);
            return rooms;
        }

        public bool CreateRoom(CreateRoomInputModel room)
        {
            Room newRoom = new Room();
            newRoom.Name = room.Name;
            newRoom.IsFeatured = room.IsFeatured;
            newRoom.RoomNumber = room.RoomNumber;
            newRoom.Price = room.Price;
            newRoom.DateAdded = DateTime.Now;
            newRoom.ShortDescription = room.ShortDescription;
            newRoom.LongDescription = room.LongDescription;
            newRoom.DisplayOrder = room.DisplayOrder;
            newRoom.IsAvailable = room.IsAvailable;
            newRoom.IsPriceVisible = room.IsPriceVisible;
            newRoom.RoomCategoryId = room.SelectedCategoryId;

            Image defaultImage = new Image
            {
                ImageExtension = "jpg",
                ImagePath = "Content\\images\\noimage\\no-image",
                IsPrimary = true,
                DateAdded = DateTime.Now
            };

            this.Data.Rooms.Add(newRoom);
            this.Data.SaveChanges();

            newRoom.Images.Add(defaultImage);
            this.Data.SaveChanges();

            return true;
        }

        public bool RoomExists(int id)
        {
            if (id <= 0)
            {
                return false;
            }
            else
            {
                bool result = this.Data.Rooms.All().Any();
                return result;
            }
        }


        public IEnumerable<SelectListItem> GetCategories()
        {
            var categories = this.Data.RoomCategories
                .All()
                .OrderBy(x => x.Id)
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name.ToString()
                });

            return new SelectList(categories, "Value", "Text");
        }


        public IEnumerable<RoomCategoryViewModel> GetRoomCategories(bool getAll)
        {
            IEnumerable<RoomCategoryViewModel> roomCategories = this.Data.RoomCategories.All().Select(MapRoomCategoriesViewModel);
            return roomCategories;
        }

        private RoomCategoryViewModel MapRoomCategoriesViewModel(RoomCategory roomCategory)
        {
            RoomCategoryViewModel model = new RoomCategoryViewModel();
            model.Id = roomCategory.Id;
            model.Name = roomCategory.Name;
            model.Slug = roomCategory.Slug;
            model.Description = roomCategory.Description;
            model.DateAdded = roomCategory.DateAdded;
            model.RoomsCount = roomCategory.Rooms.Count;

            return model;
        }


        public int CreateRoomCategory(CreateRoomCategoryInputModel roomCategory)
        {
            RoomCategory newRoomCategory = new RoomCategory();
            newRoomCategory.Name = roomCategory.Name;
            newRoomCategory.DisplayOrder = roomCategory.DisplayOrder;
            newRoomCategory.Description = roomCategory.Description;
            newRoomCategory.DateAdded = DateTime.Now;

            this.Data.RoomCategories.Add(newRoomCategory);
            this.Data.SaveChanges();

            return newRoomCategory.Id;
        }


        public CreateRoomCategoryInputModel GetRoomCategoryInputModelById(int id)
        {
            RoomCategory roomCategory = this.Data.RoomCategories.Find(id);
            return MapRoomCategoryInputModel(roomCategory);
        }

        private CreateRoomCategoryInputModel MapRoomCategoryInputModel(RoomCategory roomCategory)
        {
            CreateRoomCategoryInputModel model = new CreateRoomCategoryInputModel();
            model.Description = roomCategory.Description;
            model.DisplayOrder = roomCategory.DisplayOrder;
            model.Name = roomCategory.Name;

            return model;
        }


        public bool UpdateRoomCategory(int id, CreateRoomCategoryInputModel roomCategory)
        {
            RoomCategory dbRoomCategory = this.Data.RoomCategories.Find(id);
            if (dbRoomCategory != null)
            {
                dbRoomCategory.Description = roomCategory.Description;
                dbRoomCategory.DisplayOrder = roomCategory.DisplayOrder;
                dbRoomCategory.Name = roomCategory.Name;

                this.Data.SaveChanges();

                return true;
            }
            else
            {
                return false;
            }
        }
        
        public bool UpdateRoom(int id, CreateRoomInputModel inputModel)
        {
            Room dbRoom = this.Data.Rooms.Find(id);
            if (dbRoom != null)
            {
                dbRoom.DisplayOrder = inputModel.DisplayOrder;
                dbRoom.IsAvailable = inputModel.IsAvailable;
                dbRoom.IsFeatured = inputModel.IsFeatured;
                dbRoom.IsPriceVisible = inputModel.IsPriceVisible;
                dbRoom.LongDescription = inputModel.LongDescription;
                dbRoom.Name = inputModel.Name;
                dbRoom.Price = inputModel.Price;
                dbRoom.RoomCategoryId = inputModel.SelectedCategoryId;
                dbRoom.RoomNumber = inputModel.RoomNumber;
                dbRoom.ShortDescription = inputModel.ShortDescription;

                this.Data.SaveChanges();

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}