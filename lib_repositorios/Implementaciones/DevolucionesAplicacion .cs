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

            if (entidad!.Id_devolucion== 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            this.IConexion!.Devoluciones!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Devoluciones? Guardar(Devoluciones? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id_devolucion != 0)
                throw new Exception("lbYaSeGuardo");

            // Operaciones

            this.IConexion!.Devoluciones!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Devoluciones> Listar()
        {
            return this.IConexion!.Devoluciones!.Take(20).ToList();
        }

        public Devoluciones? Modificar(Devoluciones? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id_devolucion== 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            var entry = this.IConexion!.Entry<Devoluciones>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
