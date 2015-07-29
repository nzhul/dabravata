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
    }
}
