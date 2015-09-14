using Dabravata.Data;
using Dabravata.Data.Service;
using Dabravata.Models;
using Dabravata.Models.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dabravata.Web.Areas.Administration.Controllers
{
    public class GalleryController : Controller
    {
        private readonly IImagesService imagesService;
        private readonly IUoWData data;

        public GalleryController()
        {
            this.data = new UoWData();
            this.imagesService = new ImagesService(data);
        }

        // GET: Administration/Gallery
        public ActionResult Index()
        {
            IEnumerable<Image> images = this.imagesService.GetGalleryImage();
            return View(images);
        }

        public ActionResult SaveUploadedFile(HttpPostedFileBase file)
        {
            this.imagesService.UploadGalleryImage(file);

            return Json(new { Message = "Succ: " + "fNameVariable" });
        }
    }
}