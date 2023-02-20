using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infra.Service.Interface
{
    public interface IReservedBookService
    {
        Task ReserveBook(Guid bookId);
    }
}
