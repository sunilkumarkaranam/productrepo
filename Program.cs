using LayeredApp.Infrastructure;
using LayeredApp.Repository;
using Microsoft.EntityFrameworkCore;

namespace LayeredApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<IProductRepository, ProductRepository>();

            if (Environment.GetEnvironmentVariable("SQL_DB") != null)
            {
                builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(Environment.GetEnvironmentVariable("SQL_DB")));
            }
            else
            {
                builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataConnection")));
            }
            

            builder.Services.AddControllers();
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

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}