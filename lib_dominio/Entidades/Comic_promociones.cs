using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lib_dominio.Entidades
{
    [Table("Comic_promociones")]
    public class Comic_promociones
    {
        [Key]
        public int Id { get; set; }
        public DateTime Fecha_asignacion { get; set; }
        public string? Estado { get; set; }
        public string? Aplicacion { get; set; }
        public string? Tipo_promocion { get; set; }
        public string? Observaciones { get; set; }

        public int Promocion { get; set; }
        [ForeignKey("Promocion")]
        public Promociones? _Promocion { get; set; }

        public int Comic { get; set; }
        [ForeignKey("Comic")]
        public Comics? _Comic { get; set; }
    }
}
    