
using System.ComponentModel.DataAnnotations;

namespace Lib_dominio.Entidades
{
    public class Inventarios
    {
        [Key]
        public int Id_inventario { get; set; }
        public string? Nombre { get; set; }
        public int Stock { get; set; }
        public string? Ubicacion { get; set; }
        public DateTime Fecha_actualizacion { get; set; }
        public string? Tipo_producto { get; set; }
    }


}
