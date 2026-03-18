using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesAbstarction.ExcaptionErrors
{
    public class NotFoundProduct(int Id) : NotFoundExeption($"Product With Id {Id} Is Not Found")
    {
    }
}
