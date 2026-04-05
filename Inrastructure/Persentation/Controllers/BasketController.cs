using Microsoft.AspNetCore.Mvc;
using ServicesAbstarction;
using Shared.DTOS.BaketdDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persentation.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class BasketController(IServiceManger _serviceManger) : ControllerBase
    {
        // Get Basket By Id
        [HttpGet("{key}")]
        public async Task<ActionResult<CustomerBasketDto>> GetItem(string Key)
        {
            var bakset = await _serviceManger.BasketServices.GetCustomerBasketAsync(Key);
            return Ok(bakset);
        }

        // Create Or Update Basket
        [HttpPost]
        public async Task<ActionResult<CustomerBasketDto>> CraeteOrUpdateBasket(CustomerBasketDto basketDto)
        {
            var CreateOrUpdate = await _serviceManger.BasketServices.CreateOrUpdateAsync(basketDto);
            return Ok(CreateOrUpdate);
        }

        // Delete Basket
        [HttpDelete("{key}")]
        public async Task<ActionResult> DeleteBasket(string Key)
        {
            var IsDeleted = await _serviceManger.BasketServices.DeleteBasketAsync(Key);
            return Ok(IsDeleted);
        }
    }
}
