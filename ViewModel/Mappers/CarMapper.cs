using Common.DTO.Classes;
using Common.DTO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.ViewModels;

namespace ViewModel.Mappers
{
    public static class CarMapper
    {
        public static ICarDTO Map(ICarVM car)
        {
            CarDTO result = new CarDTO(car.Id);
            result.Title = car.Title;
            result.BuyPrice = car.BuyPrice;
            result.BuyDate = car.BuyDate;
            result.BuyMileage = car.BuyMileage;
            result.CurrentMileage = car.CurrentMileage;
            return result;
        }

        public static ICarVM Map(ICarDTO carDTO)
        {
            CarVM result = new CarVM();
            result.Id = carDTO.Id;
            result.Title = carDTO.Title;
            result.BuyPrice = carDTO.BuyPrice;
            result.BuyDate = carDTO.BuyDate;
            result.BuyMileage = carDTO.BuyMileage;
            result.CurrentMileage = carDTO.CurrentMileage;
            return result;
        }

        public static ICollection<ICarVM> Map(IList<ICarDTO> cars)
        {
            List<ICarVM> result = new List<ICarVM>(cars.Count);
            for (int i = 0; i < cars.Count; i++)
            {
                result.Add(Map(cars[i]));
            }
            return result;
        }
    }
}
