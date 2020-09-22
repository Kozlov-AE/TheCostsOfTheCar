using Common;
using Common.DTO.Classes;
using Common.DTO.Interfaces;
using Common.RepositoryInterfaces;
using SQLiteRepository.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ViewModel.DialogServices;
using ViewModel.Mappers;
using ViewModel.ViewModels;

namespace ViewModel.Facades
{
    /// <summary>
    /// Методы работы с использованием базы данных и сервисов навигации и диалоговых окон
    /// </summary>
    public class GarageFacade : IGarageFacade
    {
        string dbPath;
        IDialogService dialogService;
        INavigationAppService navService;

        public GarageFacade(string dbPath, IDialogService dialogService, INavigationAppService nav)
        {
            this.dbPath = dbPath;
            this.dialogService = dialogService;
            navService = nav;
        }

        public async Task<ICarVM> CreateNewCar()
        {
            var newcar = await dialogService.AddNewCarDialog();
            using (IUnitOfWork uow = new UnitOfWork(dbPath))
            {
                var cardto = await uow.CarRepository.AddAsync(CarMapper.Map(newcar));
                newcar = CarMapper.Map(cardto);
            }
            return newcar;
        }

        public async Task<ICarVM> ChangeCar(ICarVM car)
        {
            var changedcar = await dialogService.ChangeCar(car);
            if (changedcar != car)
            {
                using (IUnitOfWork uow = new UnitOfWork(dbPath))
                {
                    var cCar = await uow.CarRepository.UpdateAsync(CarMapper.Map(changedcar));
                    changedcar = CarMapper.Map(cCar);
                }
                return changedcar;
            }
            else return null;
        }

        public async Task GoToMainPage(int id)
        {
            await navService.GoToMainCarPage(id);
        }

        public async Task<List<ICarDTO>> GetCarList()
        {
            using (IUnitOfWork uow = new UnitOfWork(dbPath))
            {
                var r = await uow.CarRepository.GetAllAsync();
                return r.ToList();
            }
        }

        public void RemoveCar(int carId)
        {
            using (IUnitOfWork uow = new UnitOfWork(dbPath))
            {
                uow.CarRepository.RemoveAsync (carId);
            }
        }
    }
}
