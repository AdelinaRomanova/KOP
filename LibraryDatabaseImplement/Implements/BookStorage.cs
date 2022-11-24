using LibraryContracts.BindingModels;
using LibraryContracts.StorageContracts;
using LibraryContracts.ViewModels;
using LibraryDatabaseImplement.Models;

namespace LibraryDatabaseImplement.Implements
{
    public class BookStorage : IBookStorage
    {
        public List<BookViewModel> GetFullList()
        {
            using (var context = new LibraryDatabase())
            {
                return context.Books
                .ToList()
                .Select(CreateModel)
                .ToList();
            }
        }

        public List<BookViewModel> GetFilteredList(BookBindingModel model)
        {
            var context = new LibraryDatabase();
            return context.Books
                .Where(book => book.Title.Contains(model.Title) && book.Genre.Contains(model.Genre))
                .ToList()
                .Select(CreateModel)
                .ToList();
        }

        public BookViewModel GetElement(BookBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new LibraryDatabase();
            var book = context.Books
                    .ToList()
                    .FirstOrDefault(rec => rec.Title == model.Title || rec.Id == model.Id);
            return book != null ? CreateModel(book) : null;
        }

        public void Insert(BookBindingModel model)
        {
            var context = new LibraryDatabase();
            var transaction = context.Database.BeginTransaction();
            try
            {
                context.Books.Add(CreateModel(model, new Book()));
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Update(BookBindingModel model)
        {
            var context = new LibraryDatabase();
            var transaction = context.Database.BeginTransaction();
            try
            {
                var book = context.Books.FirstOrDefault(rec => rec.Id == model.Id);
                if (book == null)
                {
                    throw new Exception("Книга не найдена");
                }
                CreateModel(model, book);
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }


        public void Delete(BookBindingModel model)
        {
            var context = new LibraryDatabase();
            var book = context.Books.FirstOrDefault(rec => rec.Id == model.Id);
            if (book != null)
            {
                context.Books.Remove(book);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Книга не найдена");
            }
        }

        private static Book CreateModel(BookBindingModel model, Book book)
        {
            book.Title = model.Title;
            book.Description = model.Description;
            book.Genre = model.Genre;
            book.Cost = model.Cost;
            return book;
        }

        private BookViewModel CreateModel(Book book)
        {
            return new BookViewModel
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                Genre = book.Genre,
                Cost = book.Cost
            };
        }
    }
}
