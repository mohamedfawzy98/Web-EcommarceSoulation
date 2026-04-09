using Domain.InterFace.IRepository;
using Domain.Model.Identity;
using Microsoft.AspNetCore.Identity;
using ServicesAbstarction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class TokenServices(ITokenRepository _tokenRepository) : ITokenServices
    {
        public async Task<string> CreateTokenServices(ApplicationUser user, UserManager<ApplicationUser> userManager)
       
        =>  await  _tokenRepository.CreateTokenRepoAsync(user, userManager);
        

    }
}
