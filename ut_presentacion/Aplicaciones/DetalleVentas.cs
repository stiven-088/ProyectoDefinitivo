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
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
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
            this.lista = this.iAplicacion!.Listar();
            return lista.Count >= 0;
        }

        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.DetalleVentas()!;
            this.iAplicacion!.Guardar(this.entidad);
            return true;
        }

        public bool Modificar()
        {
            if (this.entidad != null)
            {
                this.entidad.Tipo_producto_vendido = "Producto Vendido Modificado";
                this.entidad.Cantidad = 5;
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
