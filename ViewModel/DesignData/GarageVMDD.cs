using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using ViewModel.PageViewModels;
using ViewModel.ViewModels;

namespace ViewModel.DesignData
{
    public class GarageVMDD : BaseINotify//, IGarageVM
    {
        public GarageVMDD()
        {
            Cars = new ObservableCollection<CarVM>
            {
                new CarVM()
                {
                    Title = "MyCar",
                    BuyDate = new DateTime(2005,10,20),
                    BuyPrice = 100000,
                    BuyMileage = 55000,
                    CurrentMileage = 150000
                },
                new CarVM()
                {
                    Title = "WifeCar",
                    BuyDate = new DateTime(2010,5,6),
                    BuyPrice = 555550,
                    BuyMileage = 100000,
                    CurrentMileage = 200000
                }
            };
        }
        //public ICommand CreateNewCarCommand => throw new NotImplementedException();

        //public ICommand EditCar => throw new NotImplementedException();

        //public ICommand RemoveCar => throw new NotImplementedException();

        //public ICommand ViewDetailsCar => throw new NotImplementedException();


        private CarVM _SelectedCar;
        public CarVM SelectedCar
        {
            get => _SelectedCar;
            set => Set(ref _SelectedCar, value);
        }

        public ObservableCollection<CarVM> Cars { get; set; }
    }
}
