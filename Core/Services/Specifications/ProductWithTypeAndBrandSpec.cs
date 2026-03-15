using Domain.Model;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Specifications
{
    internal class ProductWithTypeAndBrandSpec : BaseSpecification<Product, int>
    {
        public ProductWithTypeAndBrandSpec(QueryPrames prames) : base(
            p => (!prames.brandId.HasValue || p.ProductBrandId == prames.brandId) && (!prames.typeId.HasValue || p.ProductTypeId == prames.typeId)
             && (string.IsNullOrWhiteSpace(prames.Search) || p.Name.ToLower().Contains(prames.Search.ToLower())))
        {
            AddInclude(p => p.ProductTypes);
            AddInclude(p => p.ProductBrands);

            // Add Sorting
            switch (prames.productSorting)
            {
                case ProductSortingEnum.NameAsc:
                    AddOrderBy(p => p.Name);
                    break;

                case ProductSortingEnum.NameDesc:
                    AddOrderByDescending(p => p.Name);
                    break;
                case ProductSortingEnum.PriceAsc:
                    AddOrderBy(p => p.Price);
                    break;
                case ProductSortingEnum.PriceDesc:
                    AddOrderByDescending(p => p.Price);
                    break;
                default:
                    break;
            }

            // Apply Pagination
            ApplyPagination(prames.PageSize, prames.PageIndex);
        }

        public ProductWithTypeAndBrandSpec(int id) : base(p => p.Id == id)
        {
            AddInclude(p => p.ProductTypes);
            AddInclude(p => p.ProductBrands);
        }
    }
}
