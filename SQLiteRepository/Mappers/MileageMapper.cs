using Common.DTO.Classes;
using Common.DTO.Interfaces;
using SQLiteRepository.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLiteRepository.Mappers
{
    public static class MileageMapper
    {
        public static IMileageDTO Map(Mileage m)
        {
            IMileageDTO result = new MileageDTO(m.Id);
            result.CarId = m.CarId;
            result.Count = m.Count;
            result.Date = m.Date;
            result.Type = m.Type;
            return result;
        }

        public static ICollection<IMileageDTO> Map(IList<Mileage> mileages)
        {
            List<IMileageDTO> result = new List<IMileageDTO>();
            for (int i = 0; i < mileages.Count; i++)
            {
                result.Add(MileageMapper.Map(mileages[i]));
            }
            return result;
        }

        public static Mileage Map(IMileageDTO m)
        {
            Mileage result = new Mileage(m.Id);
            result.CarId = m.CarId;
            result.Count = m.Count;
            result.Date = m.Date;
            result.Type = m.Type;
            return result;
        }

        public static ICollection<Mileage> Map(IList<IMileageDTO> mileages)
        {
            List<Mileage> result = new List<Mileage>();
            for (int i = 0; i < mileages.Count; i++)
            {
                result.Add(MileageMapper.Map(mileages[i]));
            }
            return result;
        }

    }
}
