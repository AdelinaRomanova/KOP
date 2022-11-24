using LibraryContracts.BindingModels;
using LibraryContracts.StorageContracts;
using LibraryContracts.ViewModels;
using LibraryDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDatabaseImplement.Implements
{
    public class GenreStorage : IGenreStorage
    {
        public List<GenreViewModel> GetFullList()
        {
            using var context = new LibraryDatabase();
            return context.Genres
                .Select(CreateModel)
                .ToList();
        }

        public List<GenreViewModel> GetFilteredList(GenreBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new LibraryDatabase();
            return context.Genres
                .Where(rec => rec.Name.Contains(model.Name))
                .Select(CreateModel)
                .ToList();
        }

        public GenreViewModel GetElement(GenreBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new LibraryDatabase();

            var genre = context.Genres
                    .ToList()
                    .FirstOrDefault(rec => rec.Id == model.Id || rec.Name == model.Name);
            return genre != null ? CreateModel(genre) : null;

        }

        public void Insert(GenreBindingModel model)
        {
            var context = new LibraryDatabase();
            var transaction = context.Database.BeginTransaction();
            try
            {
                context.Genres.Add(CreateModel(model, new Genre()));
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Update(GenreBindingModel model)
        {
            var context = new LibraryDatabase();
            var transaction = context.Database.BeginTransaction();
            try
            {
                var genre = context.Genres.FirstOrDefault(rec => rec.Id == model.Id);
                if (genre == null)
                {
                    throw new Exception("Жанр не найден");
                }
                CreateModel(model, genre);
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }


        public void Delete(GenreBindingModel model)
        {
            var context = new LibraryDatabase();
            var shape = context.Genres.FirstOrDefault(rec => rec.Id == model.Id);
            if (shape != null)
            {
                context.Genres.Remove(shape);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Жанр не найден");
            }
        }

        private static Genre CreateModel(GenreBindingModel model, Genre genre)
        {
            genre.Name = model.Name;
            return genre;
        }

        private static GenreViewModel CreateModel(Genre genre)
        {
            return new GenreViewModel
            {
                Id = genre.Id,
                Name = genre.Name
            };
        }
    }
}
