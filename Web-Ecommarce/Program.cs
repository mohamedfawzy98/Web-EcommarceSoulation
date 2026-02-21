
using Domain.InterFace;
using Domain.InterFace.UintOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Presistence;
using Presistence.Data;
using Presistence.UnitsWork;
using Services;
using ServicesAbstarction;
using System.Reflection.Metadata;

namespace Web_Ecommarce
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
            builder.Services.AddDbContext<StoreDbContext>(op =>
            {
                op.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            // Apply DataSeeding
            builder.Services.AddScoped<IDataSeeed, DataSeed>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IServiceManger, ServiceManger>();
            // must Insatall In Services Layer 
            // AutoMapper.Extensions.Microsoft.DependencyInjection Pakages
            builder.Services.AddAutoMapper(typeof(Services.AssemblyReference).Assembly);
            var app = builder.Build();
            
            // Apply Explocit DI for DataSeeding

            using var scope = app.Services.CreateScope();
            var dataSeeed = scope.ServiceProvider.GetRequiredService<IDataSeeed>();
            dataSeeed.SeedingDataAsync();

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
