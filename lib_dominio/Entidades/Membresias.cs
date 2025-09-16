
using System.ComponentModel.DataAnnotations;

namespace Lib_dominio.Entidades
{

    public class Membresias
    {
        [Key]
        public int Id_membresia { get; set; }
        public string? Tipo { get; set; }
        public decimal Precio { get; set; }
        public string? Beneficio { get; set; }
        public DateTime Fecha_inicio { get; set; }
        public DateTime Fecha_fin { get; set; }
    }
}