using Microsoft.Extensions.DependencyInjection;
using Services.ProfileMapping;
using ServicesAbstarction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public static class ApplicationServiceRegister
    {
       public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // must Insatall In Services Layer 
            // AutoMapper.Extensions.Microsoft.DependencyInjection Pakages
            services.AddAutoMapper(x => x.AddProfile(new ProductProfile()));
            //builder.Services.AddAutoMapper(typeof(Services.AssemblyReference).Assembly);
            services.AddScoped<IServiceManger, ServiceManger>();
            services.AddScoped<PictureResolver>();

            return services;
        }
    }
}
