using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace socialNet.Repsitories.Interfaces.IRepository
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        void Update(T entity);
        void Delete(T entity);
        Task AddAsync(T entity);
    }

}
