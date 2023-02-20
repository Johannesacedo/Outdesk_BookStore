using BookStore.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infra.Data
{
    public class BookDBContext : DbContext
    {
        public BookDBContext(DbContextOptions<BookDBContext> options) : base(options)
        {

        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<ReservedBook> ReservedBooks { get; set; }
    }
}
