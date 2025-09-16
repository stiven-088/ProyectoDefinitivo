using Lib_dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace lib_repositorios.Interfaces
{
    public interface IConexion
    {
        string? StringConexion { get; set; }

      
        public DbSet<Empleados>? Empleados { get; set; }
        public DbSet<Categorias>? Categorias { get; set; }
        public DbSet<Inventarios>? Inventarios { get; set; }
        public DbSet<Membresias>? Membresias { get; set; }
        public DbSet<Clientes>? Clientes { get; set; }
        public DbSet<Comics>? Comics { get; set; }
        public DbSet<Proveedores>? Proveedores { get; set; }
        public DbSet<Ventas>? Ventas { get; set; }
        public DbSet<DetalleVentas>? DetalleVentas { get; set; }
        public DbSet<Pagos>? Pagos { get; set; }
        public DbSet<Compras>? Compras { get; set; }
        public DbSet<DetalleCompras>? DetalleCompras { get; set; }
        public DbSet<Devoluciones>? Devoluciones { get; set; }
        public DbSet<Promociones>? Promociones { get; set; }
        public DbSet<Comic_promociones>? ComicPromociones { get; set; }

        EntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
        
        
    }
}