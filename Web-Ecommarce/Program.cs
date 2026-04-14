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
using System.Threading.Tasks;
using Web_Ecommarce.CustomMiddelWare;

namespace Web_Ecommarce
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Service Regestraion
            // Add services to the container.
            builder.Services.AddControllers();
            // Add Swagger (Web Layer)
            builder.Services.AddSwaggerervices();
            // Apply DbContext (Layer Infrasturcture)
            builder.Services.AddInfrastructureService(builder.Configuration);
            // Apply AutoMapperl (Layer Service)
            builder.Services.AddApplicationServices();
            // Handle Valdation Error (Web Layer)
            builder.Services.AddWebApplcationServices();
            // Handle Authentcation By Token
            builder.Services.AddAuthenticationServices(builder.Configuration);
            #endregion

            var app = builder.Build();

            // Apply Explocit DI for DataSeeding (web Layer)
            await app.AddSeedingDataAsync();
            await app.AddSeedingDataIdentityAsync();

            #region MiddelWare

            // Custome Moddleware for Exception Handling
            app.UseCustomeExeptionHandlerMiddelWare();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwaggerMiddelWare();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseStaticFiles();

            app.MapControllers();

            app.Run();
        }
    }
    #endregion
}
