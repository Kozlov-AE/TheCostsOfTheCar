using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TheCostsOfTheCar.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainCarPageMaster : ContentPage
    {
        public ListView ListView;

        public MainCarPageMaster()
        {
            InitializeComponent();

            BindingContext = new MainCarPageMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MainCarPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MainCarPageMasterMenuItem> MenuItems { get; set; }

            public MainCarPageMasterViewModel()
            {
                MenuItems = new ObservableCollection<MainCarPageMasterMenuItem>(new[]
                {
                    new MainCarPageMasterMenuItem { Id = 0, Title = "Page 1" },
                    new MainCarPageMasterMenuItem { Id = 1, Title = "Page 2" },
                    new MainCarPageMasterMenuItem { Id = 2, Title = "Page 3" },
                    new MainCarPageMasterMenuItem { Id = 3, Title = "Page 4" },
                    new MainCarPageMasterMenuItem { Id = 4, Title = "Page 5" },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}