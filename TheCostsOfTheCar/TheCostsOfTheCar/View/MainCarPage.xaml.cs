﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TheCostsOfTheCar.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainCarPage : MasterDetailPage
    {
        public MainCarPage()
        {
            InitializeComponent();
            Detail = new NavigationPage(new CarInfoPage());
        }
    }
}