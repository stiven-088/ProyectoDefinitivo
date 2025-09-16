using Lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IDetalleComprasAplicacion
    {
        void Configurar(string StringConexion);
        List<DetalleCompras> Listar();
        DetalleCompras? Guardar(DetalleCompras? entidad);
        DetalleCompras? Modificar(DetalleCompras? entidad);
        DetalleCompras? Borrar(DetalleCompras? entidad);
    }
}