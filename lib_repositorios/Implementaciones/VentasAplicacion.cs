using Lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class VentasAplicacion : IVentasAplicacion
    {
        private IConexion? IConexion = null;

        public VentasAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Ventas? Borrar(Ventas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id_venta == 0)
                throw new Exception("lbNoSeGuardo");

            var entidadExistente = this.IConexion!.Ventas!.Find(entidad.Id_venta);
            if (entidadExistente == null)
                throw new Exception("lbEntidadNoEncontrada");

            this.IConexion!.Ventas!.Remove(entidadExistente);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Ventas? Guardar(Ventas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id_venta != 0)
                throw new Exception("lbYaSeGuardo");

            if (entidad.Total <= 0)
                throw new Exception("lbTotalInvalido");

            if (string.IsNullOrWhiteSpace(entidad.Metodo_pago))
                throw new Exception("lbMetodoPagoRequerido");

            if (entidad.Fecha_venta == default(DateTime))
                entidad.Fecha_venta = DateTime.Now;

            this.IConexion!.Ventas!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Ventas> Listar()
        {
            var ventas = this.IConexion!.Ventas!.Take(20).ToList();
            return ventas ?? new List<Ventas>();
        }

        public Ventas? Modificar(Ventas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id_venta == 0)
                throw new Exception("lbNoSeGuardo");

            var entidadExistente = this.IConexion!.Ventas!.Find(entidad.Id_venta);
            if (entidadExistente == null)
                throw new Exception("lbEntidadNoEncontrada");

            entidadExistente.Fecha_venta = entidad.Fecha_venta;
            entidadExistente.Total = entidad.Total;
            entidadExistente.Metodo_pago = entidad.Metodo_pago;
            entidadExistente.Estado_venta = entidad.Estado_venta;
            entidadExistente.Tipo_venta = entidad.Tipo_venta;
            entidadExistente.Empleado = entidad.Empleado;
            entidadExistente.Proveedor = entidad.Proveedor;
            entidadExistente.Membresia = entidad.Membresia;

            this.IConexion.SaveChanges();
            return entidadExistente;
        }
    }
}
