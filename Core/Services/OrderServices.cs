using Domain.InterFace.IRepository;
using Domain.InterFace.UintOfWorks;
using Domain.Model;
using Domain.Model.Orders;
using ServicesAbstarction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrderServices
        (IBasketRepository _basketRepository,
        IUnitOfWork _unitOfWork)
        : IOrderServices
    {
        public async Task<Order?> CreateOrderAsync(string BuyerEmail, string BasketId, int DeliveyMethodId, Address ShippingAddress)
        {
            // GetBasket FromBasketRepo
            var Basket = await _basketRepository.GetCustomerBasketAsync(BasketId);

            // Get Select Item at Basket From Product Repo
            var OrderItems = new List<OrderItem>();
            if (Basket?.Items.Count > 0)
            {
                foreach (var item in Basket.Items)
                {
                    var ProductItem = await _unitOfWork.GetRepository<Product, int>().GetByIdAsync(item.Id); // GetProduct
                    ProductItemOrder ProductItemOrder = new ProductItemOrder(ProductItem.Id, ProductItem.Name, ProductItem.PictureUrl);
                    var Items = new OrderItem(item.Quantity, ProductItem.Price, ProductItemOrder);
                    OrderItems.Add(Items);
                }
            }

            // Calc SubTotal
            var SubTotal = OrderItems.Sum(item => item.Price * item.Quantity);

            // Get DeliveryMethod From Repo
            var DeliveryMethod = await _unitOfWork.GetRepository<DeliveryMethod, int>().GetByIdAsync(DeliveyMethodId);

            // Create Order
            var Order = new Order(BuyerEmail, ShippingAddress, DeliveryMethod, OrderItems, SubTotal);

            // Creete Order Locally
            await _unitOfWork.GetRepository<Order, int>().AddAsync(Order);

            // Save Order In DB
            var Result = await _unitOfWork.Complete();
            if (Result <= 0) return null;

            return Order;
        }

        public Task<Order> GetByOdOrderBySpecificUser(string BuyerEmail, int OrderId)
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetOrderBySpecificUser(string BuyerEmail)
        {
            throw new NotImplementedException();
        }
    }
}
