using Lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class ComicsAplicacion : IComicsAplicacion
    {
        private IConexion? IConexion = null;

        public ComicsAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Comics? Borrar(Comics? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id_comic == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            this.IConexion!.Comics!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Comics? Guardar(Comics? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id_comic!= 0)
                throw new Exception("lbYaSeGuardo");

            // Operaciones

            this.IConexion!.Comics!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Comics> Listar()
        {
            return this.IConexion!.Comics!.Take(20).ToList();
        }

        public Comics? Modificar(Comics? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id_comic== 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            var entry = this.IConexion!.Entry<Comics>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
