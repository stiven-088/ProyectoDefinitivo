using Lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface ICategoriasAplicacion
    {
        void Configurar(string StringConexion);
        List<Categorias> Listar();
        Categorias? Guardar(Categorias? entidad);
        Categorias? Modificar(Categorias? entidad);
        Categorias? Borrar(Categorias? entidad);
    }
}