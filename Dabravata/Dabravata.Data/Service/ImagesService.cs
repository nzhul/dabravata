using Dabravata.Models;
using Dabravata.Models.InputModels;
using ImageResizer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dabravata.Data.Service
{
    public class ImagesService : IImagesService
    {
        private readonly IUoWData Data;

        public ImagesService(IUoWData data)
        {
            this.Data = data;
        }

        public bool UploadImages(UploadPhotoModel uploadData)
        {
            Dictionary<string, string> versions = new Dictionary<string, string>();
            //Define the versions to generate
            versions.Add("_indexThumb", "width=230&height=234&crop=auto&format=jpg"); //Crop to square thumbnail
            versions.Add("_detailsBigThumb", "maxwidth=336&crop=auto&format=jpg"); //Fit inside 400x400 area, jpeg
            versions.Add("_detailsSmallThumb", "width=77&height=61&crop=auto&format=jpg"); //Fit inside 400x400 area, jpeg
            versions.Add("_large", "maxwidth=1500&maxheight=1500&format=jpg"); //Fit inside 1900x1200 area

            int categoryId = uploadData.CategoryId;
            int roomId = uploadData.RoomId;
            var theRoom = this.Data.Rooms.Find(roomId);

            bool firstLoop = true;
            foreach (var file in uploadData.Files)
            {
                if (file != null)
                {
                    var originalFileName = file.FileName.Split('.')[0].Replace(' ', '_');
                    var originalFileExtension = file.FileName.Split('.')[1];

                    string uploadFolder = System.Web.HttpContext.Current.Server.MapPath("~/Uploads/" + categoryId + "/" + roomId);
                    if (!Directory.Exists(uploadFolder)) Directory.CreateDirectory(uploadFolder);

                    foreach (string suffix in versions.Keys)
                    {
                        //Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                        string fileName = Path.Combine(uploadFolder, originalFileName + suffix);

                        fileName = ImageBuilder.Current.Build(file, fileName, new ResizeSettings(versions[suffix]), false, true);
                    }

                    var newImage = new Image
                    {
                        ImagePath = "Uploads\\" + categoryId + "\\" + roomId + "\\" + originalFileName,
                        ImageExtension = originalFileExtension,
                        IsPrimary = false,
                        DateAdded = DateTime.Now
                    };

                    if (firstLoop)
                    {
                        theRoom.Images.First(image => image.IsPrimary == true).IsPrimary = false;
                        newImage.IsPrimary = true;
                    }

                    theRoom.Images.Add(newImage);
                    this.Data.SaveChanges();
                }

                firstLoop = false;
            }

            return true;
        }


        public bool MakePrimary(int imageId, int roomId)
        {
            var theRoom = this.Data.Rooms.Find(roomId);
            if (theRoom == null)
            {
                return false;
            }

            var oldPrimary = theRoom.Images.FirstOrDefault(image => image.IsPrimary);
            oldPrimary.IsPrimary = false;

            var newPrimary = theRoom.Images.FirstOrDefault(image => image.Id == imageId);
            newPrimary.IsPrimary = true;

            this.Data.SaveChanges();

            return true;
        }

        public bool UploadImages(UploadAttractionPhotoModel uploadData)
        {
            Dictionary<string, string> versions = new Dictionary<string, string>();
            //Define the versions to generate
            versions.Add("_indexThumb", "width=361&height=78&crop=auto&format=jpg");
            versions.Add("_BigThumb", "maxwidth=361&height=223&crop=auto&format=jpg");
            versions.Add("_detailsSmallThumb", "width=77&height=61&crop=auto&format=jpg"); //Fit inside 400x400 area, jpeg
            versions.Add("_large", "width=827&crop=auto&format=jpg");

            int attractionId = uploadData.AttractionId;
            var theAttraction = this.Data.Attractions.Find(attractionId);

            foreach (var file in uploadData.Files)
            {
                if (file != null)
                {
                    var originalFileName = file.FileName.Split('.')[0].Replace(' ', '_');
                    var originalFileExtension = file.FileName.Split('.')[1];

                    string uploadFolder = System.Web.HttpContext.Current.Server.MapPath("~/Uploads/Attractions/" + attractionId);
                    if (!Directory.Exists(uploadFolder)) Directory.CreateDirectory(uploadFolder);

                    foreach (string suffix in versions.Keys)
                    {
                        string fileName = Path.Combine(uploadFolder, originalFileName + suffix);

                        fileName = ImageBuilder.Current.Build(file, fileName, new ResizeSettings(versions[suffix]), false, true);
                    }

                    var newImage = new Image
                    {
                        ImagePath = "Uploads\\Attractions\\" + attractionId + "\\" + originalFileName,
                        ImageExtension = originalFileExtension,
                        IsPrimary = true,
                        DateAdded = DateTime.Now,
                    };

                    theAttraction.Image = newImage;
                    this.Data.SaveChanges();
                }
            }

            return true;
        }
    }
}
