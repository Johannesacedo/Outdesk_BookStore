using BookStore.Infra.Service.Interface;
using BookStore.Requests;
using MediatR;

namespace BookStore.Application.Commands
{
    public class GetBookCommandHandler : IRequestHandler<GetBookRequest>
    {
        private readonly IBookService _bookService;
        public GetBookCommandHandler(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<Unit> Handle(GetBookRequest request, CancellationToken cancellationToken)
        {
            return Unit.Value;
        }
    }
}
