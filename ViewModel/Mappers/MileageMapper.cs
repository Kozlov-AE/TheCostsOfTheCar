using Common.DTO.Classes;
using Common.DTO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.ViewModels;

namespace ViewModel.Mappers
{
    public static class MileageMapper
    {
        public static IMileageDTO Map(IMileageVM mileage)
        {
            IMileageDTO result = new MileageDTO(mileage.Id);
            result.CarId = mileage.CarId;
            result.Count = mileage.Count;
            result.Date = mileage.Date;
            result.Type = mileage.Type;
            return result;
        }

        public static ICollection<IMileageDTO> Map(IList<IMileageVM> mileages)
        {
            List<IMileageDTO> result = new List<IMileageDTO>(mileages.Count);
            for (int i = 0; i < mileages.Count; i++)
            {
                result.Add(Map(mileages[i]));
            }
            return result;
        }

        public static IMileageVM Map(IMileageDTO mileage)
        {
            IMileageVM result = new MileageVM(mileage.Id);
            result.CarId = mileage.CarId;
            result.Count = mileage.Count;
            result.Date = mileage.Date;
            result.Type = mileage.Type;
            return result;
        }

        public static ICollection<IMileageVM> Map(IList<IMileageDTO> mileages)
        {
            List<IMileageVM> result = new List<IMileageVM>(mileages.Count);
            for (int i = 0; i < mileages.Count; i++)
            {
                result.Add(Map(mileages[i]));
            }
            return result;
        }

    }
}
