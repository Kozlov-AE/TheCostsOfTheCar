using System;
using System.IO;
using SQLiteRepository;
using TheCostsOfTheCar.View;
using ViewModel.Facades;
using ViewModel.PageViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace TheCostsOfTheCar
{
    public partial class App : Application
    {
        private string dbPath;
        private string dbName = "CostsCarDb.db";
        public App()
        {
            InitializeComponent();

            dbPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    dbName);
            GaragePage p = new GaragePage();
            MainPage = new NavigationPage(p);
            MainPage.BindingContext = new GarageVM(new GarageFacade(dbPath, new DialogService.DialogService(MainPage.Navigation)));
        }

        protected override void OnStart()
        {
            BaseCreator.CreateDB (Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    dbName));
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
