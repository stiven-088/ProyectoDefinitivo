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

            var entidadExistente = this.IConexion!.Comics!.Find(entidad.Id_comic);
            if (entidadExistente == null)
                throw new Exception("lbEntidadNoEncontrada");

            this.IConexion!.Comics!.Remove(entidadExistente);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Comics? Guardar(Comics? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id_comic != 0)
                throw new Exception("lbYaSeGuardo");

            if (string.IsNullOrWhiteSpace(entidad.Nombre))
                throw new Exception("lbNombreRequerido");

            if (entidad.Precio <= 0)
                throw new Exception("lbPrecioInvalido");

            this.IConexion!.Comics!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Comics> Listar()
        {
            var comics = this.IConexion!.Comics!.Take(20).ToList();
            return comics ?? new List<Comics>();
        }

        public Comics? Modificar(Comics? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id_comic == 0)
                throw new Exception("lbNoSeGuardo");

            var entidadExistente = this.IConexion!.Comics!.Find(entidad.Id_comic);
            if (entidadExistente == null)
                throw new Exception("lbEntidadNoEncontrada");

            entidadExistente.Nombre = entidad.Nombre;
            entidadExistente.Editorial = entidad.Editorial;
            entidadExistente.Autor = entidad.Autor;
            entidadExistente.Ilustrador = entidad.Ilustrador;
            entidadExistente.Precio = entidad.Precio;
            entidadExistente.Categoria = entidad.Categoria;
            entidadExistente.Inventario = entidad.Inventario;

            this.IConexion.SaveChanges();
            return entidadExistente;
        }
    }
}
