using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lib_dominio.Entidades
{
    public class Devoluciones
    {
        [Key]
        public int Id_devolucion { get; set; }
        public string? Motivo { get; set; }
        public DateTime Fecha_inicio { get; set; }
        public DateTime Fecha_fin { get; set; }
        public string? Estado_devolucion { get; set; }
        public int Cantidad_devuelta { get; set; }

        public int Cliente { get; set; }
        [ForeignKey("Cliente")]
        public Clientes? _Cliente { get; set; }

        public int Detalle_compra { get; set; }
        [ForeignKey("Detalle_compra")]
        public DetalleCompras? _Detalle { get; set; }
    }

}
