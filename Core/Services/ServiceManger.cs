using AutoMapper;
using Domain.InterFace.IRepository;
using Domain.InterFace.UintOfWorks;
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
    public class ServiceManger(IUnitOfWork unitOfWork, IMapper mapper,
        IBasketRepository basketRepository, ICashRepository cashRepository
        , ITokenRepository _tokenRepository, UserManager<ApplicationUser> userManager
        , IUserRepository _userRepository)
        : IServiceManger
    {
        // Not Create Object Only When Need It.
        private Lazy<IProductService> _lazyProductServcies = new Lazy<IProductService>(() => new ProductService(unitOfWork, mapper));
        public IProductService ProductService => _lazyProductServcies.Value;

        private Lazy<IBasketServices> _basketServices = new Lazy<IBasketServices>(() => new BasketServices(basketRepository, mapper));
        public IBasketServices BasketServices => _basketServices.Value;
        private Lazy<ICashServices> _cashServices = new Lazy<ICashServices>(() => new CashServices(cashRepository));
        public ICashServices CashServices => _cashServices.Value;
        private Lazy<ITokenServices> _tokenServices = new Lazy<ITokenServices>(() => new TokenServices(_tokenRepository));
        public ITokenServices TokenServices => _tokenServices.Value;
        private Lazy<IUserServices> _userServices = new Lazy<IUserServices>(() => new UserServices(userManager, _tokenRepository, _userRepository));

        public IUserServices UserServices => _userServices.Value;
    }
}
