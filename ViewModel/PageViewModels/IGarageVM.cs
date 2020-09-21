using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using ViewModel.Facades;
using ViewModel.ViewModels;

namespace ViewModel.PageViewModels
{
    public interface IGarageVM : INotifyPropertyChanged
    {
        ICommand CreateNewCarCommand { get; }
        ICommand ChangeCarCommand { get; }
        ICommand RemoveCarCommand { get; }
        ICommand ShowCarDetailCommand { get; }

        ICarVM SelectedCar { get; set; }
        ObservableCollection<ICarVM> Cars { get; set; }
    }
}
