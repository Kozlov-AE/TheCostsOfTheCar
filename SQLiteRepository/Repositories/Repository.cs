using Common.RepositoryInterfaces;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteRepository.Repositories
{
    public abstract class Repository<TEntity, TDTO> : IRepository<TDTO> where TEntity : class, new()
    {
        protected SQLiteAsyncConnection context;

        public Repository(SQLiteAsyncConnection db)
        {
            context = db;
        }

        public abstract Task<TDTO> AddAsync(TDTO dto);

        public async Task<bool> Any() => (await context.Table<TEntity>().CountAsync()) > 0;

        public abstract Task<ICollection<TDTO>> GetAllAsync();

        public abstract Task<TDTO> GetByIdAsync(int id);

        public abstract void RemoveAsync(int id);

        public abstract Task<TDTO> UpdateAsync(TDTO dto);
    }
}
