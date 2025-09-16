using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lib_dominio.Entidades
{

    public class Clientes
    {
        [Key]
        public int Id_cliente { get; set; }
        public string? Nombre { get; set; }
        public string? Email { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public DateTime Fecha_registro { get; set; }

        
        public int Membresia { get; set; }
        [ForeignKey("Membresia")]
        public Membresias? _Membresia { get; set; }
    }
}