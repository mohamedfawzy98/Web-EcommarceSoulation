using Domain.InterFace.IRepository;
using Domain.Model.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Presistence.Repositories
{
    public class TokenRepository(IConfiguration _configuration) : ITokenRepository
    {
        public async Task<string> CreateTokenRepoAsync(ApplicationUser user, UserManager<ApplicationUser> userManager)
        {
            // Header (Alg , Type)
            // PayLoad
            // Signture

            // Create Claims [PayLoad]

            var authClaim = new List<Claim>()
            {
                new Claim(ClaimTypes.Email , user.Email),
                new Claim(ClaimTypes.GivenName , user.DispalyName),
                new Claim(ClaimTypes.MobilePhone , user.PhoneNumber),
            };


            var Roles = await userManager.GetRolesAsync(user);
            foreach (var item in Roles)
            {
                authClaim.Add(new Claim(ClaimTypes.Role, item));
                
            }

            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("JWT:Key"));
            var token = new JwtSecurityToken(  // first three Header (Alg , Type)
                issuer: _configuration["JWT:issuer"],
                audience: _configuration["JWT:audience"],
                expires: DateTime.Now.AddDays(double.Parse(_configuration["JWT:expire"])),
                claims: authClaim,
                signingCredentials : new SigningCredentials(Key, SecurityAlgorithms.HmacSha256Signature)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
