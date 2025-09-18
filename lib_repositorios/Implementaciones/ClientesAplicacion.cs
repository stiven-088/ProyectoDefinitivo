using Lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class ClientesAplicacion : IClientesAplicacion
    {
        private IConexion? IConexion = null;

        public ClientesAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Clientes? Borrar(Clientes? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id_cliente == 0)
                throw new Exception("lbNoSeGuardo");

            var entidadExistente = this.IConexion!.Clientes!.Find(entidad.Id_cliente);
            if (entidadExistente == null)
                throw new Exception("lbEntidadNoEncontrada");

            this.IConexion!.Clientes!.Remove(entidadExistente);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Clientes? Guardar(Clientes? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id_cliente != 0)
                throw new Exception("lbYaSeGuardo");

            if (string.IsNullOrWhiteSpace(entidad.Nombre))
                throw new Exception("lbNombreRequerido");

            if (string.IsNullOrWhiteSpace(entidad.Email))
                throw new Exception("lbEmailRequerido");

            if (entidad.Fecha_registro == default(DateTime))
                entidad.Fecha_registro = DateTime.Now;

            this.IConexion!.Clientes!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Clientes> Listar()
        {
            var clientes = this.IConexion!.Clientes!.Take(20).ToList();
            return clientes ?? new List<Clientes>();
        }

        public Clientes? Modificar(Clientes? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id_cliente == 0)
                throw new Exception("lbNoSeGuardo");

            var entidadExistente = this.IConexion!.Clientes!.Find(entidad.Id_cliente);
            if (entidadExistente == null)
                throw new Exception("lbEntidadNoEncontrada");

            entidadExistente.Nombre = entidad.Nombre;
            entidadExistente.Email = entidad.Email;
            entidadExistente.Direccion = entidad.Direccion;
            entidadExistente.Telefono = entidad.Telefono;
            entidadExistente.Membresia = entidad.Membresia;

            this.IConexion.SaveChanges();
            return entidadExistente;
        }
    }
}
