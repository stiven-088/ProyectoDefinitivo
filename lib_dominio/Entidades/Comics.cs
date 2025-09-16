using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lib_dominio.Entidades
{

    public class Comics
    {
        [Key]
        public int Id_comic { get; set; }
        public string? Nombre { get; set; }
        public string? Editorial { get; set; }
        public string? Autor { get; set; }
        public string? Ilustrador { get; set; }
        public decimal Precio { get; set; }

        public int Categoria { get; set; }
        [ForeignKey("Categoria")]
        public Categorias? _Categoria{ get; set; }

        public int Inventario { get; set; }
        [ForeignKey("Inventario")]
        public Inventarios? _Inventario { get; set; }
    }
}