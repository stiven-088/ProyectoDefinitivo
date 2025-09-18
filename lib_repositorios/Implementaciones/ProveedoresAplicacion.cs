using Lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class ProveedoresAplicacion : IProveedoresAplicacion
    {
        private IConexion? IConexion = null;

        public ProveedoresAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Proveedores? Borrar(Proveedores? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id_proveedor == 0)
                throw new Exception("lbNoSeGuardo");

            var entidadExistente = this.IConexion!.Proveedores!.Find(entidad.Id_proveedor);
            if (entidadExistente == null)
                throw new Exception("lbEntidadNoEncontrada");

            this.IConexion!.Proveedores!.Remove(entidadExistente);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Proveedores? Guardar(Proveedores? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id_proveedor != 0)
                throw new Exception("lbYaSeGuardo");

            if (string.IsNullOrWhiteSpace(entidad.Nombre))
                throw new Exception("lbNombreRequerido");

            if (string.IsNullOrWhiteSpace(entidad.Email))
                throw new Exception("lbEmailRequerido");

            this.IConexion!.Proveedores!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Proveedores> Listar()
        {
            var proveedores = this.IConexion!.Proveedores!.Take(20).ToList();
            return proveedores ?? new List<Proveedores>();
        }

        public Proveedores? Modificar(Proveedores? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id_proveedor == 0)
                throw new Exception("lbNoSeGuardo");

            var entidadExistente = this.IConexion!.Proveedores!.Find(entidad.Id_proveedor);
            if (entidadExistente == null)
                throw new Exception("lbEntidadNoEncontrada");

            entidadExistente.Nombre = entidad.Nombre;
            entidadExistente.Telefono = entidad.Telefono;
            entidadExistente.Email = entidad.Email;
            entidadExistente.Direccion = entidad.Direccion;
            entidadExistente.Ciudad = entidad.Ciudad;

            this.IConexion.SaveChanges();
            return entidadExistente;
        }
    }
}
