using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.Identity;
using Microsoft.AspNetCore.Identity;

namespace Domain.InterFace.IRepository
{
    public interface IUserRepository
    {
        Task<ApplicationUser> LoginAsync(ApplicationUser user);
        Task<ApplicationUser> RegisterAsync(ApplicationUser user);

    }
}
