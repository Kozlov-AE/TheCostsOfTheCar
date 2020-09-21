using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Common.RepositoryInterfaces
{
    public interface ITestRepository<TEntity, TDTO> where TEntity : class, new()
    {
        Task<List<TDTO>> Get();
        Task<TDTO> Get(int id);
        Task<List<TDTO>> Get<TValue>(Expression<Func<TEntity, bool>> predicate = null, Expression<Func<TEntity, TValue>> orderBy = null);
        Task<TDTO> Get(Expression<Func<TEntity, bool>> predicate);
        Task<int> Insert(TDTO entity);
        Task<int> Update(TDTO entity);
        Task<int> Delete(TDTO entity);
    }
}
