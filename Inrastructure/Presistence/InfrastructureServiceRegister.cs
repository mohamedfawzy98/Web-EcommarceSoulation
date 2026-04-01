using Domain.InterFace;
using Domain.InterFace.IRepository;
using Domain.InterFace.UintOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Presistence.Data;
using Presistence.UnitsWork;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Presistence
{
    public static class InfrastructureServiceRegister
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection Services , IConfiguration Configuration)
        {


           Services.AddDbContext<StoreDbContext>(op =>
            {
                op.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
            // Apply DataSeeding
            Services.AddScoped<IDataSeeed, DataSeed>();
            Services.AddScoped<IUnitOfWork, UnitOfWork>();
            Services.AddScoped<IBasketRepository, IBasketRepository>();
            Services.AddSingleton<IConnectionMultiplexer>( (_) =>
            {
              return  ConnectionMultiplexer.Connect(Configuration.GetConnectionString("RedisConnection")!);
            });
            return Services;
        }
    }
}
