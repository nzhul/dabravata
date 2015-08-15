﻿using Dabravata.Data;
using Dabravata.Data.Service;
using Dabravata.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dabravata.Web.Controllers
{
    public class PagesController : BaseController
    {
        private readonly IUoWData data;
        private readonly IPagesService pagesService;
        public PagesController()
        {
            this.data = new UoWData();
            this.pagesService = new PagesService(this.data);
        }

        public ActionResult Index(int id)
        {
            PageViewModel model = this.pagesService.GetPageById(id);
            return View(model);
        }
    }
}