using Common.DTO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Facade
{
    interface ICarFacade
    {
        Task<List<ICarDTO>> GetCarList();
        Task<ICarDTO> CreateNewCar();
        Task<ICarDTO> ChangeCar(ICarDTO car);
        Task RemoveCar(int carId);
    }
}
