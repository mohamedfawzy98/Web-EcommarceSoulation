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

namespace Services
{
    public class UserServices
        (UserManager<ApplicationUser> _userManager
        , ITokenRepository _tokenRepository, IUserRepository _userRepository)
        : IUserServices
    {
        public async Task<UserDto> LoginAsync(LoginDto loginDto)
        {
            var AppUser = new ApplicationUser()
            {
                Email = loginDto.Email,
                PasswordHash = loginDto.Password,

            };
            var user = await _userRepository.LoginAsync(AppUser);
            if (user != null)
            {
                return new UserDto()
                {
                    DisplayName = user?.DispalyName ?? "",
                    Email = user?.Email ?? "",
                    Token = await _tokenRepository.CreateTokenRepoAsync(user, _userManager)
                };
            }
            else
                return new UserDto();
        }

        public async Task<UserDto> RgisterAsync(RegistrDto registrDto)
        {
            var AppUser = new ApplicationUser()
            {
                Email = registrDto.Email,
                PasswordHash = registrDto.Password,
                DispalyName = registrDto.DisplayName,
                PhoneNumber = registrDto.PhoneNumber

            };

            var user = await _userRepository.RegisterAsync(AppUser);

            if (user is not null)
            {
                return new UserDto()
                {
                    DisplayName = user?.DispalyName ?? "",
                    Email = user?.Email ?? "",
                    Token = await _tokenRepository.CreateTokenRepoAsync(user, _userManager)
                };
            }
            else
                return new UserDto();

        }
    }
}
