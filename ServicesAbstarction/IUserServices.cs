using Shared.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesAbstarction
{
    public interface IUserServices
    {
        Task<UserDto> LoginAsync(LoginDto loginDto);
        Task<UserDto> RgisterAsync(RegistrDto registrDto);
    }
}
