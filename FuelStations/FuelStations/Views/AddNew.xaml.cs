using System;
using FuelStations.Models;
using FuelStations.Services;

namespace FuelStations.Views
{
    public partial class AddNew
    {
        public AddNew()
        {
            this.Title = "Add New Station";
            this.InitializeComponent();
        }

        private async void OnAddStation(object sender, EventArgs e)
        {
            await FuelStationsRestApi.AddFuelStation(new FuelStation
            {
                Name = this.Name.Text,
                FuelStationId = Guid.NewGuid(),
                Address = this.Address.Text,
                FuelPrice = int.Parse(this.FuelPrice.Text)
            });

            await this.Navigation.PushAsync(new MainPage());
        }

        private void OnBack(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new MainPage());
        }
    }
}