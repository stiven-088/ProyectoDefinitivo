

using System.ComponentModel.DataAnnotations;

namespace Lib_dominio.Entidades
{
    public class Promociones
    {
        [Key]
        public int Id_promocion { get; set; }
        public string? Descripcion { get; set; }
        public decimal Descuento { get; set; }
        public DateTime Fecha_inicio { get; set; }
        public DateTime Fecha_fin { get; set; }
        public string? Codigo { get; set; }
    }

}
