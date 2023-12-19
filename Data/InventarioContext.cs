using Microsoft.EntityFrameworkCore;

public class InventarioContext : DbContext
{
 

    public InventarioContext(DbContextOptions options) : base(options)
    {
    }

    protected InventarioContext()
    {
    }

    public DbSet<Producto> Productos { get; set; }
    public DbSet<Venta> Ventas { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Notificacion> Notificaciones { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuraciones de Producto
        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.ProductoId);
            entity.Property(e => e.Nombre).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Codigo).IsRequired().HasMaxLength(50);
            entity.Property(e => e.FechaVencimiento).IsRequired();
            entity.Property(e => e.Ubicacion).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Costo).IsRequired().HasColumnType("decimal(18,2)");
            entity.Property(e => e.PrecioVenta).IsRequired().HasColumnType("decimal(18,2)");
            entity.Property(e => e.Proveedor).HasMaxLength(100); // Asumiendo que el proveedor es un string. Si es una entidad relacionada, necesitarás una configuración adicional.
            entity.Property(e => e.Categoria).HasMaxLength(50);
        });

        // Configuraciones de Venta
        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.VentaId);
            entity.Property(e => e.FechaVenta).IsRequired();
            entity.HasOne(e => e.Producto)
                  .WithMany() // Aquí podrías especificar una propiedad de navegación en Productos si es necesario
                  .HasForeignKey(e => e.ProductoId);
            entity.HasOne(e => e.Vendedor)
                  .WithMany() // Lo mismo para Usuario, especifica una propiedad de navegación en Usuarios si es necesario
                  .HasForeignKey(e => e.VendedorId)
                  .OnDelete(DeleteBehavior.Restrict); // Esto evitará la eliminación en cascada
            entity.Property(e => e.Cantidad).IsRequired();
            entity.Property(e => e.PrecioTotal).IsRequired().HasColumnType("decimal(18,2)");
        });

        // Configuraciones de Usuario
        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId);
            entity.Property(e => e.Nombre).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
            entity.Property(e => e.PasswordHash).IsRequired();
            entity.Property(e => e.Rol).IsRequired();
        });

        // Configuraciones de Notificacion
        modelBuilder.Entity<Notificacion>(entity =>
        {
            entity.HasKey(e => e.NotificacionId);
            entity.HasOne(e => e.Producto)
                  .WithMany() // Configura la propiedad de navegación en Productos si es necesario
                  .HasForeignKey(e => e.ProductoId);
            entity.Property(e => e.Mensaje).IsRequired().HasMaxLength(256);
            entity.Property(e => e.FechaNotificacion).IsRequired();
            entity.Property(e => e.Atendida).IsRequired();
        });
    }
}
