using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lib_dominio.Entidades
{
    [Table("Detalle_compras")]
    public class DetalleCompras
    {
        [Key]
        public int Id { get; set; }
        public decimal Precio_unitario { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Descuento { get; set; }
        public string? Tipo_producto_comprado { get; set; }

        public int Compra { get; set; }
        [ForeignKey("Compra")]
        public Compras? _Compra{ get; set; }

        public int Comic { get; set; }
        [ForeignKey("Comic")]
        public Comics? _Comic { get; set; }

        public int Pago { get; set; }
        [ForeignKey("Pago")]
        public Pagos? _Pago { get; set; }
    }

}
