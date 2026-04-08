using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string? DispalyName { get; set; }
        public Address? Addrees { get; set; }
    }
}
