using AutoMapper;
using Domain.Model.Basket;
using Shared.DTOS.BaketdDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ProfileMapping
{
    public class BasketProfile : Profile
    {
        public BasketProfile()
        {
            CreateMap<BasketItemDto , BasketItem>().ReverseMap();
            CreateMap<CustomerBasketDto , CustomerBasket>().ReverseMap();
        }
    }
}
