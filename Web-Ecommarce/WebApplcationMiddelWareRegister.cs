using Domain.InterFace;
using System.Threading.Tasks;
using Web_Ecommarce.CustomMiddelWare;

namespace Web_Ecommarce
{
    public static class WebApplcationMiddelWareRegister
    {
        public static async Task<WebApplication> AddSeedingDataAsync(this WebApplication app)
        {
            // Apply Explocit DI for DataSeeding

            using var scope = app.Services.CreateScope();
            var dataSeeed = scope.ServiceProvider.GetRequiredService<IDataSeeed>();
           await dataSeeed.SeedingDataAsync();
            return app;
        }
        public static async Task<WebApplication> AddSeedingDataIdentityAsync(this WebApplication app)
        {
            // Apply Explocit DI for DataSeeding

            using var scope = app.Services.CreateScope();
            var dataSeeed = scope.ServiceProvider.GetRequiredService<IDataSeedIdentity>();
           await dataSeeed.SeedingDataIdsentityAsync();
            return app;
        }
        public static IApplicationBuilder UseCustomeExeptionHandlerMiddelWare(this IApplicationBuilder app)
        {
            // Custome Moddleware for Exception Handling
            app.UseMiddleware<CustomeExeptionHandlerMiddelWare>();
            return app;
        }

        public static IApplicationBuilder UseSwaggerMiddelWare(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            return app;
        }
    }
}
