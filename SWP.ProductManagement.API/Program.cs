
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
                options.UseSqlServer(connectionString,
                    sqlOptions => sqlOptions.MigrationsAssembly("SWP.ProductManagement.Repository")));
            builder.Services.AddCors(option =>
                option.AddPolicy("CORS", builder =>
                    builder.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin()));

            builder.Services.AddScoped<ProductService>();
            builder.Services.AddScoped<CategoryService>();
            builder.Services.AddScoped<UnitOfWork>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{

            //}
            app.UseCors("CORS");

            app.UseSwagger();

            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();
            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<ProductManagementContext>();
                db.Database.Migrate();
            }
            app.Run();
        }
    }
}
