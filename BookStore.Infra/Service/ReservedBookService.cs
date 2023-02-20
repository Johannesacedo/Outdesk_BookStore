using BookStore.Core.Entities;
using BookStore.Infra.Repository.Interface;
using BookStore.Infra.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infra.Service
{
    public class ReservedBookService : IReservedBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IReservedBookRepository _reservedBookRepository;
        public ReservedBookService(IUnitOfWork unitOfWork, IReservedBookRepository reservedBookRepository)
        {
            _unitOfWork = unitOfWork;
            _reservedBookRepository = reservedBookRepository;
        }

        public async Task ReserveBook(Guid bookId)
        {
            var reservedBook = await _reservedBookRepository.ReservedBooks().AsNoTracking().FirstOrDefaultAsync(x => x.BookId == bookId);
            if (reservedBook != null)
                throw new Exception("Book is already reserved!");

            var book = await _reservedBookRepository.ReservedBooks().AsNoTracking().OrderByDescending(x => x.BookingNumber).FirstOrDefaultAsync();
            var bookingNumber = 1;
            if (book != null)
                bookingNumber = book.BookingNumber + 1;

            _unitOfWork.Repository<ReservedBook>().Add(new ReservedBook
            {
                BookId = bookId,
                BookingNumber = bookingNumber
            });
            await _unitOfWork.Complete();
        }
    }
}
