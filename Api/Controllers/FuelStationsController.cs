using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

public class FuelStationsController : Controller
{
    [HttpGet]
    [Route("GetStations")]
    public async Task<List<FuelStation>> OnGetStations([FromServices] AppDbContext context)
    {
        return await context.FuelStations.ToListAsync();
    }

    [HttpPost]
    [Route("DeleteStation")]
    public async Task OnDeleteStation([FromBody] Guid id, [FromServices] AppDbContext context)
    {
        var x = await context.FuelStations.FirstAsync(x => x.FuelStationId == id);
        context.FuelStations.Remove(x);
        await context.SaveChangesAsync();
    }
    
    [HttpPost]
    [Route("FavStation")]
    public async Task OnFavStation([FromBody] Guid id, [FromServices] AppDbContext context)
    {
        var x = await context.FuelStations.FirstAsync(x => x.FuelStationId == id);
        x.InFavorite = true;
        await context.SaveChangesAsync();
    }
    
    [HttpPost]
    [Route("AddStation")]
    public async Task OnAddStation([FromBody] FuelStation station, [FromServices] AppDbContext context)
    {
        context.FuelStations.Add(station);
        await context.SaveChangesAsync();
    }
}