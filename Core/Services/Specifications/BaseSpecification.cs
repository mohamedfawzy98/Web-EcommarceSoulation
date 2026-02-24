using Domain.InterFace;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Specifications
{
    abstract class BaseSpecification<TEntity, TKey> : ISpecification<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {

        public Expression<Func<TEntity, bool>>? Criteria { get; private set; }
        protected BaseSpecification(Expression<Func<TEntity, bool>>? expression)
        {
            Criteria = expression;
        }
        #region Include
        public List<Expression<Func<TEntity, object>>> Include { get; private set; } = []; // Inatialize the Include list to an empty list

        public void AddInclude(Expression<Func<TEntity, object>> includeExpression)
        {
            Include.Add(includeExpression);
        }
        #endregion

        #region Sorting
        public Expression<Func<TEntity, object>>? OrderBy { get; private set; }
        protected void AddOrderBy(Expression<Func<TEntity, object>> orderBy) =>  OrderBy = orderBy;
        public Expression<Func<TEntity, object>>? OrderByDescending { get; private set; }
        protected void AddOrderByDescending(Expression<Func<TEntity, object>> orderByDescending) => OrderByDescending = orderByDescending;

        #endregion

    }
}
