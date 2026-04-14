using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ServicesAbstarction.ExcaptionErrors;
using System.Diagnostics.Contracts;
using System.Text;

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

        public static IServiceCollection AddAuthenticationServices(
       this IServiceCollection services,
       IConfiguration _configuration)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = _configuration["JWT:Issuer"],
                    ValidateAudience = false,
                    ValidAudience = _configuration["JWT:audience"],
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]))
                };
            });

            return services;
        }
    }
}

