using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logcast.Recruitment.Application.Interfaces.Base
{
    public interface IRepository<TEntity>
    {
        TEntity GetById(object id);
        Task<TEntity> GetByIdAsync(object id);

        void Insert(TEntity entity);
        Task InsertAsync(TEntity entity);
        void InsertRange(IEnumerable<TEntity> entities);
        Task InsertRangeAsync(IEnumerable<TEntity> entities);

        void Update(TEntity entityToUpdate);
        void UpdateRange(IEnumerable<TEntity> entities);

        void Delete(object id);
        void Delete(TEntity entityToDelete);
        void DeleteRange(IEnumerable<TEntity> items);


        // Commit Changes (not using UnitOfWork here)
        void Save();
        Task SaveAsync();
    }
}
