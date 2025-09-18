using Lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class PagosAplicacion : IPagosAplicacion
    {
        private IConexion? IConexion = null;

        public PagosAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Pagos? Borrar(Pagos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id_pago == 0)
                throw new Exception("lbNoSeGuardo");

            var entidadExistente = this.IConexion!.Pagos!.Find(entidad.Id_pago);
            if (entidadExistente == null)
                throw new Exception("lbEntidadNoEncontrada");

            this.IConexion!.Pagos!.Remove(entidadExistente);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Pagos? Guardar(Pagos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id_pago != 0)
                throw new Exception("lbYaSeGuardo");

            if (string.IsNullOrWhiteSpace(entidad.Metodo))
                throw new Exception("lbMetodoRequerido");

            if (entidad.Monto <= 0)
                throw new Exception("lbMontoInvalido");

            if (entidad.Fecha_pago == default(DateTime))
                entidad.Fecha_pago = DateTime.Now;

            this.IConexion!.Pagos!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Pagos> Listar()
        {
            var pagos = this.IConexion!.Pagos!.Take(20).ToList();
            return pagos ?? new List<Pagos>();
        }

        public Pagos? Modificar(Pagos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id_pago == 0)
                throw new Exception("lbNoSeGuardo");

            var entidadExistente = this.IConexion!.Pagos!.Find(entidad.Id_pago);
            if (entidadExistente == null)
                throw new Exception("lbEntidadNoEncontrada");

            entidadExistente.Metodo = entidad.Metodo;
            entidadExistente.Fecha_pago = entidad.Fecha_pago;
            entidadExistente.Monto = entidad.Monto;
            entidadExistente.Estado = entidad.Estado;
            entidadExistente.Referencia_transaccion = entidad.Referencia_transaccion;

            this.IConexion.SaveChanges();
            return entidadExistente;
        }
    }
}
