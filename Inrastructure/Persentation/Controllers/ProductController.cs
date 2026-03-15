using Microsoft.AspNetCore.Mvc;
using ServicesAbstarction;
using Shared;
using Shared.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persentation.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductController(IServiceManger _serviceManger) : ControllerBase
    {
        // Get All Product
        [HttpGet]
        public async Task<ActionResult<PaginationResult<ProductDto>>> GetAllProducts([FromQuery]QueryPrames prames)
        {
            var Product = await _serviceManger.ProductService.GetAllProductsAsync(prames);
            return Ok(Product);
        }

        // Get Product By Id
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            var product = await _serviceManger.ProductService.GetProductByIdAsync(id);
            return Ok(product);
        }

        // Get All Types
        [HttpGet("Types")]
        public async Task<ActionResult<TypeDto>> GetAllTypes()
        {
            var Types = await _serviceManger.ProductService.GetAllTypesAsync();
            return Ok(Types);
        }
        // Get All Brands
        [HttpGet("Brands")]
        public async Task<ActionResult<BrandDto>> GetAllBrands()
        {
            var Brands = await _serviceManger.ProductService.GetAllBrandsAsync();
            return Ok(Brands);
        }
    }
}
