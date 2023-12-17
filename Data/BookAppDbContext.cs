using Microsoft.EntityFrameworkCore;
using BookApp.Entities;
namespace BookApp.Data
{
    public class BookAppDbContext : DbContext
    {
        public DbSet<Book> Books => Set<Book>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("StorageAppDb");
        }
    }
}
