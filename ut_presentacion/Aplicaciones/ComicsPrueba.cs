using Lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Aplicaciones
{
    [TestClass]
    public class ComicsPrueba
    {
        private readonly IComicsAplicacion? iAplicacion;
        private readonly IConexion? iConexion;
        private List<Comics>? lista;
        private Comics? entidad;

        public ComicsPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
            iAplicacion = new ComicsAplicacion(iConexion);
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
            this.entidad = EntidadesNucleo.Comics()!;
            this.iAplicacion!.Guardar(this.entidad);
            return true;
        }

        public bool Modificar()
        {
            if (this.entidad != null)
            {
                this.entidad.Nombre = "Comic Modificado-" + DateTime.Now.ToString("yyyyMMddhhmmss");
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