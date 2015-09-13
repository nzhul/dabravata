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
        // GET: Administration/Gallery
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SaveUploadedFile()
        {
            //IMPORTANT - The action is executed for every image upload!!!!

            bool isSavedSuccessfully = true;
            string fName = "";

            foreach (string fileName in Request.Files)
            {
                HttpPostedFileBase file = Request.Files[fileName];
                //Save file content goes here
                fName = file.FileName;
                if (file != null && file.ContentLength > 0)
                {
                    var asd = 1;
                }

            }

            return Json(new { Message = "Succ: " + fName });
        }
    }
}