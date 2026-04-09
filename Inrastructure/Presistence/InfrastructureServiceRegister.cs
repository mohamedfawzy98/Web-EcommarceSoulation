using Domain.InterFace;
using Domain.InterFace.IRepository;
using Domain.InterFace.UintOfWorks;
using Domain.Model.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Presistence.Data;
using Presistence.Data.Identity.Contexts;
using Presistence.Repositories;
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


            Services.AddDbContext<StoreIdentityDbContext>(op =>
            {
                op.UseSqlServer(Configuration.GetConnectionString("IdentityConnection"));
            });
            //     <FrameworkReference Include="Microsoft.AspNetCore.App" />  <!-- ✅ أضف هذا -->
            // ADD THIS TO WORK WITH IDENTITY
            Services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<StoreIdentityDbContext>();
            // Apply DataSeeding
            Services.AddScoped<IDataSeeed, DataSeed>();
            Services.AddScoped<IDataSeedIdentity, DataSeedIdentity>();
            Services.AddScoped<IUnitOfWork, UnitOfWork>();
            Services.AddScoped<IBasketRepository, BasketRepository>();
            Services.AddScoped<ICashRepository, CashRepository>();
            Services.AddScoped<ITokenRepository, TokenRepository>();
            Services.AddSingleton<IConnectionMultiplexer>( (_) =>
            {
              return  ConnectionMultiplexer.Connect(Configuration.GetConnectionString("RedisConnection"));
            });
            return Services;
        }
    }
}
