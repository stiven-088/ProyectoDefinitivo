using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lib_dominio.Entidades
{
    public class Ventas
    {
        [Key]
        public int Id_venta { get; set; }
        public DateTime Fecha_venta { get; set; }
        public decimal Total { get; set; }
        public string? Metodo_pago { get; set; }
        public string? Estado_venta { get; set; }
        public string? Tipo_venta { get; set; }

        public int Empleado { get; set; }
        [ForeignKey("Empleado")]
        public Empleados? _Empleado { get; set; }

        public int Proveedor { get; set; }
        [ForeignKey("Proveedor")]
        public Proveedores? _Proveedor{ get; set; }

        public int Membresia { get; set; }
        [ForeignKey("Membresia")]
        public Membresias? _Membresia { get; set; }
    }
}