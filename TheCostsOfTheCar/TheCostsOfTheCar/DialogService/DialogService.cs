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
            var result = await GetObjectFromDialogPage<ICarVM>("NewCarMessage", new CarDetailView(null));
            return result;
        }

        public async Task<ICarVM> ChangeCar(ICarVM car)
        {
            var result = await GetObjectFromDialogPage<ICarVM>("ChangeCarMessage", new CarDetailView(car));
            return result;
        }

        /// <summary>Возвращает объект из модального окна</summary>
        /// <typeparam name="T">Тип объекта</typeparam>
        /// <param name="message">Сообщение из диалога</param>
        /// <param name="page">Страница диалого</param>
        /// <returns><see langword="null"/> Если нажата отмена или совершена ошибка заполнения формы</returns>
        async Task<T> GetObjectFromDialogPage<T>(string message, Page page) where T: class
        {
            T result;
            TaskCompletionSource<T> tcs = new TaskCompletionSource<T>();
            MessagingCenter.Subscribe<T>(this, message, (value) =>
            {
                tcs.TrySetResult(value);
            });
            await Navigation.PushModalAsync(page);
            result = await tcs.Task;
            await Navigation.PopModalAsync();
            return result;
        }
    }
}
