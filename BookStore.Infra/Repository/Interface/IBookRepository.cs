using BookStore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infra.Repository.Interface
{
    public interface IBookRepository
    {
        IQueryable<Book> Books();
    }
}
