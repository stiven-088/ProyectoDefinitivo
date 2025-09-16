using System.ComponentModel.DataAnnotations;

namespace Lib_dominio.Entidades
{
    public class Proveedores
    {
        [Key]
        public int Id_proveedor { get; set; }
        public string? Nombre { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public string? Direccion { get; set; }
        public string? Ciudad { get; set; }
    }
}