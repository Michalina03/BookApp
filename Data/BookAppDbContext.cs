using Microsoft.EntityFrameworkCore;
using BookApp.Data.Entities;

namespace BookApp.Data
{
    public class BookAppDbContext : DbContext
    {
        public DbSet<Book> Books => Set<Book>();
        public DbSet<Textbook> Textbook => Set<Textbook>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("StorageAppDb");
        }
    }
}
