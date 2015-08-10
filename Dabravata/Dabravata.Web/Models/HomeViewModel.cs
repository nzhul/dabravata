using Dabravata.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dabravata.Web.Models
{
    public class HomeViewModel
    {
        private IEnumerable<RoomFeatureViewModel> roomFeatures;
        private IEnumerable<AttractionViewModel> attractions;
        private IEnumerable<RoomViewModel> featuredRooms;

        public HomeViewModel()
        {
            this.roomFeatures = new List<RoomFeatureViewModel>();
            this.attractions = new List<AttractionViewModel>();
            this.featuredRooms = new List<RoomViewModel>();
        }

        public IEnumerable<AttractionViewModel> Attractions
        {
            get { return this.attractions; }
            set { this.attractions = value; }
        }

        public IEnumerable<RoomFeatureViewModel> RoomFeatures
        {
            get { return this.roomFeatures; }
            set { this.roomFeatures = value; }
        }

        public IEnumerable<RoomViewModel> FeaturedRooms
        {
            get { return this.featuredRooms; }
            set { this.featuredRooms = value; }
        }
    }
}