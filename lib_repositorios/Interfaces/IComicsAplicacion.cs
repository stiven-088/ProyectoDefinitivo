using Lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IComicsAplicacion
    {
        void Configurar(string StringConexion);
        List<Comics> Listar();
        Comics? Guardar(Comics? entidad);
        Comics? Modificar(Comics? entidad);
        Comics? Borrar(Comics? entidad);
    }
}