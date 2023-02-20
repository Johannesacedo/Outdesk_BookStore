using BookStore.Core.Entities;
using BookStore.Infra.Data;
using BookStore.Infra.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infra.Repository
{
    public class ReservedBookRepository : IReservedBookRepository
    {
        private readonly BookDBContext _context;
        public ReservedBookRepository(BookDBContext context)
        {
            _context = context;
        }

        public IQueryable<ReservedBook> ReservedBooks()
        {
            return _context.ReservedBooks;
        }
    }
}
