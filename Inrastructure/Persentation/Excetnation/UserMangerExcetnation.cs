using Domain.Model.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Persentation.Excetnation
{
    public static class UserMangerExcetnation
    {
        public static async Task<ApplicationUser?>  FindUserByAddressAsync(this UserManager<ApplicationUser> userManager , ClaimsPrincipal User)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await userManager.Users.Include(u => u.Addrees).FirstOrDefaultAsync(x => x.Email == email);
            return user;
        }
    }
}
