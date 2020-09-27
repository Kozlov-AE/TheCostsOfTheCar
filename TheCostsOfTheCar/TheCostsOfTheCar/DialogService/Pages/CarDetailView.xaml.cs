using Common.DTO.Classes;
using Common.DTO.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.DialogServices;
using ViewModel.PageViewModels;
using ViewModel.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TheCostsOfTheCar.DialogService.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarDetailView : ContentPage, INotifyPropertyChanged
    {
        public CarDetailView()
        {
            InitializeComponent();
            Car = new CarVM();
            BindingContext = this;
        }

        public CarDetailView(ICarVM car)
        {
            InitializeComponent();
            if (car != null)
            {
                Car = car.Copy();
                oldCar = car.Copy();
                IsChange = true;
            }
            else
            {
                Car = new CarVM();
                IsCreate = true;
            }
            BindingContext = this;
        }

        public ICarVM Car { get; set; }
        ICarVM oldCar;
        public bool IsChange { get; set; } = false;
        public bool IsCreate { get; set; } = false;

        private void BackBtn_Clicked(object sender, EventArgs e)
        {
            ClosePage();
        }

        private void OkBtn_Clicked(object sender, EventArgs e)
        {
            if (IsCreate)
            {
                if (!string.IsNullOrWhiteSpace(Car.Title))
                {
                    MessagingCenter.Send<ICarVM>(Car.Copy(), "NewCarMessage");
                }
                else
                {
                    ClosePage();
                }
            }
            if (IsChange)
            {
                if (Car != oldCar)
                {
                    if (!string.IsNullOrWhiteSpace(Car.Title))
                    {
                        MessagingCenter.Send<ICarVM>(Car.Copy(), "ChangeCarMessage");
                    }
                    else
                        ClosePage();
                }
                else
                    ClosePage();
            }
        }

        private void ClosePage()
        {
            MessagingCenter.Unsubscribe<ICarVM>(Car, "NewCarMessage");
            Navigation.PopModalAsync();
        }
    }
}