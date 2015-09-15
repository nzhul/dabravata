using Dabravata.Models;
using Dabravata.Models.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Dabravata.Data.Service
{
    public interface IImagesService
    {
        bool UploadImages(UploadPhotoModel uploadData);

        bool UploadImages(UploadAttractionPhotoModel uploadData);

        bool MakePrimary(int imageId, int productId);

        IEnumerable<Image> GetRandomRoomImages();

        bool UploadGalleryImage(HttpPostedFileBase file);

        IEnumerable<Image> GetGalleryImage();

        bool DeleteGalleryImage(int imageId);
    }
}
