using Common.DTO.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using ViewModel.ViewModels;

namespace ViewModel.Facades
{
    public interface IGarageFacade
    {
        Task<List<ICarDTO>> GetCarList();
        Task<ICarVM> CreateNewCar();
        Task<ICarVM> ChangeCar(ICarVM car);
        Task GoToMainPage(int id);
        void RemoveCar(int carId);
    }
}
