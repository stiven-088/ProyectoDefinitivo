using Lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class MembresiasAplicacion : IMembresiasAplicacion
    {
        private IConexion? IConexion = null;

        public MembresiasAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Membresias? Borrar(Membresias? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id_membresia == 0)
                throw new Exception("lbNoSeGuardo");

            var entidadExistente = this.IConexion!.Membresias!.Find(entidad.Id_membresia);
            if (entidadExistente == null)
                throw new Exception("lbEntidadNoEncontrada");

            this.IConexion!.Membresias!.Remove(entidadExistente);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Membresias? Guardar(Membresias? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id_membresia != 0)
                throw new Exception("lbYaSeGuardo");

            if (string.IsNullOrWhiteSpace(entidad.Tipo))
                throw new Exception("lbTipoRequerido");

            if (entidad.Precio <= 0)
                throw new Exception("lbPrecioInvalido");

            if (entidad.Fecha_inicio == default(DateTime))
                entidad.Fecha_inicio = DateTime.Now;

            if (entidad.Fecha_fin == default(DateTime))
                entidad.Fecha_fin = DateTime.Now.AddMonths(12);

            this.IConexion!.Membresias!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Membresias> Listar()
        {
            var membresias = this.IConexion!.Membresias!.Take(20).ToList();
            return membresias ?? new List<Membresias>();
        }

        public Membresias? Modificar(Membresias? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id_membresia == 0)
                throw new Exception("lbNoSeGuardo");

            var entidadExistente = this.IConexion!.Membresias!.Find(entidad.Id_membresia);
            if (entidadExistente == null)
                throw new Exception("lbEntidadNoEncontrada");

            entidadExistente.Tipo = entidad.Tipo;
            entidadExistente.Precio = entidad.Precio;
            entidadExistente.Beneficio = entidad.Beneficio;
            entidadExistente.Fecha_inicio = entidad.Fecha_inicio;
            entidadExistente.Fecha_fin = entidad.Fecha_fin;

            this.IConexion.SaveChanges();
            return entidadExistente;
        }
    }
}
