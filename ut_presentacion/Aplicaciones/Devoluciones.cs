/*
using Lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Aplicaciones
{
    [TestClass]
    public class DevolucionesPrueba
    {
        private readonly IDevolucionesAplicacion? iAplicacion;
        private readonly IConexion? iConexion;
        private List<Devoluciones>? lista;
        private Devoluciones? entidad;

        public DevolucionesPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
            iAplicacion = new DevolucionesAplicacion(iConexion);
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
            var cliente = iConexion!.Clientes.FirstOrDefault(x => x.Id_cliente == 1);
            var detalleCompra = iConexion!.DetalleCompras.FirstOrDefault(x => x.Id == 1);
            entidad = EntidadesNucleo.Devoluciones(cliente, detalleCompra)!;
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