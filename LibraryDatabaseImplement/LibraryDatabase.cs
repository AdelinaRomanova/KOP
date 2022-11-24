using Microsoft.EntityFrameworkCore;
using LibraryDatabaseImplement.Models;

namespace LibraryDatabaseImplement
{
    public class LibraryDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=LibraryDatabase;Integrated Security=True;MultipleActiveResultSets=True; TrustServerCertificate=True");
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().Property(m => m.Cost).IsRequired(false);
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Book> Books { set; get; }

        public virtual DbSet<Genre> Genres { set; get; }
    }
}
