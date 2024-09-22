
using Microsoft.EntityFrameworkCore;
using SWP.ProductManagement.Repository;
using SWP.ProductManagement.Repository.Models;
using SWP.ProductManagement.Service.Services;

namespace SWP.ProductManagement.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<ProductManagementContext>(options =>
            options.UseSqlServer(connectionString));

            builder.Services.AddScoped<ProductService>();
            builder.Services.AddScoped<CategoryService>();
            builder.Services.AddScoped<UnitOfWork>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
           
            //}
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
