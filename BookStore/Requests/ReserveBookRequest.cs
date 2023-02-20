using MediatR;

namespace BookStore.Requests
{
    public class ReserveBookRequest : IRequest
    {
        public Guid BookId { get; set; }
    }
}
