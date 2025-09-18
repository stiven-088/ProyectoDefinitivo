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

            var entidadExistente = this.IConexion!.ComicPromociones!.Find(entidad.Id);
            if (entidadExistente == null)
                throw new Exception("lbEntidadNoEncontrada");

            this.IConexion!.ComicPromociones!.Remove(entidadExistente);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Comic_promociones? Guardar(Comic_promociones? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            if (string.IsNullOrWhiteSpace(entidad.Estado))
                throw new Exception("lbEstadoRequerido");

            if (entidad.Fecha_asignacion == default(DateTime))
                entidad.Fecha_asignacion = DateTime.Now;

            this.IConexion!.ComicPromociones!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Comic_promociones> Listar()
        {
            var comicPromociones = this.IConexion!.ComicPromociones!.Take(20).ToList();
            return comicPromociones ?? new List<Comic_promociones>();
        }

        public Comic_promociones? Modificar(Comic_promociones? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            var entidadExistente = this.IConexion!.ComicPromociones!.Find(entidad.Id);
            if (entidadExistente == null)
                throw new Exception("lbEntidadNoEncontrada");

            entidadExistente.Fecha_asignacion = entidad.Fecha_asignacion;
            entidadExistente.Estado = entidad.Estado;
            entidadExistente.Aplicacion = entidad.Aplicacion;
            entidadExistente.Tipo_promocion = entidad.Tipo_promocion;
            entidadExistente.Observaciones = entidad.Observaciones;
            entidadExistente.Promocion = entidad.Promocion;
            entidadExistente.Comic = entidad.Comic;

            this.IConexion.SaveChanges();
            return entidadExistente;
        }
    }
}
