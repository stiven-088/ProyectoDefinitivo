using System.ComponentModel.DataAnnotations;

namespace Lib_dominio.Entidades
{

    public class Empleados
    {
        [Key]
        public int Id_empleado { get; set; }
        public string? Nombre { get; set; }
        public string? Puesto { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public DateTime Fecha_contratacion { get; set; }
    }
}