using LibraryContracts.BindingModels;
using LibraryContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryContracts.BusinessLogicsContracts
{
    public interface IGenreLogic
    {
        List<GenreViewModel> Read(GenreBindingModel model);
        void CreateOrUpdate(GenreBindingModel model);
        void Delete(GenreBindingModel model);
    }
}
