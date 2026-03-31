using Microsoft.AspNetCore.Mvc;
using ServicesAbstarction.ExcaptionErrors;
using System.Diagnostics.Contracts;

namespace Web_Ecommarce
{
    public static class ServicesRegister
    {
        public static IServiceCollection AddSwaggerervices(this IServiceCollection Services)
        {
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            Services.AddEndpointsApiExplorer();
            Services.AddSwaggerGen();

            return Services;
        }

        public static IServiceCollection AddWebApplcationServices(this IServiceCollection Services)
        {
            // Handle Valdation Error
            Services.Configure<ApiBehaviorOptions>(options =>
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
            return Services;
        }
    }
}
