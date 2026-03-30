using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ServicesAbstarction.ExcaptionErrors
{
    public class ValdationError
    {
        public string Filed { get; set; } = default!;
        public IEnumerable<string> Errors { get; set; } = [];
       
    }
}
