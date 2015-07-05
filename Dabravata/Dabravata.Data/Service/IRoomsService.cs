using Dabravata.Models.InputModels;
using Dabravata.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dabravata.Data.Service
{
    public interface IRoomsService
    {
        RoomViewModel GetRoomById(int id);

        /// <summary>
        /// Get all rooms from the database
        /// </summary>
        /// <returns>Collection of RoomViewModel</returns>
        IEnumerable<RoomViewModel> GetRooms(bool getAll, bool isAvailable);

        /// <summary>
        /// Creates new Room in the database
        /// </summary>
        /// <returns>Returns the Id of the new Room</returns>
        int CreateRoom(CreateRoomInputModel room);
    }
}
