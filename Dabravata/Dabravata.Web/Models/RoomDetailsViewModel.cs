﻿using Dabravata.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dabravata.Web.Models
{
    public class RoomDetailsViewModel
    {
        public RoomViewModel TheRoom { get; set; }

        public IEnumerable<RoomViewModel> SimilarRooms { get; set; }
    }
}