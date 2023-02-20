using BookStore.Infra.Repository.Interface;
using BookStore.Infra.Repository;
using BookStore.Infra.Service.Interface;
using BookStore.Infra.Service;
using Microsoft.AspNetCore.Mvc;
using BookStore.BLL.ErrorHandling;
using BookStore.BLL.AppDBContext;

namespace BookStore.BLL.ServiceExtensions
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //Services
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IReservedBookService, ReservedBookService>();

            //Repositories
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IReservedBookRepository, ReservedBookRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));
            services.AddScoped<IDatabaseInitializer, AppDBInitializer>();
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errors = actionContext.ModelState
                        .Where(e => e.Value.Errors.Count > 0)
                        .SelectMany(x => x.Value.Errors)
                        .Select(x => x.ErrorMessage).ToArray();

                    var errorResponse = new ApiValidationError
                    {
                        Errors = errors
                    };

                    return new BadRequestObjectResult(errorResponse);
                };
            });

            return services;
        }
    }
}
