using AutoMapper;
using Domain.InterFace.UintOfWorks;
using Domain.Model;
using Services.Specifications;
using ServicesAbstarction;
using Shared;
using Shared.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService(IUnitOfWork _unitOfWork, IMapper _mapper) : IProductService
    {
        public async Task<PaginationResult<ProductDto>> GetAllProductsAsync(QueryPrames prames)
        {
            var repo = _unitOfWork.GetRepository<Product, int>();
            //var Product = await repo.GetAllAsync();
            var spec = new ProductWithTypeAndBrandSpec(prames);
            var Product = await repo.GetAllAsyncWithSpec(spec);          
            var productDtos = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(Product);
            var CountProduct = productDtos.Count();
            var CountSpec = new ProductCountSpec(prames);
            var GetAllCount = await repo.GetCountAsync(CountSpec);
            return new PaginationResult<ProductDto>(CountProduct,prames.PageIndex, GetAllCount, productDtos);
        }
        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var spec = new ProductWithTypeAndBrandSpec(id);
            var ProductId = await _unitOfWork.GetRepository<Product, int>().GetByIdAsyncWithSpec(spec);
            //var ProductId = await _unitOfWork.GetRepository<Product, int>().GetByIdAsync(id);
            var productDto = _mapper.Map<Product, ProductDto>(ProductId);
            return (productDto);
        }
        public async Task<IEnumerable<BrandDto>> GetAllBrandsAsync()
        {
            var Brand = await _unitOfWork.GetRepository<ProductBrands, int>().GetAllAsync();
            var BrandDto = _mapper.Map<IEnumerable<ProductBrands>, IEnumerable<BrandDto>>(Brand);

            return BrandDto;
        }


        public async Task<IEnumerable<TypeDto>> GetAllTypesAsync()
        {
            var type = await _unitOfWork.GetRepository<ProductTypes, int>().GetAllAsync();
            var typeDto = _mapper.Map<IEnumerable<ProductTypes>, IEnumerable<TypeDto>>(type);
            return typeDto;
        }

    }
}
