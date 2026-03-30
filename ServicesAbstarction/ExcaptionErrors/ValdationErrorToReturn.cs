using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ServicesAbstarction.ExcaptionErrors
{
    public class ValdationErrorToReturn
    {
        public int StatusCode { get; set; } = (int)HttpStatusCode.BadRequest;
        public string Message { get; set; } = "Validation Error";
        public IEnumerable<ValdationError> ValdationErrors = [];

    }
}
