using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Users
{
    public class RegistrDto
    {
        [Required(ErrorMessage ="DisplayName Is Requried!!")]
        public string DisplayName { get; set; } = default!;
        [Required(ErrorMessage = "Email Is Requried!!")]
        [EmailAddress]
        public string Email { get; set; } = default!;
        [Required(ErrorMessage = "Password Is Requried!!")]
        public string Password { get; set; } = default!;
        [Required(ErrorMessage = "PhoneNumber Is Requried!!")]
        public string PhoneNumber { get; set; } = default!; 
    }
}
