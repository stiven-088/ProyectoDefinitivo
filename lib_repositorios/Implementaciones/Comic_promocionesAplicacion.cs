using Lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class Comic_promocionesAplicacion : IComic_promocionesAplicacion
    {
        private IConexion? IConexion = null;

        public Comic_promocionesAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Comic_promociones? Borrar(Comic_promociones? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            this.IConexion!.ComicPromociones!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Comic_promociones? Guardar(Comic_promociones? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            // Operaciones

            this.IConexion!.ComicPromociones!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Comic_promociones> Listar()
        {
            return this.IConexion!.ComicPromociones!.Take(20).ToList();
        }

        public Comic_promociones? Modificar(Comic_promociones? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            var entry = this.IConexion!.Entry<Comic_promociones>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
