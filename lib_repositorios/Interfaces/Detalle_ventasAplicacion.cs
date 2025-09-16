using Lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IDetalle_ventasAplicacion
    {
        void Configurar(string StringConexion);
        List<DetalleVentas> Listar();
        DetalleVentas? Guardar(DetalleVentas? entidad);
        DetalleVentas? Modificar(DetalleVentas? entidad);
        DetalleVentas? Borrar(DetalleVentas? entidad);
    }
}