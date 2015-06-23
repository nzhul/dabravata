using Dabravata.Data.Repositories;
using Dabravata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dabravata.Data
{
    public interface IUoWData
    {
        IRepository<ApplicationUser> Users { get; }
        IRepository<Room> Rooms { get; }
        IRepository<RoomCategory> RoomCategories { get; }
        IRepository<RoomFeature> RoomFeatures { get; }
        IRepository<Image> Images { get; }
        IRepository<Attraction> Attractions { get; }
        IRepository<Reservation> Reservations { get; }

        int SaveChanges();
    }
}
