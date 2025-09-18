using Lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class CategoriasAplicacion : ICategoriasAplicacion
    {
        private IConexion? IConexion = null;

        public CategoriasAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Categorias? Borrar(Categorias? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id_categorias == 0)
                throw new Exception("lbNoSeGuardo");

            
            var entidadExistente = this.IConexion!.Categorias!.Find(entidad.Id_categorias);
            if (entidadExistente == null)
                throw new Exception("lbEntidadNoEncontrada");

            this.IConexion!.Categorias!.Remove(entidadExistente);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Categorias? Guardar(Categorias? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id_categorias != 0)
                throw new Exception("lbYaSeGuardo");

            
            if (string.IsNullOrWhiteSpace(entidad.Nombre))
                throw new Exception("lbNombreRequerido");

            if (entidad.Fecha_creacion == default(DateTime))
                entidad.Fecha_creacion = DateTime.Now;

            this.IConexion!.Categorias!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Categorias> Listar()
        {
            var categorias = this.IConexion!.Categorias!.Take(20).ToList();
            return categorias ?? new List<Categorias>();
        }

        public Categorias? Modificar(Categorias? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id_categorias == 0)
                throw new Exception("lbNoSeGuardo");

            var entidadExistente = this.IConexion!.Categorias!.Find(entidad.Id_categorias);
            if (entidadExistente == null)
                throw new Exception("lbEntidadNoEncontrada");

            entidadExistente.Nombre = entidad.Nombre;
            entidadExistente.Descripcion = entidad.Descripcion;
            entidadExistente.Estado = entidad.Estado;
            entidadExistente.Prioridad = entidad.Prioridad;

            this.IConexion.SaveChanges();
            return entidadExistente;
        }
    }
}
