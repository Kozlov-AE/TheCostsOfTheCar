using Common.DTO.Classes;
using Common.DTO.Interfaces;
using Common.RepositoryInterfaces;
using SQLiteRepository;
using SQLiteRepository.Repositories;
using System;
using System.Threading.Tasks;

namespace TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseCreator.CreateDB("TestBD1.db");
            using (var uow = new UnitOfWork("TestBD1.db"))
            {
                ICarDTO carDTO = new CarDTO($"{DateTime.Now.Millisecond} машинка", new DateTime(2010, 2, 19), 500000, 1000, 21580);
                uow.CarRepository.AddAsync(carDTO).Wait();
                PrintAllCars(uow).Wait();
            }
        }

        static void CarPrint(ICarDTO car)
        {
            Console.WriteLine($"{car.Id} {car.Title} - пробег покупки {car.BuyMileage.Count} цена = {car.BuyPrice.ToString()}");
        }

        static async Task PrintAllCars(IUnitOfWork uow)
        {
            var cars = await uow.CarRepository.GetAllAsync();
            foreach (var i in cars)
            {
                CarPrint(i);
            }
        }
    }
}
