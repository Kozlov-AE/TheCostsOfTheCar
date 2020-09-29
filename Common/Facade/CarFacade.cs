using Common.DTO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Facade
{
    public class CarFacade : ICarFacade
    {
        public Task<ICarDTO> ChangeCar(ICarDTO car)
        {
            throw new NotImplementedException();
        }

        public Task<ICarDTO> CreateNewCar()
        {
            throw new NotImplementedException();
        }

        public Task<List<ICarDTO>> GetCarList()
        {
            throw new NotImplementedException();
        }

        public Task RemoveCar(int carId)
        {
            throw new NotImplementedException();
        }
    }
}
