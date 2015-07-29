using Dabravata.Models.Pages;
using Dabravata.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dabravata.Data.Service
{
    public class PagesService : IPagesService
    {
        private readonly IUoWData Data;

        public PagesService(IUoWData data)
        {
            this.Data = data;
        }

        public IEnumerable<PageViewModel> GetPages()
        {
            IEnumerable<PageViewModel> model = this.Data.Pages.All().Select(MapPageViewModel);

            return model;
        }

        private PageViewModel MapPageViewModel (Page page)
        {
            PageViewModel model = new PageViewModel();
            model.Title = page.Title;
            model.Description = page.Description;
            model.Content = page.Content;

            return model;
        }
    }
}
