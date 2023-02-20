using BookStore.Infra.Data;
using BookStore.Infra.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace BookStore.BLL.AppDBContext
{
    public interface IDatabaseInitializer
    {
        Task SeedData();
    }
    public class AppDBInitializer : IDatabaseInitializer
    {
        private readonly BookDBContext _dbContext;
        private readonly IBookService _bookService;
        private IConfiguration _config;

        public AppDBInitializer(BookDBContext dbContext, IBookService bookService, IConfiguration config)
        {
            _dbContext = dbContext;
            _bookService = bookService;
            _config = config;
        }


        public async Task SeedData()
        {
            await _dbContext.Database.MigrateAsync().ConfigureAwait(false);
            await InitializeBooks();
        }

        private async Task InitializeBooks()
        {
            var book1Name = "CQRS for Dummies";
            var book1Id = Guid.Parse("9b0896fa-3880-4c2e-bfd6-925c87f22878");

            //Create Book 1
            var book1Exists = await _bookService.CheckBookExists(book1Name);
            if (!book1Exists)
            {
                await _bookService.CreateBook(book1Name, book1Id);
            }

            var book2Name = "Visual Studio Tips";
            var book2Id = Guid.Parse("0550818d-36ad-4a8d-9c3a-a715bf15de76");

            //Create Book 1
            var book2Exists = await _bookService.CheckBookExists(book2Name);
            if (!book2Exists)
            {
                await _bookService.CreateBook(book2Name, book2Id);
            }

            var book3Name = "NHibernate Cookbook";
            var book3Id = Guid.Parse("8e0f11f1-be5c-4dbc-8012-c19ce8cbe8e1");

            //Create Book 1
            var book3Exists = await _bookService.CheckBookExists(book3Name);
            if (!book3Exists)
            {
                await _bookService.CreateBook(book3Name, book3Id);
            }
        }
    }
}
