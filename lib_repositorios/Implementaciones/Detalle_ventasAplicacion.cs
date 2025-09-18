using Lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class Detalle_ventasAplicacion : IDetalle_ventasAplicacion
    {
        private IConexion? IConexion = null;

        public Detalle_ventasAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public DetalleVentas? Borrar(DetalleVentas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Verificar que la entidad existe en la base de datos
            var entidadExistente = this.IConexion!.DetalleVentas!.Find(entidad.Id);
            if (entidadExistente == null)
                throw new Exception("lbEntidadNoEncontrada");

            this.IConexion!.DetalleVentas!.Remove(entidadExistente);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public DetalleVentas? Guardar(DetalleVentas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            // Validaciones básicas
            if (entidad.Precio_unitario <= 0)
                throw new Exception("lbPrecioUnitarioInvalido");

            if (entidad.Cantidad <= 0)
                throw new Exception("lbCantidadInvalida");

            if (entidad.Subtotal <= 0)
                throw new Exception("lbSubtotalInvalido");

            this.IConexion!.DetalleVentas!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<DetalleVentas> Listar()
        {
            var detalleVentas = this.IConexion!.DetalleVentas!.Take(20).ToList();
            return detalleVentas ?? new List<DetalleVentas>();
        }

        public DetalleVentas? Modificar(DetalleVentas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            var entidadExistente = this.IConexion!.DetalleVentas!.Find(entidad.Id);
            if (entidadExistente == null)
                throw new Exception("lbEntidadNoEncontrada");

            entidadExistente.Precio_unitario = entidad.Precio_unitario;
            entidadExistente.Cantidad = entidad.Cantidad;
            entidadExistente.Subtotal = entidad.Subtotal;
            entidadExistente.Descuento = entidad.Descuento;
            entidadExistente.Tipo_producto_vendido = entidad.Tipo_producto_vendido;
            entidadExistente.Venta = entidad.Venta;
            entidadExistente.Comic = entidad.Comic;

            this.IConexion.SaveChanges();
            return entidadExistente;
        }
    }
}
