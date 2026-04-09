using Domain.Model.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesAbstarction
{
    public interface ITokenServices
    {
       Task<string> CreateTokenServices(ApplicationUser user , UserManager<ApplicationUser> userManager); 
    }
}
