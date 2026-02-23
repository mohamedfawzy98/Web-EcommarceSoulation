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
        public static IQueryable<TEntity> CreateQuery<TEntity , TKey> (IQueryable<TEntity> InputQuery , ISpecification<TEntity,TKey> specification) where TEntity : BaseEntity<TKey>
        {
            var Query = InputQuery;
            if(specification.Criteria is not null)
            {
                Query = Query.Where(specification.Criteria);
            }
            if(specification.Include is not null && specification.Include.Count > 0)
            {
                Query = specification.Include.Aggregate(Query , (CurrentQuery , InExp) => CurrentQuery.Include(InExp)); 
            }

            return Query;
        }
    }
}
