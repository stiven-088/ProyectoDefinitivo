using Lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IComic_promocionesAplicacion
    {
        void Configurar(string StringConexion);
        List<Comic_promociones> Listar();
        Comic_promociones? Guardar(Comic_promociones? entidad);
        Comic_promociones? Modificar(Comic_promociones? entidad);
        Comic_promociones? Borrar(Comic_promociones? entidad);
    }
}