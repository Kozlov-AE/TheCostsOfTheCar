using Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

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
            throw new NotImplementedException();
        }
    }
}
