using AutoMapper;
using BookStore.Core.DTO;
using BookStore.Core.Entities;
using BookStore.Core.Specifications;
using BookStore.Infra.Repository.Interface;
using BookStore.Infra.Service.Interface;
using Microsoft.EntityFrameworkCore;


namespace BookStore.Infra.Service
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public BookService(IBookRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> CheckBookExists(string name)
        {
            var books = await _repository.Books().AsNoTracking().FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());

            if (books == null)
                return false;
            else
                return true;
        }
        public async Task CreateBook(string bookName, Guid id)
        {
            _unitOfWork.Repository<Book>().Add(new Book
            {
                Id = id,
                Name = bookName,
            });
            await _unitOfWork.Complete();
        }

        public async Task<IReadOnlyList<BookDto>> GetBooks(BookSpecParameter specParams)
        {
            var specs = new GetBooksSpecification(specParams);
            var books = await _unitOfWork.Repository<Book>().ListAsync(specs);
            var booksMapped = _mapper.Map<IReadOnlyList<BookDto>>(books);
            return booksMapped;
        }
    }
}
