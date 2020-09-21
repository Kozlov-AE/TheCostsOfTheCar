using Common.DTO.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using ViewModel.ViewModels;

namespace ViewModel.DialogServices
{
    public interface IDialogService
    {
        Task<ICarVM> AddNewCarDialog();
        Task<ICarVM> ChangeCar(ICarVM car);
        //ICarVM AddNewCarDialog();

    }
}
