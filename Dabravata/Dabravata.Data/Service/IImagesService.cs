using Dabravata.Models.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dabravata.Data.Service
{
    public interface IImagesService
    {
        bool UploadImages(UploadPhotoModel uploadData);

        bool MakePrimary(int imageId, int productId);
    }
}
