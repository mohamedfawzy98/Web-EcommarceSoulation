using AutoMapper;
using AutoMapper.Execution;
using Domain.Model;
using Microsoft.Extensions.Configuration;
using Shared.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ProfileMapping
{
    public class PictureResolver(IConfiguration _configuration) : IValueResolver<Product, ProductDto, string>
    {
        public string Resolve(Product source, ProductDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                return $"{_configuration.GetSection("URLS")["BaseURL"]}{source.PictureUrl}";
            }
            return string.Empty;
        }
    }
}
