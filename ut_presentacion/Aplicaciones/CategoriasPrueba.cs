using Lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Aplicaciones
{
    [TestClass]
    public class CategoriasPrueba
    {
        private readonly ICategoriasAplicacion? iAplicacion;
        private readonly IConexion? iConexion;
        private List<Categorias>? lista;
        private Categorias? entidad;

        public CategoriasPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
            iAplicacion = new CategoriasAplicacion(iConexion);
        }

        [TestMethod]
        public void Ejecutar()
        {
            Assert.AreEqual(true, Guardar());
            Assert.AreEqual(true, Modificar());
            Assert.AreEqual(true, Listar());
            Assert.AreEqual(true, Borrar());
        }

        public bool Listar()
        {
            this.lista = this.iAplicacion!.Listar();
            return lista.Count >= 0;
        }

        public bool Guardar()
        {
            
            this.entidad = EntidadesNucleo.Categorias()!;
            this.iAplicacion!.Guardar(this.entidad);
            return true;
        }

        public bool Modificar()
        {
            
            if (this.entidad != null)
            {
                this.entidad.Nombre = "Categoria Modificada-" + DateTime.Now.ToString("yyyyMMddhhmmss");
                this.iAplicacion!.Modificar(this.entidad);
            }
            return true;
        }

        public bool Borrar()
        {
            
            if (this.entidad != null)
            {
                this.iAplicacion!.Borrar(this.entidad);
            }
            return true;
        }
    }
}
