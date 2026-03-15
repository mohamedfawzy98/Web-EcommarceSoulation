using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.InterFace
{
    public interface ISpecification<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        Expression<Func<TEntity, bool>>? Criteria { get; }  // Take a lambda exp to filter the data Take  entity return bool
        List<Expression<Func<TEntity, object>>> Include { get; } // Take a lambda exp to include the related data Take entity return object
        Expression<Func<TEntity, object>>? OrderBy { get; } // Take a lambda exp to order the data Take entity return object    
        Expression<Func<TEntity, object>>? OrderByDescending { get; } // Take a lambda exp to order the data in descending order Take entity return object
       // To Pagination
        public int Take { get; }
        public int Skip { get; }
        public bool IsPaginged { get; set; }
    }
}
