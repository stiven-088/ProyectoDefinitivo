using Lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class InventariosAplicacion : IIventariosAplicacion
    {
        private IConexion? IConexion = null;

        public InventariosAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Inventarios? Borrar(Inventarios? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id_inventario == 0)
                throw new Exception("lbNoSeGuardo");

            var entidadExistente = this.IConexion!.Inventarios!.Find(entidad.Id_inventario);
            if (entidadExistente == null)
                throw new Exception("lbEntidadNoEncontrada");

            this.IConexion!.Inventarios!.Remove(entidadExistente);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Inventarios? Guardar(Inventarios? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id_inventario != 0)
                throw new Exception("lbYaSeGuardo");

            if (string.IsNullOrWhiteSpace(entidad.Tipo_producto))
                throw new Exception("lbTipoProductoRequerido");

            if (entidad.Stock < 0)
                throw new Exception("lbStockInvalido");

            if (entidad.Fecha_actualizacion == default(DateTime))
                entidad.Fecha_actualizacion = DateTime.Now;

            this.IConexion!.Inventarios!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Inventarios> Listar()
        {
            var inventarios = this.IConexion!.Inventarios!.Take(20).ToList();
            return inventarios ?? new List<Inventarios>();
        }

        public Inventarios? Modificar(Inventarios? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id_inventario == 0)
                throw new Exception("lbNoSeGuardo");

            var entidadExistente = this.IConexion!.Inventarios!.Find(entidad.Id_inventario);
            if (entidadExistente == null)
                throw new Exception("lbEntidadNoEncontrada");

            entidadExistente.Tipo_producto = entidad.Tipo_producto;
            entidadExistente.Stock = entidad.Stock;
            entidadExistente.Nombre = entidad.Nombre;
            entidadExistente.Ubicacion = entidad.Ubicacion;
            entidadExistente.Fecha_actualizacion = DateTime.Now;

            this.IConexion.SaveChanges();
            return entidadExistente;
        }
    }
}
