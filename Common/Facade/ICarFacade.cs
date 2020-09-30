using Common.DTO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Facade
{
    public interface ICarFacade
    {
        Task<List<ICarDTO>> GetCarList();
        /// <summary>Вызывает диалог для создания нового автомобиля, сохраняет его в БД</summary>
        /// <returns>Новый созданный автомобиль с ID или <see langword="null"/> в случае отмены диалога</returns>
        Task<ICarDTO> CreateNewCar();
        /// <summary>Вызвать диалог редактирования автомобиля, сохранить новый автомобиль в БД</summary>
        /// <param name="car">Изменяемый автомобиль</param>
        /// <returns>Измененный автомобиль или <see langword="null"/> в случае отмены диалога</returns>
        Task<ICarDTO> ChangeCar(ICarDTO car);
        Task RemoveCar(int carId);
    }
}
