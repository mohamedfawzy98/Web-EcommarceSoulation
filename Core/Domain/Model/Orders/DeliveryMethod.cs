using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Orders
{
    public class DeliveryMethod : BaseEntity<int>
    {
        public string ShortName { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string DelibveryTime { get; set; } = default!;
        public decimal Cost { get; set; }
    }
}
