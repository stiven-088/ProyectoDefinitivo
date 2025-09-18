/*
using Lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Aplicaciones
{
    [TestClass]
    public class DetalleComprasPrueba
    {
        private readonly IDetalleComprasAplicacion? iAplicacion;
        private readonly IConexion? iConexion;
        private List<DetalleCompras>? lista;
        private DetalleCompras? entidad;

        public DetalleComprasPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = "Server=localhost;Database=Proyecto;Trusted_Connection=True;";
            iAplicacion = new DetalleComprasAplicacion(iConexion);
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
            var compra = iConexion!.Compras.FirstOrDefault(x => x.Id_compra == 1);
            var comic = iConexion!.Comics.FirstOrDefault(x => x.Id_comic == 1);
            var pago = iConexion!.Pagos.FirstOrDefault(x => x.Id_pago == 1);
            entidad = EntidadesNucleo.DetalleCompras(compra, comic, pago)!;
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