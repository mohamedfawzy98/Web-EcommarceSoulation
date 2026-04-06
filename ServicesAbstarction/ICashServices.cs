using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesAbstarction
{
    public interface ICashServices
    {
        Task<string> GeTCashAsync(string key);
        Task AddCashAsync(string key , object response , TimeSpan? time);

    }
}
