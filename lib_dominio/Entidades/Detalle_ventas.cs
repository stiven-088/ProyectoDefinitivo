using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lib_dominio.Entidades
{
    [Table("Detalle_Ventas")]
    public class DetalleVentas
    {
        [Key]
        public int Id { get; set; }
        public decimal Precio_unitario { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Descuento { get; set; }
        public string? Tipo_producto_vendido { get; set; }

        public int Venta { get; set; }
        [ForeignKey("Venta")]
        public Ventas? _Venta { get; set; }

        public int Comic { get; set; }
        [ForeignKey("Comic")]
        public Comics? _Comic { get; set; }
    }
}