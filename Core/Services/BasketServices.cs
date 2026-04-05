using AutoMapper;
using Domain.InterFace.IRepository;
using Domain.Model.Basket;
using ServicesAbstarction;
using ServicesAbstarction.ExcaptionErrors;
using Shared.DTOS.BaketdDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BasketServices(IBasketRepository _basketRepository , IMapper _mapper) : IBasketServices
    {
        public async Task<CustomerBasketDto?> CreateOrUpdateAsync(CustomerBasketDto basket)
        {
            var mappedbasket = _mapper.Map<CustomerBasketDto , CustomerBasket>(basket);
            var CreatedOrUpdatedBasket = await  _basketRepository.CreateOrUpdateAsync(mappedbasket , null);
            if (CreatedOrUpdatedBasket is not null)
                return await GetCustomerBasketAsync(basket.Id);
            else
                throw new Exception($"The Created Or Update Not Completed");
        }

        public async Task<bool> DeleteBasketAsync(string Id) =>  await _basketRepository.DeleteBasketAsync(Id);
       

        public async Task<CustomerBasketDto?> GetCustomerBasketAsync(string Key)
        {
            var basket =  await _basketRepository.GetCustomerBasketAsync(Key);
            if (basket is not null)
                return _mapper.Map<CustomerBasket , CustomerBasketDto>(basket);
            else
                throw new BasketNotFoundExepection(Key);

        }
    }
}
