using System;
using System.Collections.Generic;
using System.Globalization;
using FuelStations.Models;
using FuelStations.Services;
using Xamarin.Forms;

namespace FuelStations.Views
{
    public partial class ListOfStations
    {
        public ListOfStations(List<FuelStation> fuelStations)
        {
            this.Title = "List Of All Stations";
            this.InitializeComponent();
            fuelStations.ForEach(x => this.ListOfStationsContainer?.Children.Add(this.OnConvertFuelStationToStackLayout(x)));
        }

        private StackLayout OnConvertFuelStationToStackLayout(FuelStation fuelStation)
        {
            var stackLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children =
                {
                    new Label
                    {
                        WidthRequest = 200,
                        Text = fuelStation.Name
                    },
                    new Label
                    {
                        WidthRequest = 200,
                        Text = fuelStation.FuelPrice.ToString(CultureInfo.InvariantCulture)
                    },
                    new Label
                    {
                        WidthRequest = 200,
                        Text = fuelStation.Address
                    },
                    new Label
                    {
                        WidthRequest = 200,
                        IsVisible = false,
                        Text = fuelStation.FuelStationId.ToString(),
                    },
                    new Label
                    {
                        WidthRequest = 100,
                        Text = fuelStation.InFavorite.ToString()
                    }
                }
            };
            
            var addButton = new Button
            {
                WidthRequest = 100,
                Text = "Save to fav",
            };
            addButton.Clicked += this.OnSaveToFav;
            stackLayout.Children.Add(addButton);
            
            var deleteButton = new Button
            {
                WidthRequest = 100,
                Text = "Delete",
            };
            deleteButton.Clicked += this.OnDelete;
            stackLayout.Children.Add(deleteButton);

            return stackLayout;
        }
        
        private async void OnSaveToFav(object sender, EventArgs e)
        {
            var favElement = (sender as Button)?.Parent as StackLayout;
            var favElementId = (favElement?.Children[3] as Label)?.Text;

            if (Guid.TryParse(favElementId, out var g))
            {
                await FuelStationsRestApi.SaveFuelStationToFavById(g);
            }

            if (favElement == null)
            {
                return;
            }
            
            favElement.Children[4] = new Label
            {
                WidthRequest = 100,
                Text = true.ToString()
            };
        }
        
        private async void OnDelete(object sender, EventArgs e)
        {
            var elementForDelete = (sender as Button)?.Parent as StackLayout;
            var idForDelete = (elementForDelete?.Children[3] as Label)?.Text;

            if (Guid.TryParse(idForDelete, out var parsedId))
            {
                await FuelStationsRestApi.DeleteFuelStationById(parsedId);
            }
            
            this.ListOfStationsContainer.Children.Remove(elementForDelete);
        }

        private void OnBackToMain(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new MainPage());
        }
    }
}