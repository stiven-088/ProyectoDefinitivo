/*
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Aplicaciones
{
    [TestClass]
    public class ComicsPrueba
    {
        private readonly IComicsAplicacion? iAplicacion;
        private readonly IConexion? iConexion;
        private List<Comics>? lista;
        private Comics? entidad;

        public ComicsPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = "Server=localhost;Database=Proyecto;Trusted_Connection=True;";
            iAplicacion = new ComicsAplicacion(iConexion);
        }

        [TestMethod]
        public void Ejecutar()
        {
            Assert.AreEqual(true, Guardar());
            Assert.AreEqual(true, Modificar());
            Assert.AreEqual(true, Listar());
            Assert.AreEqual(true, Borrar());
        }

        public bool Listar()
        {
            lista = iAplicacion!.Listar();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            var categoria = iConexion!.Categorias.FirstOrDefault(x => x.Id_categorias == 1);
            var inventario = iConexion!.Inventarios.FirstOrDefault(x => x.Id_inventario == 1);
            entidad = EntidadesNucleo.Comics(categoria, inventario)!;
            iAplicacion!.Guardar(entidad);
            return true;
        }

        public bool Modificar()
        {
            iAplicacion!.Modificar(entidad);
            return true;
        }

        public bool Borrar()
        {
            iAplicacion!.Borrar(entidad);
*/