using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.ViewModels;

namespace ViewModel.DesignData
{
    public class CarInfoVMDD : BaseINotify
    {
        public CarVM Car = new CarVM()
        {
            Id = 1,
            Title = "МашинаDesignData",
            BuyDate = new DateTime(2010, 05, 15),
            BuyPrice = 100500,
            BuyMileage = 500,
            CurrentMileage = 100428,
        };

        public double AMilePrice =>
            Car.BuyPrice / (Car.CurrentMileage - Car.BuyMileage);
    }
}
