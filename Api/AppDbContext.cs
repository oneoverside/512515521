using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api;

public class AppDbContext : DbContext
{
    public DbSet<FuelStation> FuelStations { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}