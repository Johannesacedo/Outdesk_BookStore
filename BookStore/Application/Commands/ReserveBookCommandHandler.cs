using BookStore.Infra.Service.Interface;
using BookStore.Requests;
using MediatR;
namespace BookStore.Application.Commands
{
    public class ReserveBookCommandHandler:IRequestHandler<ReserveBookRequest>
    {
        private readonly IReservedBookService _reservedBookService;
        public ReserveBookCommandHandler(IReservedBookService reservedBookService)
        {
            _reservedBookService = reservedBookService;
        }
        public async Task<Unit> Handle(ReserveBookRequest request, CancellationToken cancellationToken)
        {
            await _reservedBookService.ReserveBook(request.BookId);
            return Unit.Value;
        }
    }
}
