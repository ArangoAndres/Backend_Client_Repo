using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Cliente> Clientes { get; set; }

    public DbSet<Archivo> Archivos { get; set; }

    public DbSet<Observacion> Observaciones { get; set; }

    public DbSet<Usuario> Usuarios { get; set; }
}