using Microsoft.AspNetCore.Mvc;
using ServicesAbstarction;
using Shared.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persentation.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AccountController(IServiceManger _serviceManger) : ControllerBase
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
    }
}
