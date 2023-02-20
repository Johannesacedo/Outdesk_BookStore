using BookStore.Core.DTO;
using BookStore.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infra.Service.Interface
{
    public interface IBookService
    {
        Task<bool> CheckBookExists(string name);
        Task CreateBook(string bookName, Guid id);
        Task<IReadOnlyList<BookDto>> GetBooks(BookSpecParameter specParams);
    }
}
