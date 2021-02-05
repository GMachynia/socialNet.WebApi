using Microsoft.EntityFrameworkCore;
using socialNet.Data;
using socialNet.Repsitories.Interfaces.IRepository;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace socialNet.Repositories.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        internal readonly AppDbContext _appDbContext;
        internal readonly DbSet<T> _dbSet;
        public Repository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
            this._dbSet = _appDbContext.Set<T>();
        }

        public IQueryable<T> FindAll()
        {
            return this._dbSet.AsNoTracking();
        }
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this._dbSet.Where(expression).AsNoTracking();
        }
        public async Task AddAsync(T entity)
        {
            await this._dbSet.AddAsync(entity);
        }
        public void Update(T entity)
        {
            this._dbSet.Update(entity);
        }
        public void Delete(T entity)
        {
            this._dbSet.Remove(entity);
        }


    }
}
