using Domain.InterFace.IRepository;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.InterFace.UintOfWorks
{
    public interface IUnitOfWork
    {
        // Use this method to get the repository for a specific entity type and key type.
        // And Not Use aprpert each repo As Not Work Each Repo Create Obect
        IGenaricRepository<TEntity , TKey> GetRepository<TEntity , TKey>() where TEntity : BaseEntity<TKey>;
        Task<int> Complete();   // Returns the number of state entries written to the database.
    }
}
