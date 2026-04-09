using Domain.Model.Identity;
using Microsoft.AspNetCore.Identity;
using ServicesAbstarction;
using Shared.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserServices
        (UserManager<ApplicationUser> _userManager 
        , SignInManager<ApplicationUser> _signInManager
        , ITokenServices _tokenServices)
        : IUserServices
    {
        public async Task<UserDto> LoginAsync(LoginDto loginDto)
        {
           
            return new UserDto()
            {
                DisplayName = user.DispalyName,
                Email = user.Email,
                Token = await  _tokenServices.CreateTokenServices(user,_userManager)
            };
        }

        public async Task<UserDto> RgisterAsync(RegistrDto registrDto)
        {
            

            return new UserDto()
            {
                DisplayName = user.DispalyName,
                Email = user.Email,
                Token = await _tokenServices.CreateTokenServices(user, _userManager)
            };

        }
    }
}
