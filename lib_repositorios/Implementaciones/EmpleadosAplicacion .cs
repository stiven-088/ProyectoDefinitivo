using Lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class EmpleadosAplicacion : IEmpleadosAplicacion
    {
        private IConexion? IConexion = null;

        public EmpleadosAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Empleados? Borrar(Empleados? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id_empleado == 0)
                throw new Exception("lbNoSeGuardo");

            var entidadExistente = this.IConexion!.Empleados!.Find(entidad.Id_empleado);
            if (entidadExistente == null)
                throw new Exception("lbEntidadNoEncontrada");

            this.IConexion!.Empleados!.Remove(entidadExistente);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Empleados? Guardar(Empleados? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id_empleado != 0)
                throw new Exception("lbYaSeGuardo");

            if (string.IsNullOrWhiteSpace(entidad.Nombre))
                throw new Exception("lbNombreRequerido");

            if (string.IsNullOrWhiteSpace(entidad.Puesto))
                throw new Exception("lbPuestoRequerido");

            if (entidad.Fecha_contratacion == default(DateTime))
                entidad.Fecha_contratacion = DateTime.Now;

            this.IConexion!.Empleados!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Empleados> Listar()
        {
            var empleados = this.IConexion!.Empleados!.Take(20).ToList();
            return empleados ?? new List<Empleados>();
        }

        public Empleados? Modificar(Empleados? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id_empleado == 0)
                throw new Exception("lbNoSeGuardo");

            var entidadExistente = this.IConexion!.Empleados!.Find(entidad.Id_empleado);
            if (entidadExistente == null)
                throw new Exception("lbEntidadNoEncontrada");

            entidadExistente.Nombre = entidad.Nombre;
            entidadExistente.Puesto = entidad.Puesto;
            entidadExistente.Telefono = entidad.Telefono;
            entidadExistente.Email = entidad.Email;
            entidadExistente.Fecha_contratacion = entidad.Fecha_contratacion;

            this.IConexion.SaveChanges();
            return entidadExistente;
        }
    }
}
