using System;

namespace FuelStations.Models
{
    public class FuelStation
    {
        public Guid FuelStationId { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Address { get; set; }
        public bool InFavorite { get; set; }
        public int FuelPrice { get; set; }
    }
}