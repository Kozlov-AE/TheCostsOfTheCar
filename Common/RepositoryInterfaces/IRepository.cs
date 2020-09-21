using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Common.RepositoryInterfaces
{
    public interface IRepository <TDTO>
    {
        /// <summary>Записать приходящий из вне объект в репозиторий</summary>
        Task<TDTO> AddAsync(TDTO dto);
        /// <summary>Получить экземпляр из репозитория по его id</summary>
        Task<TDTO> GetByIdAsync(int id);
        /// <summary>Получить все экземпляры из репозитория</summary>
        Task<ICollection<TDTO>> GetAllAsync();
        /// <summary>Обновить экземпляр в репозитории. Если такого нет, то добавится новый</summary>
        Task<TDTO> UpdateAsync(TDTO dto);
        /// <summary>Удалить экземпляр из репозитория, зная его id</summary>
        void RemoveAsync(int id);
        /// <summary>Проверить есть ли в репозитории элементы</summary>
        Task<bool> Any();

    }
}
