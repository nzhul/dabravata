﻿using Dabravata.Models;
using Dabravata.Models.InputModels;
using Dabravata.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Dabravata.Data.Service
{
    public interface IRoomsService
    {
        RoomViewModel GetRoomById(int id);

        CreateRoomInputModel GetRoomInputModelById(int id);

        /// <summary>
        /// Get all rooms from the database
        /// </summary>
        /// <returns>Collection of RoomViewModel</returns>
        IEnumerable<RoomViewModel> GetRooms(bool getAll, bool isAvailable);

        /// <summary>
        /// Creates new Room in the database
        /// </summary>
        /// <returns>Returns the Id of the new Room</returns>
        bool CreateRoom(CreateRoomInputModel room);

        bool RoomExists(int id);

        IEnumerable<SelectListItem> GetCategories();

        IEnumerable<RoomCategoryViewModel> GetRoomCategories(bool getAll);

        int CreateRoomCategory(CreateRoomCategoryInputModel roomCategory);

        CreateRoomCategoryInputModel GetRoomCategoryInputModelById(int id);

        bool UpdateRoomCategory(int id, CreateRoomCategoryInputModel inputModel);

        bool UpdateRoom(int id, CreateRoomInputModel inputModel);

        IEnumerable<RoomFeatureViewModel> GetRoomFeatures(bool getAll);

        int CreateRoomFeature(CreateRoomFeatureInputModel featureInput);

        CreateRoomFeatureInputModel GetRoomFeatureInputModelById(int id);

        bool UpdateRoomFeature(int id, CreateRoomFeatureInputModel roomFeature);

        bool DeleteRoomFeature(int id);

        IEnumerable<RoomFeature> GetAvailableRoomFeatures();

        List<int> GetSelectedRoomFeatureIds(int id);
    }
}
