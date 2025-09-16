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

            if (entidad!.Id_categorias== 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            this.IConexion!.Categorias!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Categorias? Guardar(Categorias? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id_categorias != 0)
                throw new Exception("lbYaSeGuardo");

            // Operaciones

            this.IConexion!.Categorias!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Categorias> Listar()
        {
            return this.IConexion!.Categorias!.Take(20).ToList();
        }

        public Categorias? Modificar(Categorias? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id_categorias == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            var entry = this.IConexion!.Entry<Categorias>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
