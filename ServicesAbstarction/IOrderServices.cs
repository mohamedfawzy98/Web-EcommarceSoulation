using Domain.Model.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesAbstarction
{
    public interface IOrderServices
    {
        Task<Order> CreateOrderAsync(string BuyerEmail, string BasketId, int DeliveyMethodId, Address ShippingAddress);
        Task<Order> GetOrderBySpecificUser(string BuyerEmail);
        Task<Order> GetByOdOrderBySpecificUser(string BuyerEmail, int OrderId);
    }
}
