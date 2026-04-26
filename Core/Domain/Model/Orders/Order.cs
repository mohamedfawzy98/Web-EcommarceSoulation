using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Orders
{
    public class Order : BaseEntity<int>
    {
        public string BuyerEmail { get; set; } = default!;
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
        // Status From Enum
        public OrderStatus Status { get; set; }
        // Object From Address
        public Address ShippingAddress { get; set; }
        // Relation Here One With DliveryMethod
        // By Conventaion Will Mapping In DB
        public DeliveryMethod deliveryMethod { get; set; }
        // Relation Here Many With OrderItems
        public ICollection<OrderItem> Items { get; set; } = [];
        public decimal SubTotal { get; set; }
        // Method Calac Total
        public decimal GetTotal => SubTotal + deliveryMethod.Cost;
        public string PaymentIntentId { get; set; } = string.Empty;

    }
}
