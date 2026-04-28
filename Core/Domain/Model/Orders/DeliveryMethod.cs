using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Orders
{
    public class DeliveryMethod : BaseEntity<int>
    {
        public DeliveryMethod(string shortName, string description, string delibveryTime, decimal cost)
        {
            ShortName = shortName;
            Description = description;
            DelibveryTime = delibveryTime;
            Cost = cost;
        }
        public DeliveryMethod()
        {
            
        }
        public string ShortName { get; set; }
        public string Description { get; set; } 
        public string DelibveryTime { get; set; } 
        public decimal Cost { get; set; }
    }
}
