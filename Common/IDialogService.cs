using Common.DTO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public interface IDialogService
    {
        Task<ICarDTO> AddNewCarDialog();
        Task<ICarDTO> ChangeCar(ICarDTO car);
    }
}
