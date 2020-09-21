using Common.DTO.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using TheCostsOfTheCar.DialogService.Pages;
using ViewModel.DialogServices;
using ViewModel.PageViewModels;
using ViewModel.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TheCostsOfTheCar.DialogService
{
    public class DialogService  : IDialogService
    {
        public INavigation Navigation { get; set; }

        public DialogService(INavigation nav)
        {
            Navigation = nav;
        }

        public async Task<ICarVM> AddNewCarDialog()
        {
            return await GetObjectFromDialogPage<ICarVM>("NewCarMessage", new CarDetailView(null));
        }

        public async Task<ICarVM> ChangeCar(ICarVM car)
        {
            return await GetObjectFromDialogPage<ICarVM>("ChangeCarMessage", new CarDetailView(car));
        }

        async Task<T> GetObjectFromDialogPage<T>(string message, Page page) where T: class
        {
            TaskCompletionSource<T> tcs = new TaskCompletionSource<T>();
            MessagingCenter.Subscribe<T>(this, message, (value) =>
            {
                tcs.TrySetResult(value);
            });
            await Navigation.PushModalAsync(page);
            var c = await tcs.Task;
            Navigation.PopModalAsync();
            return c;
        }
    }
}
