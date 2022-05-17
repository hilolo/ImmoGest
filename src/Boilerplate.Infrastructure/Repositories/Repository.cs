using System;
using System.Linq;
using System.Threading.Tasks;
using ImmoGest.Domain.Core.Entities;
using ImmoGest.Domain.Core.Interfaces;
using ImmoGest.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ImmoGest.Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        public Repository(ApplicationDbContext dbContext)
        {
            Db = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            DbSet = Db.Set<TEntity>();
        }

        protected ApplicationDbContext Db { get; }

        protected DbSet<TEntity> DbSet { get; }

        public virtual IQueryable<TEntity> GetAll()
        { 

            return DbSet.AsNoTracking();
        }
        public virtual IQueryable<TEntity> GetAllFilter<IFilter>(IFilter filterOption) where IFilter : FilterOption
            => (!string.IsNullOrEmpty(filterOption.SearchQuery)) ? 
            DbSet.AsNoTracking().Where(e => e.SearchTerms.Contains(filterOption.SearchQuery)) :
             DbSet.AsNoTracking();
        


        public virtual async Task<TEntity> GetById(Guid id)
        {
            return await DbSet
                        .AsNoTracking()
                        .FirstOrDefaultAsync(e => e.Id == id);
        }

        public virtual TEntity Create(TEntity entity)
        {
            DbSet.Add(entity);
            return entity;
        }

        public virtual TEntity Update(TEntity entity)
        {
            DbSet.Update(entity);
            return entity;
        }

        public virtual async Task Delete(Guid id)
        {
            var entity = await DbSet.FindAsync(id);
            if (entity != null) DbSet.Remove(entity);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        protected virtual void Dispose(bool disposing)
        {
            if (disposing) Db.Dispose();
        }

    }
}
