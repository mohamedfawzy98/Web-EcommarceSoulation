using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOS.BaketdDtos
{
    public class BasketItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        [Range(1, int.MaxValue, ErrorMessage = "Price must be at least 1.")]
        public decimal Price { get; set; }
        [Range(1, 100, ErrorMessage = "Quantity must be at least 1.")]
        public int Quantity { get; set; }
        public string PictureUrl { get; set; } = default!;
    }
}
