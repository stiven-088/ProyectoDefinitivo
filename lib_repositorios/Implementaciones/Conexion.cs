using Lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public partial class Conexion : DbContext, IConexion
    {
        public string? StringConexion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.StringConexion!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

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
    }
}