﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dabravata.Models.ViewModels
{
    public class RoomCategoryViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Slug { get; set; }

        public string Description { get; set; }

        public DateTime DateAdded { get; set; }

        public int RoomsCount { get; set; }
    }
}
