using System;
using FuelStations.Services;

namespace FuelStations.Views
{
    public partial class DeleteStation
    {
        public DeleteStation()
        {
            this.Title = "Delete Station";
            this.InitializeComponent();
        }

        private async void OnDeleteStation(object sender, EventArgs e)
        {
            var idForDelete = this.Id.Text;

            if (Guid.TryParse(idForDelete, out var parsedId))
            {
                await FuelStationsRestApi.DeleteFuelStationById(parsedId);
            }
            
            this.OnBack(sender, e);
        }

        private void OnBack(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new MainPage());
        }
    }
}