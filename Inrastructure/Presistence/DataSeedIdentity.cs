using Domain.InterFace;
using Domain.Model.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Presistence.Data.Identity.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistence
{
    public class DataSeedIdentity(StoreIdentityDbContext _identityDbContext, UserManager<ApplicationUser> _userManager) : IDataSeedIdentity
    {
        public async Task SeedingDataIdsentityAsync()
        {
            var Mig = await _identityDbContext.Database.GetPendingMigrationsAsync();
            if (Mig.Any())
            {
                await _identityDbContext.Database.MigrateAsync();
            }
          

            await _identityDbContext.Database.MigrateAsync();
            if (!_userManager.Users.Any())
            {
                var user = new ApplicationUser
                {
                    DispalyName = "Mohamed Fawzy",
                    Email = "m@gmail.com",
                    PhoneNumber = "011987653763",
                    UserName = "m@gmail.com",
                    Addrees = new Address
                    {
                        FName = "Mohamed",
                        LName = "Fawzy",
                        Country = "Egypt",
                        City = "Cairo",

                    },
                };

                var result = await _userManager.CreateAsync(user, "M12345678@m");
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        Console.WriteLine($"Error: {error.Code} - {error.Description}");
                    }
                }
            }
        }
    }
}
