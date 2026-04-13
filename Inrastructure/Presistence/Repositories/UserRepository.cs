using Domain.InterFace.IRepository;
using Domain.Model.Identity;
using Microsoft.AspNetCore.Identity;
using ServicesAbstarction;
using Shared.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistence.Repositories
{
    public class UserRepository(UserManager<ApplicationUser> _userManager
        , SignInManager<ApplicationUser> _signInManager
        ) : IUserRepository
    {
        public async Task<ApplicationUser> LoginAsync(ApplicationUser user)
        {
            // CHECK Email
            var users = await _userManager.FindByEmailAsync(user.Email);
            if (users == null) return null;
            // Check Password
            var Result = await _signInManager.CheckPasswordSignInAsync(users, user.PasswordHash, false);
            if (!Result.Succeeded)
                return null;

            return users;
        }

        public async Task<ApplicationUser> RegisterAsync(ApplicationUser user)
        {
            var CheckEmail = await _userManager.FindByEmailAsync(user.Email);
            if (CheckEmail is not null) return null;

            var userApp = new ApplicationUser()
            {
                DispalyName = user.DispalyName,
                Email = user.Email,
                UserName = user.Email.Split('@')[0],
                PhoneNumber = user.PhoneNumber,
            };

            var Result = await _userManager.CreateAsync(userApp, user.PasswordHash);
            if (!Result.Succeeded)
                return null;

            return userApp;
        }
    }
}
