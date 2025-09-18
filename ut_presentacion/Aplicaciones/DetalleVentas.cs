/*
using Lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Aplicaciones
{
    [TestClass]
    public class DetalleVentasPrueba
    {
        private readonly IDetalle_ventasAplicacion? iAplicacion;
        private readonly IConexion? iConexion;
        private List<DetalleVentas>? lista;
        private DetalleVentas? entidad;

        public DetalleVentasPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = "Server=localhost;Database=Proyecto;Trusted_Connection=True;";
            iAplicacion = new Detalle_ventasAplicacion(iConexion);
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
            var venta = iConexion!.Ventas.FirstOrDefault(x => x.Id_venta == 1);
            var comic = iConexion!.Comics.FirstOrDefault(x => x.Id_comic == 1);
            entidad = EntidadesNucleo.DetalleVentas(venta, comic)!;
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