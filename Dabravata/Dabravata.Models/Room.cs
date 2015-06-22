using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dabravata.Models
{
    public class Room
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public int Price { get; set; }
        
        public bool IsAvailable { get; set; }
    }
}
