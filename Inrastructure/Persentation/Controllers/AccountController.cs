using Domain.Model.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Persentation.Excetnation;
using ServicesAbstarction;
using Shared.DTOS;
using Shared.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Persentation.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AccountController(IServiceManger _serviceManger, UserManager<ApplicationUser> _userManager) : ControllerBase
    {
        [HttpPost("Login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto logindto)
        {
            
            var user = await _serviceManger.UserServices.LoginAsync(logindto);
            if (user is null)
                throw new Exception("UnAuth 401");

            return Ok(user);

        }
        [HttpPost("Registr")]
        public async Task<ActionResult<UserDto>> Registr(RegistrDto registrdto)
        {
            var user = await _serviceManger.UserServices.RgisterAsync(registrdto);
            if (user is null)
                throw new Exception("Please Enter Correct Data To Registr");

            return Ok(user);

        }

        [Authorize]
        [HttpGet("GeCurrentUser")]
        public async Task<ActionResult<UserDto>> GeCurrentUser()
        {
            var Email = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(Email);
            var Result = new UserDto()
            {
                DisplayName = user?.DispalyName ?? "",
                Email = user?.Email ?? "",
                Token = await _serviceManger.TokenServices.CreateTokenServices(user, _userManager)

            };

            return Ok(Result);
                }

        [Authorize]
        [HttpGet("Address")]
        public async Task<ActionResult<AddressDto>> GetAddress()
        {
            var GetAddress = await _userManager.FindUserByAddressAsync(User);

            var MappedAdderss = new AddressDto()
            {
                City = GetAddress.Addrees.City,
                Country = GetAddress.Addrees.Country,
                FName = GetAddress.Addrees.FName,
                LName = GetAddress.Addrees.LName,
                street = GetAddress.Addrees.street
            };

            return MappedAdderss;
        }
    }
}
