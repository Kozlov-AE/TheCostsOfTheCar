using Common.DTO.Interfaces;
using Common.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.RepositoryInterfaces.Repositories
{
    public interface IMileageRepository : IRepository<IMileageDTO> 
    {
        Task<ICollection<IMileageDTO>> GetCarMilleagesByType(int carid, MileageTypeEnum type);
    }
}
