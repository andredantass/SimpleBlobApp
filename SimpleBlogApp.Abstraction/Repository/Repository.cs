using Microsoft.EntityFrameworkCore;
using SimpleBlogApp.Abstraction.Domain;
using SimpleBlogApp.Abstraction.Interface;

namespace SimpleBlogApp.Abstraction.Repository
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly DbContext Context;
        protected readonly DbSet<T> DbSet;

        public Repository(DbContext context)
        {
            Context = context;
            DbSet = Context.Set<T>();
        }
        public virtual async Task AddAsync(T entity)
        {
            await DbSet.AddAsync(entity);
        }

        public virtual void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }

        public virtual async Task<T?> GetByIdAsync(string id)
        {
            return await DbSet.FindAsync(id);
        }

        public Task SaveChangesAsync()
        {
            return Context.SaveChangesAsync();
        }

        public virtual void Update(T entity)
        {
            var entityEntry = Context.Entry(entity);
            DbSet.Update(entity);
        }
    }
}
