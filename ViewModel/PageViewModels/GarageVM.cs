using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ViewModel.DialogServices;
using ViewModel.Facades;
using ViewModel.Mappers;
using ViewModel.ViewModels;

namespace ViewModel.PageViewModels
{
    public class GarageVM : BaseINotify, IGarageVM, INotifyPropertyChanged
    {
        private ICommand _CreateNewCarCommand;
        private ICommand _RemoveCarCommand;
        private ICommand _ChangeCarCommand;
        private ICommand _ShowCarDetailCommand;

        IGarageFacade GarageFacade { get; set; }
        

        public ICarVM SelectedCar { get; set; }

        public ObservableCollection<ICarVM> Cars { get; set; }

        public GarageVM()
        {
        }

        public GarageVM(IGarageFacade garageFacade)
        {
            Cars = new ObservableCollection<ICarVM>();
            GarageFacade = garageFacade;
            LoadCarList();
        }

        public ICommand CreateNewCarCommand => _CreateNewCarCommand ??
            (_CreateNewCarCommand = new RelayCommand(() => CreateNewCar()));

        public ICommand ChangeCarCommand => _ChangeCarCommand ??
            (_ChangeCarCommand = new RelayCommand(() => ChangeCar()));

        public ICommand RemoveCarCommand => _RemoveCarCommand ??
            (_RemoveCarCommand = new RelayCommand(() => CreateNewCar()));

        public ICommand ShowCarDetailCommand => _ShowCarDetailCommand ??
            (_ShowCarDetailCommand = new RelayCommand(() => ShowCarDetail(SelectedCar.Id)));


        /// <summary>Заполняет коллекцию машин при создании окна</summary>
        async void LoadCarList()
        {
            var c = await GarageFacade.GetCarList();
            foreach (var car in c)
            {
                Cars.Add(CarMapper.Map(car));
            }
        }

        async Task CreateNewCar()
        {
            Cars.Add((ICarVM)await GarageFacade.CreateNewCar());
        }

        async Task ChangeCar()
        {
            if (SelectedCar != null)
            {
                var cCar = await GarageFacade.ChangeCar(SelectedCar);
                if (cCar != null)
                {
                    Cars.Remove(SelectedCar);
                    Cars.Add(cCar);
                }
            }
        }

        async Task ShowCarDetail(int carID)
        {
            await GarageFacade.GoToMainPage(carID);
        }

        void RemoveSelectedCar()
        {
            GarageFacade.RemoveCar(SelectedCar.Id);
            Cars.Remove(SelectedCar);
        }
    }
}
