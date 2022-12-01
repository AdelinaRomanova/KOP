using LibraryContracts.BusinessLogicsContracts;
using LibraryContracts.StorageContracts;
using LibraryContracts.BindingModels;
using LibraryContracts.ViewModels;
using LibraryDatabaseImplement.Implements;

namespace LibraryBusinessLogic.BusinessLogics
{
    public class BookLogic : IBookLogic
    {
        private readonly IBookStorage _bookStorage;
        public BookLogic()
        {
            _bookStorage = new BookStorage();
        }

        public List<BookViewModel> Read(BookBindingModel model)
        {
            if (model == null)
            {
                return _bookStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<BookViewModel> { _bookStorage.GetElement(model) };
            }
            return _bookStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(BookBindingModel model)
        {
            var element = _bookStorage.GetElement(
                new BookBindingModel
                {
                    Title = model.Title
                });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Книга с таким названием уже существует");
            }
            if (model.Id.HasValue)
            {
                _bookStorage.Update(model);
            }
            else
            {
                _bookStorage.Insert(model);
            }
        }

        public void Delete(BookBindingModel model)
        {
            var element = _bookStorage.GetElement(new BookBindingModel { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Книга не найдена");
            }
            _bookStorage.Delete(model);
        }
    }
}
