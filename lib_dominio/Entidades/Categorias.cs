
using System.ComponentModel.DataAnnotations;

namespace Lib_dominio.Entidades
{
    public class Categorias
    {
        [Key]
        public int Id_categorias { get; set; }
        public string? Nombre { get; set; }
        public DateTime Fecha_creacion { get; set; }
        public string? Descripcion { get; set; }
        public bool Estado { get; set; }
        public int Prioridad { get; set; }
    }

}
