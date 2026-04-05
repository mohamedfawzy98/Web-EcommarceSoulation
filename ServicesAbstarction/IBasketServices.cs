using Shared.DTOS.BaketdDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesAbstarction
{
    public interface IBasketServices
    {
        Task<CustomerBasketDto?> GetCustomerBasketAsync(string Key);
        Task<bool> DeleteBasketAsync(string Id);
        Task<CustomerBasketDto?> CreateOrUpdateAsync(CustomerBasketDto basket);
    }
}
