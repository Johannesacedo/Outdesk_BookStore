using BookStore.BLL.ErrorHandling;
using BookStore.Core.DTO;
using BookStore.Core.Specifications;
using BookStore.Infra.Service.Interface;
using BookStore.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.BLL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IBookService _bookService;
        public BookController(IMediator mediator, IBookService bookService)
        {
            _mediator = mediator;
            _bookService = bookService;
        }

        [HttpGet("books")]
        public async Task<IActionResult> GetBooks([FromQuery] BookSpecParameter request)
        {
            var results = await _bookService.GetBooks(request);

            return Ok(results);
        }

        [HttpPost("reserve")]
        public async Task<IActionResult> ReserveBook([FromBody] ReservedBookDTO request)
        {
            try
            {
                var req = new ReserveBookRequest
                {
                    BookId = request.BookId
                };

                var results = await _mediator.Send(req);

                return Ok();
            }
            catch (Exception x)
            {
                return BadRequest(new ApiStatusCodeResponse(400, x.Message));
            }
        }
    }
}
