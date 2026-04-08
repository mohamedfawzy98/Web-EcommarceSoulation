using Domain.Model.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.InterFace.IRepository
{
    public interface ITokenRepository
    {
        Task<string> CreateTokenRepoAsync(ApplicationUser user, UserManager<ApplicationUser> userManager);
    }
}
