using Domain.InterFace;
using Domain.InterFace.IRepository;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Presistence.Data;
using Presistence.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistence.Repositories
{
    public class GenaricRepository<TEntity, TKey>(StoreDbContext _dbContext) : IGenaricRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        public async Task<IEnumerable<TEntity?>> GetAllAsync() => await _dbContext.Set<TEntity>().ToListAsync();

        public async Task<TEntity> GetByIdAsync(TKey id) => await _dbContext.Set<TEntity>().FindAsync(id);
        public async Task AddAsync(TEntity entity) => await _dbContext.Set<TEntity>().AddAsync(entity);

        public void Delete(TEntity entity) => _dbContext.Set<TEntity>().Remove(entity);


        public void Update(TEntity entity) => _dbContext.Set<TEntity>().Update(entity);

        public async Task<IEnumerable<TEntity?>> GetAllAsyncWithSpec(ISpecification<TEntity, TKey> specification)
        {
            return await SpecificationEvalouter.CreateQuery(_dbContext.Set<TEntity>() ,specification).ToListAsync();
        }

        public async Task<TEntity> GetByIdAsyncWithSpec(ISpecification<TEntity, TKey> specification)
        {
            return await SpecificationEvalouter.CreateQuery(_dbContext.Set<TEntity>() , specification).FirstOrDefaultAsync();
        }

        public async Task<int> GetCountAsync(ISpecification<TEntity, TKey> specification)
        => await SpecificationEvalouter.CreateQuery(_dbContext.Set<TEntity>(), specification).CountAsync();
    }
}
