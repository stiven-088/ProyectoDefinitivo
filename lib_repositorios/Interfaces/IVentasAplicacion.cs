using Lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IVentasAplicacion
    {
        void Configurar(string StringConexion);
        List<Ventas> Listar();
        Ventas? Guardar(Ventas? entidad);
        Ventas? Modificar(Ventas? entidad);
        Ventas? Borrar(Ventas? entidad);
    }
}