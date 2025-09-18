using Lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class DetalleComprasAplicacion : IDetalleComprasAplicacion
    {
        private IConexion? IConexion = null;

        public DetalleComprasAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public DetalleCompras? Borrar(DetalleCompras? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Verificar que la entidad existe en la base de datos
            var entidadExistente = this.IConexion!.DetalleCompras!.Find(entidad.Id);
            if (entidadExistente == null)
                throw new Exception("lbEntidadNoEncontrada");

            this.IConexion!.DetalleCompras!.Remove(entidadExistente);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public DetalleCompras? Guardar(DetalleCompras? entidad)
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

            this.IConexion!.DetalleCompras!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<DetalleCompras> Listar()
        {
            var detalleCompras = this.IConexion!.DetalleCompras!.Take(20).ToList();
            return detalleCompras ?? new List<DetalleCompras>();
        }

        public DetalleCompras? Modificar(DetalleCompras? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            var entidadExistente = this.IConexion!.DetalleCompras!.Find(entidad.Id);
            if (entidadExistente == null)
                throw new Exception("lbEntidadNoEncontrada");

            entidadExistente.Precio_unitario = entidad.Precio_unitario;
            entidadExistente.Cantidad = entidad.Cantidad;
            entidadExistente.Subtotal = entidad.Subtotal;
            entidadExistente.Descuento = entidad.Descuento;
            entidadExistente.Tipo_producto_comprado = entidad.Tipo_producto_comprado;
            entidadExistente.Compra = entidad.Compra;
            entidadExistente.Comic = entidad.Comic;
            entidadExistente.Pago = entidad.Pago;

            this.IConexion.SaveChanges();
            return entidadExistente;
        }
    }
}
