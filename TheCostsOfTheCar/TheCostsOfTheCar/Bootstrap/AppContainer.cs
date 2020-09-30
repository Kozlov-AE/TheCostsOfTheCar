using Autofac;
using Common;
using Common.RepositoryInterfaces;
using SQLiteRepository.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PageViewModels;
using ViewModel.ViewModels;

namespace TheCostsOfTheCar.Bootstrap
{
    public class AppContainer
    {
        private static IContainer container;

        public AppContainer()
        {
            var builder = new ContainerBuilder();
            //Services
            builder.RegisterType<DialogService.DialogService>().As<IDialogService>().SingleInstance();
            builder.RegisterType<NavigationAppService>().As<INavigationAppService>().SingleInstance();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().SingleInstance();

            //Entities view models
            builder.RegisterType<CarVM>().SingleInstance();
            builder.RegisterType<MileageVM>().SingleInstance();

            //Pages view models
            builder.RegisterType<GarageVM>().SingleInstance();
            builder.RegisterType<MainCarPageVM>().SingleInstance();

            container = builder.Build();
        }

        public T Resolve<T>() => container.Resolve<T>();
        public object Resolve(Type type) => container.Resolve(type);
    }
}
