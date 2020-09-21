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

        private async void BackBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private async void OkBtn_Clicked(object sender, EventArgs e)
        {
            if (IsCreate)
            {
                MessagingCenter.Send<ICarVM>(Car.Copy(), "NewCarMessage");
            }
            if (IsChange)
            {
                if (Car != oldCar)
                {
                    MessagingCenter.Send<ICarVM>(Car.Copy(), "ChangeCarMessage");
                }
            }
            //await Navigation.PopModalAsync();
        }
    }
}