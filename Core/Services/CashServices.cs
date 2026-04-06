using Domain.InterFace.IRepository;
using ServicesAbstarction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CashServices(ICashRepository _cashRepository) : ICashServices
    {
        public async Task AddCashAsync(string key, object response, TimeSpan? time) => await _cashRepository.AddCashRepoAsync(key, response, time);


        public async Task<string> GeTCashAsync(string key) => await _cashRepository.GeTCashRepoAsync(key);


    }
}
