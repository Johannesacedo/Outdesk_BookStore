using BookStore.BLL.AppDBContext;
using BookStore.BLL.ServiceExtensions;
using BookStore.Infra.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var configBuilder = new ConfigurationBuilder();

// add values from a json file
configBuilder.AddJsonFile("appsettings.json");

// create the IConfigurationRoot instance
IConfigurationRoot config = configBuilder.Build();

// Add services to the container.
builder.Services.AddAutoMapper(typeof(MapDataProfile));
builder.Services.AddMediatR(typeof(Program).GetTypeInfo().Assembly);
builder.Services.AddControllers();
builder.Services.AddApplicationServices();
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddDbContext<BookDBContext>(options =>
{
    options.UseSqlServer(config.GetSection("ConnectionStrings:DefaultConnection").Value, b => b.MigrationsAssembly("BookStore.Infra"));
}, ServiceLifetime.Scoped);

var corsName = "corslist";
builder.Services.AddCors(options =>
{
    options.AddPolicy(corsName, builder =>
    {
        //App:CorsOrigins in appsettings.json can contain more than one address with splitted by comma.
        builder
            .WithOrigins(
               // App:CorsOrigins in appsettings.json can contain more than one address separated by comma.
               config.GetSection("App:CorsOrigins").Value
                    .Split(",", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray()
            )
            .SetIsOriginAllowedToAllowWildcardSubdomains()
            .SetIsOriginAllowed(origin => true)
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

SeedDatabase();
app.UseHttpsRedirection();
app.UseCors(corsName); //Enable CORS!

app.UseAuthorization();

app.MapControllers();

app.Run();

void SeedDatabase() //can be placed at the very bottom under app.Run()
{
    using (var scope = app.Services.CreateScope())
    {
        var databaseInitializer = scope.ServiceProvider.GetRequiredService<IDatabaseInitializer>();
        databaseInitializer.SeedData().Wait();
    }
}