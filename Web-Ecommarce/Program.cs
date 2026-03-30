using Domain.InterFace;
using Domain.InterFace.UintOfWorks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Presistence;
using Presistence.Data;
using Presistence.UnitsWork;
using Services;
using Services.ProfileMapping;
using ServicesAbstarction;
using ServicesAbstarction.ExcaptionErrors;
using System.Reflection.Metadata;
using Web_Ecommarce.CustomMiddelWare;

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
            // must Insatall In Services Layer 
            // AutoMapper.Extensions.Microsoft.DependencyInjection Pakages
            builder.Services.AddAutoMapper(x => x.AddProfile(new ProductProfile()));
           //builder.Services.AddAutoMapper(typeof(Services.AssemblyReference).Assembly);
            builder.Services.AddScoped<IServiceManger, ServiceManger>();
            builder.Services.AddScoped<PictureResolver>();

            // Handle Valdation Error
            builder.Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = (actionContext) =>
                {
                    var Errors = actionContext.ModelState
                        .Where(e => e.Value.Errors.Any())
                        .Select(M => new ValdationError()
                        {
                            Filed = M.Key,
                            Errors = M.Value.Errors.Select(e => e.ErrorMessage)
                        });
                    var responseObj = new ValdationErrorToReturn()
                    {
                        ValdationErrors = Errors
                    };
                    return new BadRequestObjectResult(responseObj);
                };
            });

            var app = builder.Build();

            // Apply Explocit DI for DataSeeding

            using var scope = app.Services.CreateScope();
            var dataSeeed = scope.ServiceProvider.GetRequiredService<IDataSeeed>();
            dataSeeed.SeedingDataAsync();



            // Custome Moddleware for Exception Handling
            app.UseMiddleware<CustomeExeptionHandlerMiddelWare>();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseStaticFiles();

            app.MapControllers();

            app.Run();
        }
    }
}
