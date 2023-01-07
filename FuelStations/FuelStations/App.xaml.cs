using FuelStations.Views;
using System;
using FuelStations.Models;
using Xamarin.Forms;

namespace FuelStations
{
    public partial class App
    {
        public App()
        {
            this.InitializeComponent();
            this.MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
