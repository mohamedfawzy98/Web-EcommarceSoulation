using Domain.InterFace;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistence.Specifications
{
    public static class SpecificationEvalouter
    {
        public static IQueryable<TEntity> CreateQuery<TEntity, TKey>(IQueryable<TEntity> InputQuery, ISpecification<TEntity, TKey> specification) where TEntity : BaseEntity<TKey>
        {
            var Query = InputQuery;
            // Apply the criteria to the query if it exists
            if (specification.Criteria is not null)
            {
                Query = Query.Where(specification.Criteria);
            }

            // Apply the Sorting to the query if it exists
            if (specification.OrderBy is not null)
            {
                Query = Query.OrderBy(specification.OrderBy);
            }
            if (specification.OrderByDescending is not null)
            {
                Query = Query.OrderByDescending(specification.OrderByDescending);
            }

            //Apply Pagination
            if (specification.IsPaginged)
            {
                Query = Query.Skip(specification.Skip).Take(specification.Take);
            }

            // Apply the include expressions to the query if they exist
            if (specification.Include is not null && specification.Include.Count > 0)
            {
                Query = specification.Include.Aggregate(Query, (CurrentQuery, InExp) => CurrentQuery.Include(InExp));
            }

            return Query;
        }
    }
}
