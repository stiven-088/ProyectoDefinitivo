/*
using Lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Aplicaciones
{
    [TestClass]
    public class ComicPromocionesPrueba
    {
        private readonly IComic_promocionesAplicacion? iAplicacion;
        private readonly IConexion? iConexion;
        private List<Comic_promociones>? lista;
        private Comic_promociones? entidad;

        public ComicPromocionesPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = "Server=localhost;Database=Proyecto;Trusted_Connection=True;";
            iAplicacion = new Comic_promocionesAplicacion(iConexion);
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
            lista = iAplicacion!.Listar();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            var promocion = iConexion!.Promociones.FirstOrDefault(x => x.Id_promocion == 1);
            var comic = iConexion!.Comics.FirstOrDefault(x => x.Id_comic == 1);
            entidad = EntidadesNucleo.Comic_promociones(promocion, comic)!;
            iAplicacion!.Guardar(entidad);
            return true;
        }

        public bool Modificar()
        {
            iAplicacion!.Modificar(entidad);
            return true;
        }

        public bool Borrar()
        {
            iAplicacion!.Borrar(entidad);
            return true;
        }
    }
}
*/