using Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TheCostsOfTheCar.View;
using Xamarin.Forms;
using ViewModel.PageViewModels;

namespace TheCostsOfTheCar
{
    public class NavigationAppService : INavigationAppService
    {
        INavigation nav;

        public NavigationAppService(INavigation navigation)
        {
            nav = navigation;
        }

        public async Task GoToMainCarPage(int carId)
        {
            MainCarPageVM vm = new MainCarPageVM(carId);
            Page page = new MainCarPage();
            page.BindingContext = vm;
            await nav.PushAsync(page);
        }
    }
}
