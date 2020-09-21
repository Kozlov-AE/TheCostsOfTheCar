using Common.DTO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DTO.Classes
{
    public class CarDTO : BaseIdDTO, ICarDTO
    {
        public CarDTO(int id = 0) : base(id){}

        public string Title { get; set; }
        public DateTime BuyDate { get; set; }
        public double BuyPrice { get; set; }
        public int BuyMileage { get; set; }
        public int CurrentMileage { get; set; }
        //public IMileageDTO BuyMileage { get; set; }
        //public IMileageDTO CurrentMileage { get; set; }

        //public CarDTO(string title, DateTime buyDate, double buyPrice, int buyMileage, int currentMileage)
        //{
        //    Title = title;
        //    BuyDate = buyDate;
        //    BuyPrice = buyPrice;
        //    BuyMileage = new MileageDTO()
        //    {
        //        Date = BuyDate,
        //        Count = currentMileage,
        //        CarId = Id,
        //        Type = Enums.MileageTypeEnum.Current
        //    };
        //    CurrentMileage = new MileageDTO()
        //    {
        //        Date = DateTime.Now,
        //        Count = buyMileage,
        //        CarId = Id,
        //        Type = Enums.MileageTypeEnum.First
        //    };
        //}
    }
}
