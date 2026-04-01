using Domain.InterFace.IRepository;
using Domain.Model.Basket;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Presistence.Repositories
{
    public class BasketRepository(IConnectionMultiplexer connection) : IBasketRepository
    {
        private IDatabase _database = connection.GetDatabase();
        public async Task<CustomerBasket?> CreateOrUpdateAsync(CustomerBasket basket, TimeSpan? TimeToLive)
        {
            var jsonbasket = JsonSerializer.Serialize(basket);
            bool IsCreatedOrUpdated =  await _database.StringSetAsync(basket.Id, jsonbasket, TimeToLive ?? TimeSpan.FromDays(30));
            if (IsCreatedOrUpdated)
                return await GetCustomerBasketAsync(basket.Id);
            else
                return null;
        }

        public async Task<bool> DeleteBasketAsync(string Id) => await _database.KeyDeleteAsync(Id);

        public async Task<CustomerBasket?> GetCustomerBasketAsync(string Key)
        {
            var basket = await _database.StringGetAsync(Key);
            if (!basket.IsNullOrEmpty)
              return  JsonSerializer.Deserialize<CustomerBasket?>(basket!);
            else
                return null;
        }
    }
}
