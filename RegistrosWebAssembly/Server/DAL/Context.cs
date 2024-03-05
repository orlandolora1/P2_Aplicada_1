using Microsoft.EntityFrameworkCore;

public class Context : DbContext
{
    public DbSet<Accesorio> Accesorios { get; set; }
    public DbSet<Vehiculo> Vehiculo { get; set; }
    public DbSet<VehiculoDetalle> Accesorio { get; set; }

    public Context(DbContextOptions<Context> options) : base(options)
    {
        
    }
}