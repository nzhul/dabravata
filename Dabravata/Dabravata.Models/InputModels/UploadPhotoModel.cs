using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Dabravata.Models.InputModels
{
    public class UploadPhotoModel
    {
        public int RoomId { get; set; }

        public int CategoryId { get; set; }

        public IEnumerable<HttpPostedFileBase> Files { get; set; }
    }
}
