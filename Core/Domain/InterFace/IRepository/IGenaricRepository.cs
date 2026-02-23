using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.InterFace.IRepository
{
    public interface IGenaricRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        Task<TEntity> GetByIdAsync(TKey id);
        Task<IEnumerable<TEntity?>> GetAllAsync();
        Task<IEnumerable<TEntity?>> GetAllAsyncWithSpec(ISpecification<TEntity , TKey> specification);
        Task<TEntity> GetByIdAsyncWithSpec(ISpecification<TEntity, TKey> specification);
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);

    }
}
