using Dabravata.Models.InputModels;
using Dabravata.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dabravata.Data.Service
{
    public interface IPagesService
    {
        IEnumerable<PageViewModel> GetPages();

        int CreatePage(CreatePageInputModel inputModel);

        bool PageExists(int id);

        CreatePageInputModel GetPageInputModelById(int id);

        bool UpdatePage(int id, CreatePageInputModel inputModel);

        bool DeletePage(int id);
    }
}
