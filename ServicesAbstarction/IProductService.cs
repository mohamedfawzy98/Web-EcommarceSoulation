using Shared;
using Shared.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesAbstarction
{
    public interface IProductService
    {
        // Get All Products
        Task<PaginationResult<ProductDto>> GetAllProductsAsync(QueryPrames prames); // Add Filtration  // Add Sorting

        // Get Product By Id
        Task<ProductDto> GetProductByIdAsync(int id);

        // Get All Brands
        Task<IEnumerable<BrandDto>> GetAllBrandsAsync();

        // Get All Types
        Task<IEnumerable<TypeDto>> GetAllTypesAsync();
    }
}
