using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class QueryPrames
    {
        public int? brandId { get; set; }
        public int? typeId { get; set; }
        public ProductSortingEnum productSorting { get; set; }
        public string? Search { get; set; }
    }
}
