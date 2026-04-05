using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesAbstarction.ExcaptionErrors
{
    public class BasketNotFoundExepection(string Id) : NotFoundExeption($"Basket With Id {Id} Is Not Found")
    {
    }
}
