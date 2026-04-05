using AutoMapper;
using Domain.InterFace.IRepository;
using Domain.InterFace.UintOfWorks;
using ServicesAbstarction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceManger(IUnitOfWork unitOfWork , IMapper mapper , IBasketRepository basketRepository) : IServiceManger
    {
        // Not Create Object Only When Need It.
        private Lazy<IProductService> _lazyProductServcies = new Lazy<IProductService>(() => new ProductService(unitOfWork , mapper));
        public IProductService ProductService => _lazyProductServcies.Value;

        private Lazy<IBasketServices> _basketServices = new Lazy<IBasketServices>(() => new BasketServices(basketRepository,mapper));
        public IBasketServices BasketServices => _basketServices.Value;
    }
}
