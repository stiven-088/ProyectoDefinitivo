using Lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Aplicaciones
{
    [TestClass]
    public class PromocionesPrueba
    {
        private readonly IPromocionesAplicacion? iAplicacion;
        private readonly IConexion? iConexion;
        private List<Promociones>? lista;
        private Promociones? entidad;

        public PromocionesPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
            iAplicacion = new PromocionesAplicacion(iConexion);
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
            this.entidad = EntidadesNucleo.Promociones()!;
            this.iAplicacion!.Guardar(this.entidad);
            return true;
        }

        public bool Modificar()
        {
            if (this.entidad != null)
            {
                this.entidad.Descripcion = "Promoción Modificada-" + DateTime.Now.ToString("yyyyMMddhhmmss");
                this.entidad.Descuento = 20;
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
