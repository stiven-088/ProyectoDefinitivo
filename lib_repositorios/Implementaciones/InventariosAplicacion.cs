using Lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class InventariosAplicacion : IIventariosAplicacion
    {
        private IConexion? IConexion = null;

        public InventariosAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Inventarios? Borrar(Inventarios? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id_inventario == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            this.IConexion!.Inventarios!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Inventarios? Guardar(Inventarios? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id_inventario != 0)
                throw new Exception("lbYaSeGuardo");

            // Operaciones

            this.IConexion!.Inventarios!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Inventarios> Listar()
        {
            return this.IConexion!.Inventarios!.Take(20).ToList();
        }

        public Inventarios? Modificar(Inventarios? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id_inventario == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            var entry = this.IConexion!.Entry<Inventarios>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
