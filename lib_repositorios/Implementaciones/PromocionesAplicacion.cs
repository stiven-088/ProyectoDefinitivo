using Lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class PromocionesAplicacion : IPromocionesAplicacion
    {
        private IConexion? IConexion = null;

        public PromocionesAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Promociones? Borrar(Promociones? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id_promocion == 0)
                throw new Exception("lbNoSeGuardo");

            var entidadExistente = this.IConexion!.Promociones!.Find(entidad.Id_promocion);
            if (entidadExistente == null)
                throw new Exception("lbEntidadNoEncontrada");

            this.IConexion!.Promociones!.Remove(entidadExistente);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Promociones? Guardar(Promociones? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id_promocion != 0)
                throw new Exception("lbYaSeGuardo");

            if (string.IsNullOrWhiteSpace(entidad.Descripcion))
                throw new Exception("lbDescripcionRequerida");

            if (entidad.Descuento <= 0 || entidad.Descuento > 100)
                throw new Exception("lbDescuentoInvalido");

            if (entidad.Fecha_inicio == default(DateTime))
                entidad.Fecha_inicio = DateTime.Now;

            if (entidad.Fecha_fin == default(DateTime))
                entidad.Fecha_fin = DateTime.Now.AddMonths(1);

            this.IConexion!.Promociones!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Promociones> Listar()
        {
            var promociones = this.IConexion!.Promociones!.Take(20).ToList();
            return promociones ?? new List<Promociones>();
        }

        public Promociones? Modificar(Promociones? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id_promocion == 0)
                throw new Exception("lbNoSeGuardo");

            var entidadExistente = this.IConexion!.Promociones!.Find(entidad.Id_promocion);
            if (entidadExistente == null)
                throw new Exception("lbEntidadNoEncontrada");

            entidadExistente.Descripcion = entidad.Descripcion;
            entidadExistente.Descuento = entidad.Descuento;
            entidadExistente.Fecha_inicio = entidad.Fecha_inicio;
            entidadExistente.Fecha_fin = entidad.Fecha_fin;
            entidadExistente.Codigo = entidad.Codigo;

            this.IConexion.SaveChanges();
            return entidadExistente;
        }
    }
}
