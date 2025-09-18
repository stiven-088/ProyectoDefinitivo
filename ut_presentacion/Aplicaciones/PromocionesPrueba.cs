/*
using Lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Aplicaciones
{
    [TestClass]
    public class PromocionesPrueba
    {
        private readonly IPagosAplicacion? iAplicacion;
        private readonly IConexion? iConexion;
        private List<Promociones>? lista;
        private Pagos? entidad;

        public PromocionesPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
            iAplicacion = new PagosAplicacion(iConexion);
        }

        [TestMethod]
        public void Ejecutar()
        {
            Assert.AreEqual(true, Guardar());
            Assert.AreEqual(true, Modificar());
            Assert.AreEqual(true, Listar(GetIAplicacion()));
            Assert.AreEqual(true, Borrar());
        }

        public IPagosAplicacion GetIAplicacion()
        {
            return iAplicacion;
        }

        public bool Listar(IPagosAplicacion iAplicacion)
        {
            lista = iAplicacion!.Listar();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            entidad = EntidadesNucleo.Pagos();
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