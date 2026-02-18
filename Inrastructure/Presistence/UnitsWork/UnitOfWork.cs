using Domain.InterFace.IRepository;
using Domain.InterFace.UintOfWorks;
using Domain.Model;
using Presistence.Data;
using Presistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistence.UnitsWork
{
    public class UnitOfWork(StoreDbContext _dbContext) : IUnitOfWork
    {
        private readonly Dictionary<string, object> _repositories = [];
        public IGenaricRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {
            // Get Type
            var type = typeof(TEntity).Name;
            // Check if the repository exist
            if (_repositories.TryGetValue(type, out object? value))
                return (IGenaricRepository<TEntity, TKey>)value;
            else
            {
                // Create object of repository
                var repo = new GenaricRepository<TEntity, TKey>(_dbContext);
                // Add repository to dictionary
                _repositories["type"] = repo;
                // Return repository
                return repo;
            }
        }
        public async Task<int> Complete() => await _dbContext.SaveChangesAsync();
    }
}
