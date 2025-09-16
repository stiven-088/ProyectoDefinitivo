using Lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class Detalle_ventasAplicacion : IDetalle_ventasAplicacion
    {
        private IConexion? IConexion = null;

        public Detalle_ventasAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public DetalleVentas? Borrar(DetalleVentas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id!= 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            this.IConexion!.DetalleVentas!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public DetalleVentas? Guardar(DetalleVentas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id!= 0)
                throw new Exception("lbYaSeGuardo");

            // Operaciones

            this.IConexion!.DetalleVentas!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<DetalleVentas> Listar()
        {
            return this.IConexion!.DetalleVentas!.Take(20).ToList();
        }

        public DetalleVentas? Modificar(DetalleVentas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            var entry = this.IConexion!.Entry<DetalleVentas>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
