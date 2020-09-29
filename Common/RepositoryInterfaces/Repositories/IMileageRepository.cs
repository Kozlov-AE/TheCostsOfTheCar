using Common.DTO.Interfaces;
using Common.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.RepositoryInterfaces.Repositories
{
    public interface IMileageRepository : IRepository<IMileageDTO> 
    {
        /// <summary>Получить все показания одометра определенного типа для определенного автомобиля</summary>
        /// <param name="carid">ID автомобиля</param>
        /// <param name="type">Тип показаний</param>
        /// <returns></returns>
        Task<ICollection<IMileageDTO>> GetCarMilleagesByType(int carid, MileageTypeEnum type);
    }
}
