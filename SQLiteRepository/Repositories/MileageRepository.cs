using Common.DTO.Interfaces;
using Common.Enums;
using Common.RepositoryInterfaces.Repositories;
using SQLite;
using SQLiteRepository.Entities;
using SQLiteRepository.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteRepository.Repositories
{
    public class MileageRepository : Repository<Mileage, IMileageDTO>, IMileageRepository
    {
        public MileageRepository(SQLiteAsyncConnection db) : base(db) { }

        public override async Task<IMileageDTO> AddAsync(IMileageDTO dto)
        {

            Mileage FoundedMileage = (dto.Type != MileageTypeEnum.Regular)
                ? await context.GetAsync<Mileage>(m => (m.Type == dto.Type && m.CarId == dto.CarId)).ConfigureAwait(false)
                : null;
            if (FoundedMileage != null)
            {
                UpdateMileageToRegular(FoundedMileage);
            }
            dto.Id = await context.InsertAsync(MileageMapper.Map(dto)).ConfigureAwait(false);
            return dto;
        }

        /// <summary>Изменить запись пробега в БД на регулярный</summary>
        private async void UpdateMileageToRegular(Mileage mil)
        {
            mil.Type = MileageTypeEnum.Regular;
            await context.UpdateAsync(mil).ConfigureAwait(false);
        }

        public override async Task<ICollection<IMileageDTO>> GetAllAsync()
        {
            return MileageMapper.Map(await context.Table<Mileage>().ToListAsync().ConfigureAwait(false));
        }

        public override async Task<IMileageDTO> GetByIdAsync(int id)
        {
            return MileageMapper.Map(await context.FindAsync<Mileage>(id));
        }

        public async Task<ICollection<IMileageDTO>> GetCarMilleagesByType(int carid, MileageTypeEnum type)
        {
            return MileageMapper.Map(await context.Table<Mileage>().Where(m => m.CarId == carid && m.Type == type).ToListAsync());
        }

        public override void RemoveAsync(int id)
        {
            //context.DeleteAsync<Mileage>(id);
        }

        public override async Task<IMileageDTO> UpdateAsync(IMileageDTO dto)
        {
            if(dto.Id == 0 && dto.CarId != 0)
            {
                var mil = await context.GetAsync<Mileage>(m => m.Type == dto.Type && m.CarId == dto.CarId);
                mil.Count = dto.Count;
                mil.Date = dto.Date;
                await context.UpdateAsync(mil);
                dto.Id = mil.Id;
            }
            else if (dto.Id == 0 || (await context.FindAsync<Mileage>(dto.Id) == null))
            {
                throw new Exception(Common.Static.Exceptions.MileageExceptions.MileageIdMissing);
            }
                else
                {
                    await context.UpdateAsync(MileageMapper.Map(dto));
                }
            return dto;
        }
    }
}
