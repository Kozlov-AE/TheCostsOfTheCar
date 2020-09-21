using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public interface INavigationAppService
    {
        Task GoToMainCarPage(int carId);
    }
}
