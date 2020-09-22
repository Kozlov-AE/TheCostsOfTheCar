using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.ViewModels;

namespace ViewModel.PageViewModels
{
    public class MainCarPageVM : BaseINotify, IMainCarPageVM
    {
        CarVM car;
        public MainCarPageVM(int carId)
        {
            car = null;
        }
    }
}
