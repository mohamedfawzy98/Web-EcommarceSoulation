using AutoMapper;
using Domain.Model;
using Shared.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ProfileMapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(dist => dist.ProductBrandName, option => option.MapFrom(src => src.ProductBrands.Name))
                .ForMember(dist => dist.ProductTypeName, option => option.MapFrom(src => src.ProductTypes.Name))
                .ForMember(dist => dist.PictureUrl, option => option.MapFrom<PictureResolver>());  // to Add BaseUrl

            CreateMap<ProductBrands, BrandDto>();
            CreateMap<ProductTypes, TypeDto>();
        }
    }
}
