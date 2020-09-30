using Common.DTO.Interfaces;
using Common.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Facade
{
    public class CarFacade : ICarFacade
    {
        IUnitOfWork uow;
        IDialogService dialogService;
        INavigationAppService navService;

        public CarFacade(IUnitOfWork unitOfWork, IDialogService dialog, INavigationAppService navigation)
        {
            uow = unitOfWork;
            dialogService = dialog;
            navService = navigation;
        }

        public Task<ICarDTO> ChangeCar(ICarDTO car)
        {
            throw new NotImplementedException();
        }

        public async Task<ICarDTO> CreateNewCar()
        {
            var newcar = await dialogService.AddNewCarDialog();
            if (newcar != null)
            {
                using (IUnitOfWork uow = new UnitOfWork(dbPath))
                {
                    var cardto = await uow.CarRepository.AddAsync(newcar);
                    newcar = cardto;
                }
            }
            return newcar;
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
