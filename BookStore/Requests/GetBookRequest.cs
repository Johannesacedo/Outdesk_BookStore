using MediatR;

namespace BookStore.Requests
{
    public class GetBookRequest : IRequest
    {
        public string Search { get; set; }
    }
}
