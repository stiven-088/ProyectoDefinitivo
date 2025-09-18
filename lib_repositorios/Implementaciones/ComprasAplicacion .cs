using Lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class ComprasAplicacion : IComprasAplicacion
    {
        private IConexion? IConexion = null;

        public ComprasAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Compras? Borrar(Compras? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id_compra == 0)
                throw new Exception("lbNoSeGuardo");

            var entidadExistente = this.IConexion!.Compras!.Find(entidad.Id_compra);
            if (entidadExistente == null)
                throw new Exception("lbEntidadNoEncontrada");

            this.IConexion!.Compras!.Remove(entidadExistente);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Compras? Guardar(Compras? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id_compra != 0)
                throw new Exception("lbYaSeGuardo");

            if (string.IsNullOrWhiteSpace(entidad.Nombre_comic))
                throw new Exception("lbNombreComicRequerido");

            if (entidad.Cantidad <= 0)
                throw new Exception("lbCantidadInvalida");

            if (entidad.Total <= 0)
                throw new Exception("lbTotalInvalido");

            if (entidad.Fecha_compra == default(DateTime))
                entidad.Fecha_compra = DateTime.Now;

            this.IConexion!.Compras!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Compras> Listar()
        {
            var compras = this.IConexion!.Compras!.Take(20).ToList();
            return compras ?? new List<Compras>();
        }

        public Compras? Modificar(Compras? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id_compra == 0)
                throw new Exception("lbNoSeGuardo");

            var entidadExistente = this.IConexion!.Compras!.Find(entidad.Id_compra);
            if (entidadExistente == null)
                throw new Exception("lbEntidadNoEncontrada");

            entidadExistente.Fecha_compra = entidad.Fecha_compra;
            entidadExistente.Nombre_comic = entidad.Nombre_comic;
            entidadExistente.Cantidad = entidad.Cantidad;
            entidadExistente.Total = entidad.Total;
            entidadExistente.Estado_compra = entidad.Estado_compra;
            entidadExistente.Cliente = entidad.Cliente;

            this.IConexion.SaveChanges();
            return entidadExistente;
        }
    }
}
