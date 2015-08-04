using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Dabravata.Models.InputModels
{
    public class UploadAttractionPhotoModel
    {
        public int AttractionId { get; set; }

        public IEnumerable<HttpPostedFileBase> Files { get; set; }
    }
}
