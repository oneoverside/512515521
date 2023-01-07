using System;
using FuelStations.Services;

namespace FuelStations.Views
{
    public partial class MainPage
    {
        public MainPage()
        {
            this.Title = "Main Page";
            this.InitializeComponent();
        }

        private async void OnViewStations(object sender, EventArgs e)
        {
            await this.Navigation.PushAsync(new ListOfStations(await FuelStationsRestApi.GetFuelStations()));
        }

        private void OnAddNewStation(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new AddNew());
        }

        private void OnDelete(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new DeleteStation());
        }
    }
}
