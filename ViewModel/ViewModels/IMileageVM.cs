using Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ViewModel.ViewModels
{
    public interface IMileageVM : INotifyPropertyChanged
    {
        int Id { get; set; }
        DateTime Date { get; set; }
        int Count { get; set; }
        int CarId { get; set; }
        MileageTypeEnum Type { get; set; }
    }
}
