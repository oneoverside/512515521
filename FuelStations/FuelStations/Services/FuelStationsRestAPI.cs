using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FuelStations.Models;
using Newtonsoft.Json;

namespace FuelStations.Services
{
    public static class FuelStationsRestApi
    {
        public static async Task DeleteFuelStationById(Guid id)
        {
            var httpClient = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(id), Encoding.UTF8, "text/json");
            await httpClient.PostAsync("http://localhost:2284/DeleteStation", content);
        }
        
        public static async Task SaveFuelStationToFavById(Guid id)
        {
            var httpClient = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(id), Encoding.UTF8, "text/json");
            await httpClient.PostAsync("http://localhost:2284/FavStation", content);
        }

        public static async Task AddFuelStation(FuelStation fuelStation)
        {
            var httpClient = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(fuelStation), Encoding.UTF8, "text/json");
            await httpClient.PostAsync("http://localhost:2284/AddStation", content);
        }

        public static async Task<List<FuelStation>> GetFuelStations()
        {
            var httpClient = new HttpClient();
            var serverResponse = await httpClient.GetAsync("http://localhost:2284/GetStations");
            var json = await serverResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<FuelStation>>(json);
        }
    }
}