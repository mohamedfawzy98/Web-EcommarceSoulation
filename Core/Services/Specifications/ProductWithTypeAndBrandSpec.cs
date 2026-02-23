using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Specifications
{
    internal class ProductWithTypeAndBrandSpec : BaseSpecification<Product, int>
    {
        public ProductWithTypeAndBrandSpec(int? brandId, int? typeId) : base(
            p => (!brandId.HasValue || p.ProductBrandId == brandId) && (!typeId.HasValue || p.ProductTypeId == typeId)
            )
        {
            AddInclude(p => p.ProductTypes);
            AddInclude(p => p.ProductBrands);
        }

        public ProductWithTypeAndBrandSpec(int id):base(p => p.Id ==id)
        {
            AddInclude(p => p.ProductTypes);
            AddInclude(p => p.ProductBrands);
        }
    }
}
