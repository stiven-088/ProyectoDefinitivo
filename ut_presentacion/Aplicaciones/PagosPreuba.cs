using Lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Aplicaciones
{
    [TestClass]
    public class PagosPrueba
    {
        private readonly IPagosAplicacion? iAplicacion;
        private readonly IConexion? iConexion;
        private List<Pagos>? lista;
        private Pagos? entidad;

        public PagosPrueba()
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
            this.entidad = EntidadesNucleo.Pagos()!;
            this.iAplicacion!.Guardar(this.entidad);
            return true;
        }

        public bool Modificar()
        {
            if (this.entidad != null)
            {
                this.entidad.Estado = "Procesado";
                this.entidad.Metodo = "Transferencia-" + DateTime.Now.ToString("yyyyMMddhhmmss");
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
