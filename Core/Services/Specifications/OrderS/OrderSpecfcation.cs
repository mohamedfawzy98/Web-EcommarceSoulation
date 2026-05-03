using Domain.Model.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Specifications.OrderS
{
    class OrderSpecification : BaseSpecification<Order, int>
    {
        public OrderSpecification(string BuyerEmail) : base(o => o.BuyerEmail == BuyerEmail)
        {
            Include.Add(o => o.Items);
            Include.Add(o => o.deliveryMethod);
            AddOrderByDescending(o => o.OrderDate);
        }

        public OrderSpecification(string email , int id) : base(o => o.BuyerEmail == email && o.Id == id)
        {
            Include.Add(o => o.Items);
            Include.Add(o => o.deliveryMethod);
        }
    }
}

