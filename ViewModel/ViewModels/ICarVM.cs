using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ViewModel.ViewModels
{
    public interface ICarVM : INotifyPropertyChanged, ICopy<ICarVM>
    {
        int Id { get; set; }
        string Title { get; set; }
        DateTime BuyDate { get; set; }
        double BuyPrice { get; set; }
        int BuyMileage { get; set; }
        int CurrentMileage { get; set; }
    }
}
