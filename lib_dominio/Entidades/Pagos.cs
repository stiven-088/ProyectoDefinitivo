
using System.ComponentModel.DataAnnotations;

namespace Lib_dominio.Entidades
{
    public class Pagos
    {
        [Key]
        public int Id_pago { get; set; }
        public string? Metodo { get; set; }
        public DateTime Fecha_pago { get; set; }
        public decimal Monto { get; set; }
        public string? Estado { get; set; }
        public string? Referencia_transaccion { get; set; }
    }
}