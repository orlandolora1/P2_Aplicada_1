using Microsoft.EntityFrameworkCore;

public class Context : DbContext
{
    public DbSet<Accesorio> Prioridades { get; set; }
    public DbSet<Vehiculo> Vehiculo { get; set; }
    public DbSet<VehiculoDetalle> Modelo { get; set; }

    public Context(DbContextOptions<Context> options) : base(options)
    {
        
    }
}