using Jac.Search.Services;
using Microsoft.Extensions.Configuration;

namespace Jac.Search.Interfaces
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddScoped<ICustomersService, CustomersService>();
            builder.Services.AddScoped<IProductsService, ProductsService>();
            builder.Services.AddScoped<ISalesService, SalesService>();

            builder.Services.AddHttpClient("customersService", c =>
            {
                c.BaseAddress = new Uri(builder.Configuration["Services:Customers"]);
            });

            builder.Services.AddHttpClient("productsService", c =>
            {
                c.BaseAddress = new Uri(builder.Configuration["Services:Products"]);
            });

            builder.Services.AddHttpClient("salesService", c =>
            {
                c.BaseAddress = new Uri(builder.Configuration["Services:Sales"]);
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}