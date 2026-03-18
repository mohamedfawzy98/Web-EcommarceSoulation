using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesAbstarction.ExcaptionErrors
{
    public class NotFoundExeption(string Message) : Exception(Message)
    {

    }
}
