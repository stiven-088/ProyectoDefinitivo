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

            if (entidad!.Id_promocion== 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            this.IConexion!.Promociones!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Promociones? Guardar(Promociones? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id_promocion != 0)
                throw new Exception("lbYaSeGuardo");

            // Operaciones

            this.IConexion!.Promociones!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Promociones> Listar()
        {
            return this.IConexion!.Promociones!.Take(20).ToList();
        }

        public Promociones? Modificar(Promociones? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id_promocion == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            var entry = this.IConexion!.Entry<Promociones>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
