using Domain.Model;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Azure.Core.HttpHeader;

namespace Services.Specifications
{
    internal class ProductCountSpec : BaseSpecification<Product , int>
    {
        public ProductCountSpec(QueryPrames prames) : base(
        p => (!prames.brandId.HasValue || p.ProductBrandId == prames.brandId) && (!prames.typeId.HasValue || p.ProductTypeId == prames.typeId)
        && (string.IsNullOrWhiteSpace(prames.Search) || p.Name.ToLower().Contains(prames.Search.ToLower())))
        {

        }
    }
}
