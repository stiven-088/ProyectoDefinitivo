using Lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IComprasAplicacion
    {
        void Configurar(string StringConexion);
        List<Compras> Listar();
        Compras? Guardar(Compras? entidad);
        Compras? Modificar(Compras? entidad);
        Compras? Borrar(Compras? entidad);
    }
}