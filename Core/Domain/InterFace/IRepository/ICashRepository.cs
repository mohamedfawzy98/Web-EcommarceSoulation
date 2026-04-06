using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.InterFace.IRepository
{
    public interface ICashRepository
    {
        Task<string> GeTCashRepoAsync(string key);
        Task AddCashRepoAsync(string key, object response, TimeSpan? time);
    }
}
