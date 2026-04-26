using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Orders
{
    public class OrderItem : BaseEntity<int>
    {
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public ProductItemOrder Product { get; set; } = default!;
    }

    
}
