using Lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class DevolucionesAplicacion : IDevolucionesAplicacion
    {
        private IConexion? IConexion = null;

        public DevolucionesAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Devoluciones? Borrar(Devoluciones? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id_devolucion == 0)
                throw new Exception("lbNoSeGuardo");

            var entidadExistente = this.IConexion!.Devoluciones!.Find(entidad.Id_devolucion);
            if (entidadExistente == null)
                throw new Exception("lbEntidadNoEncontrada");

            this.IConexion!.Devoluciones!.Remove(entidadExistente);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Devoluciones? Guardar(Devoluciones? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id_devolucion != 0)
                throw new Exception("lbYaSeGuardo");

            if (string.IsNullOrWhiteSpace(entidad.Motivo))
                throw new Exception("lbMotivoRequerido");

            if (entidad.Cantidad_devuelta <= 0)
                throw new Exception("lbCantidadDevueltaInvalida");

            if (entidad.Fecha_inicio == default(DateTime))
                entidad.Fecha_inicio = DateTime.Now;

            this.IConexion!.Devoluciones!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Devoluciones> Listar()
        {
            var devoluciones = this.IConexion!.Devoluciones!.Take(20).ToList();
            return devoluciones ?? new List<Devoluciones>();
        }

        public Devoluciones? Modificar(Devoluciones? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id_devolucion == 0)
                throw new Exception("lbNoSeGuardo");

            var entidadExistente = this.IConexion!.Devoluciones!.Find(entidad.Id_devolucion);
            if (entidadExistente == null)
                throw new Exception("lbEntidadNoEncontrada");

            entidadExistente.Motivo = entidad.Motivo;
            entidadExistente.Fecha_inicio = entidad.Fecha_inicio;
            entidadExistente.Fecha_fin = entidad.Fecha_fin;
            entidadExistente.Estado_devolucion = entidad.Estado_devolucion;
            entidadExistente.Cantidad_devuelta = entidad.Cantidad_devuelta;
            entidadExistente.Cliente = entidad.Cliente;
            entidadExistente.Detalle_compra = entidad.Detalle_compra;

            this.IConexion.SaveChanges();
            return entidadExistente;
        }
    }
}
