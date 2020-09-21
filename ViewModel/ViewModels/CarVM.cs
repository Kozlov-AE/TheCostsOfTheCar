using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.ViewModels
{
    public class CarVM : BaseINotify, ICarVM
    {
        public int Id { get; set; }

        private string _Title;
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

        private DateTime _BuyDate;
        public DateTime BuyDate
        {
            get => _BuyDate;
            set => Set(ref _BuyDate, value);
        }

        private double _BuyPrice;
        public double BuyPrice
        {
            get => _BuyPrice;
            set => Set(ref _BuyPrice, value);
        }

        private int _BuyMileage;
        public int BuyMileage
        {
            get => _BuyMileage;
            set => Set(ref _BuyMileage, value);
        }

        private int _CurrentMileage;
        public int CurrentMileage
        {
            get => _CurrentMileage;
            set => Set(ref _CurrentMileage, value);
        }

        public CarVM(int id = 0)
        {
            Id = id;
        }
        public CarVM()
        { }

        public ICarVM Copy()
        {
            ICarVM CopiedCar = new CarVM(this.Id);
            CopiedCar.BuyDate = this.BuyDate;
            CopiedCar.BuyMileage = this.BuyMileage;
            CopiedCar.BuyPrice = this.BuyPrice;
            CopiedCar.CurrentMileage = this.CurrentMileage;
            CopiedCar.Title = this.Title;
            return CopiedCar;
        }
    }
}
