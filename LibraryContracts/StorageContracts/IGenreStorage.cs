using LibraryContracts.BindingModels;
using LibraryContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryContracts.StorageContracts
{
    public interface IGenreStorage
    {
        List<GenreViewModel> GetFullList();
        List<GenreViewModel> GetFilteredList(GenreBindingModel model);
        GenreViewModel GetElement(GenreBindingModel model);

        void Insert(GenreBindingModel model);
        void Update(GenreBindingModel model);
        void Delete(GenreBindingModel model);
    }
}
