/*
using Lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Aplicaciones
{
    [TestClass]
    public class VentasPrueba
    {
        private readonly IVentasAplicacion? iAplicacion;
        private readonly IConexion? iConexion;
        private List<Ventas>? lista;
        private Ventas? entidad;

        public VentasPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
            iAplicacion = new VentasAplicacion(iConexion);
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
            var empleado = iConexion!.Empleados.FirstOrDefault(x => x.Id_empleado == 1);
            var proveedor = iConexion!.Proveedores.FirstOrDefault(x => x.Id_proveedor == 1);
            var membresia = iConexion!.Membresias.FirstOrDefault(x => x.Id_membresia == 1);
            entidad = EntidadesNucleo.Ventas(empleado, proveedor, membresia)!;
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