using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class QueryPrames
    {
        private const int DefaultValue = 5;
        private const int MaxValue = 10;
        public int? brandId { get; set; }
        public int? typeId { get; set; }
        public ProductSortingEnum productSorting { get; set; }
        public string? Search { get; set; }
        public int PageIndex { get; set; } = 1;
        private int pagesize = DefaultValue;

        public int PageSize
        {
            get { return pagesize; }
            set { pagesize = value > MaxValue ? MaxValue : value; }
        }

    }
}
