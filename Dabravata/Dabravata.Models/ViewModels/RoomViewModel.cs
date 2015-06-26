using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dabravata.Models.ViewModels
{
    public class RoomViewModel
    {
        private ICollection<RoomFeature> roomFeatures;

        public RoomViewModel()
        {
            this.roomFeatures = new HashSet<RoomFeature>();
        }

        public int Id { get; set; }

        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public int Price { get; set; }
        
        public bool IsAvailable { get; set; }

        public string RoomCategoryName { get; set; }

        public Image PrimaryImage { get; set; }

        public virtual ICollection<RoomFeature> RoomFeature
        {
            get { return this.roomFeatures; }
            set { this.roomFeatures = value; }
        }
    }
}
