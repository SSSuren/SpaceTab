using Logcast.Recruitment.Application.Interfaces.Base;
using Logcast.Recruitment.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logcast.Recruitment.DataAccess.Repositories.Base
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected IDbContext _context;
        protected DbSet<TEntity> _dbSet;

        public Repository(IDbContext dbContext)
        {
            _context = dbContext;
            _dbSet = _context.Set<TEntity>();
        }

        public void Delete(object id)
        {
            var entityToDelete = _dbSet.Find(id);
            Delete(entityToDelete);
        }

        public void Delete(TEntity entityToDelete)
        {
            if ((_context as DbContext).Entry(entityToDelete).State == EntityState.Detached)
                _dbSet.Attach(entityToDelete);

            _dbSet.Remove(entityToDelete);
        }

        public void DeleteRange(IEnumerable<TEntity> items)
        {
            if (items == null || !items.Any()) return;

            foreach (var item in items)
                _dbSet.Attach(item);

            _dbSet.RemoveRange(items);
        }

        public TEntity GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public Task<TEntity> GetByIdAsync(object id)
        {
            return _dbSet.FindAsync(id).AsTask();
        }

        public void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public Task InsertAsync(TEntity entity)
        {
            return _dbSet.AddAsync(entity).AsTask();
        }

        public void InsertRange(IEnumerable<TEntity> entities)
        {
            _dbSet.AddRange(entities);
        }

        public Task InsertRangeAsync(IEnumerable<TEntity> entities)
        {
            return _dbSet.AddRangeAsync(entities);
        }

        public void Update(TEntity entityToUpdate)
        {
            _dbSet.Update(entityToUpdate);
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            _dbSet.UpdateRange(entities);
        }

        public void Save()
        {
            foreach (var item in (_context as DbContext).ChangeTracker.Entries())
            {
                if (item.State == EntityState.Added || item.State == EntityState.Modified)
                {
                    bool creating = item.State == EntityState.Added;
                    SetTrackingData(item.Entity as BaseEntity, creating);
                }
            }

            (_context as DbContext).SaveChanges();
        }

        public async Task SaveAsync()
        {
            foreach (var item in (_context as DbContext).ChangeTracker.Entries())
            {
                if (item.State == EntityState.Added || item.State == EntityState.Modified)
                {
                    bool creating = item.State == EntityState.Added;
                    SetTrackingData(item.Entity as BaseEntity, creating);
                }
            }

            await (_context as DbContext).SaveChangesAsync();
        }

        protected void SetTrackingData(BaseEntity entity, bool creating)
        {
            if (creating)
            {
                entity.IsActive = true;
                entity.CreatedDate = DateTime.UtcNow;
            }
            entity.UpdatedDate = DateTime.UtcNow;
        }
    }
}
