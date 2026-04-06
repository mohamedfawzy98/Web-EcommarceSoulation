using Domain.InterFace.IRepository;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Presistence.Repositories
{
    public class CashRepository(IConnectionMultiplexer connection) : ICashRepository
    {
        private IDatabase _database = connection.GetDatabase();
        public async Task AddCashRepoAsync(string key, object response, TimeSpan? time)
        {
            if (response == null)
                return;
            var jsonresponse = JsonSerializer.Serialize(response);
            await _database.StringSetAsync(key, jsonresponse, time ?? TimeSpan.FromHours(2));
        }

        public async Task<string> GeTCashRepoAsync(string key)
        {
            var cash = await _database.StringGetAsync(key);
            if (cash.IsNullOrEmpty)
                return null;

            return cash.ToString();

        }
    }
}
