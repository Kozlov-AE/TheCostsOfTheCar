using Common.DTO.Interfaces;
using Common.RepositoryInterfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLiteRepository.Entities;
using SQLiteRepository.Mappers;
using SQLite;
using SQLiteNetExtensionsAsync.Extensions;
using Common.DTO.Classes;
using Common.Static;
using System;

namespace SQLiteRepository.Repositories
{
    public class CarRepository : ICarRepository
    {
        SQLiteAsyncConnection context;

        public CarRepository(SQLiteAsyncConnection _context)
        {
            context = _context;
        }

        public async Task<ICarDTO> AddAsync(ICarDTO dto)
        {
            if (await IsNameExist(dto.Title).ConfigureAwait(false))
            {
                throw new Exception(Exceptions.CarExceptions.CarNameIsExists);
            }

            var car = CarMapper.Map(dto);
            car.AddMileage(new Mileage()
            {
                Date = car.BuyDate,
                Count = dto.BuyMileage,
                Type = Common.Enums.MileageTypeEnum.First
            });
            car.AddMileage(new Mileage()
            {
                Date = DateTime.Now,
                Count = dto.CurrentMileage,
                Type = Common.Enums.MileageTypeEnum.Current
            });

            await context.InsertWithChildrenAsync(car, recursive: true).ConfigureAwait(false);
            var newCar = await context.GetWithChildrenAsync<Car>(car.Id, recursive: true).ConfigureAwait(false);
            return CarMapper.Map(newCar);
        }

        public async Task<bool> Any()
        {
            return await context.Table<Car>().CountAsync().ConfigureAwait(false) > 0;
        }

        public async Task<ICollection<ICarDTO>> GetAllAsync()
        {
            var cars = await context.GetAllWithChildrenAsync<Car>().ConfigureAwait(false);
            return CarMapper.Map(cars);
        }

        public async Task<ICarDTO> GetByIdAsync(int id)
        {
            return CarMapper.Map(await context.GetAsync<Car>(id).ConfigureAwait(false));
        }

        public async void RemoveAsync(int id)
        {
            await context.QueryAsync<Mileage>("delete from Mileages where CarId = ?", id).ConfigureAwait(false);
            await context.DeleteAsync<Car>(id).ConfigureAwait(false);
        }

        public async Task<ICarDTO> UpdateAsync(ICarDTO dto)
        {
            var dbcar = await context.GetWithChildrenAsync<Car>
                (dto.Id, recursive: true).ConfigureAwait(false);

            if (dbcar.BuyDate != dto.BuyDate || dbcar.BuyMileage.Count != dto.BuyMileage)
            {
                var mil = await context.GetAsync<Mileage>
                    (m => m.CarId == dto.Id && m.Type == Common.Enums.MileageTypeEnum.First)
                    .ConfigureAwait(false);
                mil.Count = dto.BuyMileage;
                mil.Date = dto.BuyDate;
                await context.UpdateAsync(mil).ConfigureAwait(false);
            }

            dbcar.BuyDate = dto.BuyDate;
            dbcar.BuyPrice = dto.BuyPrice;
            dbcar.Title = dto.Title;
            if (dbcar.Title != dto.Title)
            {
                if (await IsNameExist(dto.Title).ConfigureAwait(false))
                {
                    throw new Exception(Exceptions.CarExceptions.CarNameIsExists);
                }
            }
            else await context.UpdateAsync(dbcar).ConfigureAwait(false);
             
            var newCar = await context.GetWithChildrenAsync<Car>(dto.Id, recursive: true).ConfigureAwait(false);
            return CarMapper.Map(newCar);
        }

        /// <summary>Проверяет есть ли уже такое имя машины</summary>
        /// <param name="title">Наименование машины</param>
        /// <returns>true если машина найдена</returns>
        async Task<bool>IsNameExist(string title)
        {
            var foundCar = await context.FindAsync<Car>(c => c.Title == title).ConfigureAwait(false);
            return foundCar != null;
        }
    }
}
