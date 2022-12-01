using LibraryContracts.BindingModels;
using LibraryContracts.BusinessLogicsContracts;
using LibraryContracts.StorageContracts;
using LibraryContracts.ViewModels;
using LibraryDatabaseImplement.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBusinessLogic.BusinessLogics
{
    public class GenreLogic : IGenreLogic
    {
        private readonly IGenreStorage _genreStorage;

        public GenreLogic()
        {
            _genreStorage = new GenreStorage();
        }

        public List<GenreViewModel> Read(GenreBindingModel model)
        {
            if (model == null)
            {
                return _genreStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<GenreViewModel> { _genreStorage.GetElement(model) };
            }
            return _genreStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(GenreBindingModel model)
        {
            var element = _genreStorage.GetElement(
                new GenreBindingModel
                {
                    Name = model.Name
                });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Такой жанр уже существует");
            }
            if (model.Id.HasValue)
            {
                _genreStorage.Update(model);
            }
            else
            {
                _genreStorage.Insert(model);
            }
        }

        public void Delete(GenreBindingModel model)
        {
            var element = _genreStorage.GetElement(new GenreBindingModel { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Жанр не найден");
            }
            _genreStorage.Delete(model);
        }
    }
}
