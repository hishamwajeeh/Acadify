using Acadify.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acadify.Infrastructure.InfrastructureBases
{
    public class GenericRepositoryAsync<T> : IGenericRepositoryAsync<T> where T : class
    {
        #region Vars / Props

        protected readonly ApplicationDbContext _dbContext;

        #endregion

        #region Constructor(s)


        public GenericRepositoryAsync(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion


        #region Methods / Actions

        // Retrieves an entity by its primary key (ID).
        // Use this when you need to find a specific record by its unique identifier.
        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }


        // Returns a queryable collection of entities with "No Tracking" enabled.
        // Use this for read-only operations to improve performance (EF won’t track changes).
        public IQueryable<T> GetTableNoTracking()
        {
            return _dbContext.Set<T>().AsNoTracking().AsQueryable();
        }


        // Adds multiple entities to the database asynchronously.
        // Use this when inserting a list or batch of new records.
        public virtual async Task AddRangeAsync(ICollection<T> entities)
        {
            await _dbContext.Set<T>().AddRangeAsync(entities);
            await _dbContext.SaveChangesAsync();
        }


        // Adds a single entity to the database asynchronously.
        // Use this when you need to insert a new record.
        public virtual async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }


        // Updates an existing entity in the database asynchronously.
        // Use this when you need to modify an existing record.
        public virtual async Task UpdateAsync(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }


        // Deletes a single entity from the database asynchronously.
        // Use this when removing one specific record.
        public virtual async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }


        // Deletes multiple entities from the database asynchronously.
        // Use this when removing a batch or collection of records.
        public virtual async Task DeleteRangeAsync(ICollection<T> entities)
        {
            foreach (var entity in entities)
            {
                _dbContext.Entry(entity).State = EntityState.Deleted;
            }
            await _dbContext.SaveChangesAsync();
        }


        // Saves all pending changes to the database asynchronously.
        // Use this after making multiple modifications when not using methods that already call SaveChangesAsync().
        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }


        // Begins a new database transaction.
        // Use this when you need multiple operations to succeed or fail together (atomic operations).
        public IDbContextTransaction BeginTransaction()
        {
            return _dbContext.Database.BeginTransaction();
        }


        // Commits the current database transaction.
        // Call this after all operations in a transaction succeed.
        public void Commit()
        {
            _dbContext.Database.CommitTransaction();
        }


        // Rolls back the current database transaction.
        // Call this to revert all changes if something fails during a transaction.
        public void RollBack()
        {
            _dbContext.Database.RollbackTransaction();
        }


        // Returns a queryable collection of entities **with tracking** enabled.
        // Use this when you plan to modify the returned entities.
        public IQueryable<T> GetTableAsTracking()
        {
            return _dbContext.Set<T>().AsQueryable();
        }


        // Updates multiple entities in the database asynchronously.
        // Use this when you need to modify several records at once.
        public virtual async Task UpdateRangeAsync(ICollection<T> entities)
        {
            _dbContext.Set<T>().UpdateRange(entities);
            await _dbContext.SaveChangesAsync();
        }

        #endregion

    }
}
