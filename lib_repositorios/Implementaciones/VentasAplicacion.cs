using Lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class VentasAplicacion : IVentasAplicacion
    {
        private IConexion? IConexion = null;

        public VentasAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Ventas? Borrar(Ventas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id_venta== 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            this.IConexion!.Ventas!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Ventas? Guardar(Ventas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id_venta!= 0)
                throw new Exception("lbYaSeGuardo");

            // Operaciones

            this.IConexion!.Ventas!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Ventas> Listar()
        {
            return this.IConexion!.Ventas!.Take(20).ToList();
        }

        public Ventas? Modificar(Ventas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id_venta == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            var entry = this.IConexion!.Entry<Ventas>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
