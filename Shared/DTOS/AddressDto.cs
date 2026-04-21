using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOS
{
    public class AddressDto
    {
        //public int Id { get; set; }
        public string FName { get; set; } = default!;
        public string LName { get; set; } = default!;
        public string City { get; set; } = default!;
        public string Country { get; set; } = default!;
        public string? street { get; set; }
    }
}
