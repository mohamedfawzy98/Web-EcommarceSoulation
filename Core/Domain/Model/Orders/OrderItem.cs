using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Orders
{
    public class OrderItem : BaseEntity<int>
    {
        public OrderItem(int quantity, decimal price, ProductItemOrder product)
        {
            Quantity = quantity;
            Price = price;
            Product = product;
        }
        public OrderItem()
        {
            
        }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public ProductItemOrder Product { get; set; } = default!;
    }

    
}
