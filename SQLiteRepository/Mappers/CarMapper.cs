using Common.DTO.Classes;
using Common.DTO.Interfaces;
using SQLiteRepository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLiteRepository.Mappers
{
    public static class CarMapper
    {
        public static ICarDTO Map (Car car)
        {
            ICarDTO result = new CarDTO(car.Id);
            result.Title = car.Title;
            result.BuyPrice = car.BuyPrice;
            result.BuyDate = car.BuyDate;
            result.BuyMileage = car.BuyMileage.Count;
            result.CurrentMileage = car.CurrentMileage.Count;
            return result;
        }

        public static ICollection<ICarDTO> Map (IList<Car> cars)
        {
            //cars.ForEach(c => carsDTO.Add(CarMapper.Map(c))); - Почитал, for() типа быстрее на маленьких количествах
            List<ICarDTO> result = new List<ICarDTO>();
            for (int i = 0; i < cars.Count; i++)
            {
                result.Add(CarMapper.Map(cars[i]));
            }
            return result;
        }

        public static Car Map (ICarDTO carDTO)
        {
            Car result = new Car();
            result.Id = carDTO.Id;
            result.Title = carDTO.Title;
            result.BuyPrice = carDTO.BuyPrice;
            result.BuyDate = carDTO.BuyDate;
            return result;
        }

        public static ICollection<Car> Map(IList<ICarDTO> cars)
        {
            List<Car> result = new List<Car>();
            for (int i = 0; i < cars.Count; i++)
            {
                result.Add(CarMapper.Map(cars[i]));
            }
            return result;
        }

    }
}
