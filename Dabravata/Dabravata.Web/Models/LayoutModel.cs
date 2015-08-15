using Dabravata.Models;
using Dabravata.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dabravata.Web.Models
{
    public class LayoutModel
    {
        private IEnumerable<RoomCategoryViewModel> roomCategories;
        private IEnumerable<AttractionViewModel> attractions;
        private IEnumerable<PageViewModel> pages;

        public LayoutModel()
        {
            this.roomCategories = new List<RoomCategoryViewModel>();
            this.attractions = new List<AttractionViewModel>();
            this.pages = new List<PageViewModel>();
        }

        public IEnumerable<PageViewModel> Pages
        {
            get { return this.pages; }
            set { this.pages = value; }
        }

        public IEnumerable<RoomCategoryViewModel> RoomCategories 
        {
            get { return this.roomCategories; }
            set { this.roomCategories = value; }
        }

        public IEnumerable<AttractionViewModel> Attractions
        {
            get { return this.attractions; }
            set { this.attractions = value; }
        }
    }
}