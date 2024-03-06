using Microsoft.EntityFrameworkCore;
using BookApp.Data.Entities;

namespace BookApp.Data
{
    public class BookAppDbContext : DbContext
    {
        public BookAppDbContext(DbContextOptions<BookAppDbContext>options)
            : base(options)
        {

        }
        public DbSet<Book> Book { get; set; }
    }
}
