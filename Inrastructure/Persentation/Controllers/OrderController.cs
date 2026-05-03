using AutoMapper;
using Domain.Model.Orders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServicesAbstarction;
using Shared.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Persentation.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class OrderController(IServiceManger _serviceManger , IMapper _mapper) : ControllerBase
    {

        // Ctreate Order 
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Order>> CreateOrder(OrderDto orderDto)
        {
            // BasketId , DeliveryMethodId , ShippingAddress

            // GetEmail 
            var Email = User.FindFirstValue(ClaimTypes.Email);
            var Adres = _mapper.Map<AddressDto, Address>(orderDto.ShippingAddress);
            var Order = await _serviceManger.OrderServices.CreateOrderAsync(Email, orderDto.BasketId, orderDto.DeliveryMethodId, Adres);
            if(Order == null) return BadRequest("Problem creating order");  
            return Ok(Order);
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            var Email = User.FindFirstValue(ClaimTypes.Email);
            var orders = await _serviceManger.OrderServices.GetOrderBySpecificUser(Email);
            if (orders == null) return NotFound("No orders found");
            return Ok(orders);
        }

        [HttpGet("{Id}")]
        [Authorize] 
        public async Task<ActionResult<Order?>> GetOrderById(int Id)
        {
            var Email = User.FindFirstValue(ClaimTypes.Email);
            var orders = await _serviceManger.OrderServices.GetByOdOrderBySpecificUser(Email,Id);
            if (orders == null) return NotFound("No orders found");
            return Ok(orders);
        }
    }
}
