using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace A2SPA.Data.Repo
{
    public class Repository
    {
        protected Boolean Disposed;
        protected A2SPAContext DbContext;

        public Repository(A2SPAContext dbContext)
        {
            DbContext = dbContext;
        }

        public void Dispose()
        {
            if(!Disposed)
            {
                if(DbContext != null)
                {
                    DbContext.Dispose();

                    Disposed = true;
                }
            }
        }

        protected IQueryable<TEntity> Paging<TEntity>(int pageSize, int pageNumber) where TEntity : class
        {
            var query = DbContext.Set<TEntity>();

            return pageSize > 0 && pageNumber > 0 ? query.Skip((pageNumber - 1) * pageSize).Take(pageSize) : query;
        }

        protected IQueryable<TEntity> Paging<TEntity>(IQueryable<TEntity> query, int pageSize, int pageNumber) where TEntity : class
            => pageSize > 0 && pageNumber > 0 ? query.Skip((pageNumber - 1) * pageSize).Take(pageSize) : query;

        protected virtual void Add<TEntity>(TEntity entity) where TEntity : class
        {
            var cast = entity as IAuditEntity;

            if (cast != null)
            {
                if (!cast.CreateDtm.HasValue)
                {
                    cast.CreateDtm = DateTime.Now;
                }
            }

            var entry = DbContext.Entry(entity);

            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                var dbSet = DbContext.Set<TEntity>();

                dbSet.Add(entity);
            }
        }

        protected virtual void Update<TEntity>(TEntity entity, DbSet<TEntity> dbSet = null) where TEntity : class
        {
            var cast = entity as IAuditEntity;

            if (cast != null)
            {
                if (!cast.UpdateDtm.HasValue)
                {
                    cast.UpdateDtm = DateTime.Now;
                }
            }

            var entry = DbContext.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                dbSet?.Attach(entity);
            }

            entry.State = EntityState.Modified;
        }

        protected virtual void Remove<TEntity>(TEntity entity) where TEntity : class
        {
            var dbSet = DbContext.Set<TEntity>();

            var entry = DbContext.Entry(entity);

            if (entry.State == EntityState.Deleted)
            {
                dbSet.Attach(entity);
                dbSet.Remove(entity);
            }
            else
            {
                entry.State = EntityState.Deleted;
            }
        }

        public Int32 CommitChanges()
         => DbContext.SaveChanges();

        public Task<Int32> CommitChangesAsync()
         => DbContext.SaveChangesAsync();
    }
}
