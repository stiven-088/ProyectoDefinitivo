using Lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IIventariosAplicacion
    {
        void Configurar(string StringConexion);
        List<Inventarios> Listar();
        Inventarios? Guardar(Inventarios? entidad);
        Inventarios? Modificar(Inventarios? entidad);
        Inventarios? Borrar(Inventarios? entidad);
    }
}