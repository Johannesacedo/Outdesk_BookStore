using BookStore.Core.Entities;
using BookStore.Infra.Data;
using BookStore.Infra.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infra.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookDBContext _context;
        public BookRepository(BookDBContext context)
        {
            _context = context;
        }

        public IQueryable<Book> Books()
        {
            return _context.Books;
        }
    }
}
