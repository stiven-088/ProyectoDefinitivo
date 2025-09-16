using Lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class CategoriasPrueba
    {
        private readonly IConexion? iConexion;
        private List<Categorias>? lista;
        private Categorias? entidad;

        public CategoriasPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
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
            lista = iConexion!.Categorias!.ToList();
            return lista.Count > 0;
        }
        public bool Guardar()
        {
            entidad = EntidadesNucleo.Categorias()!;
            iConexion!.Categorias!.Add(entidad);
            iConexion!.SaveChanges();
            return true;
        }
        public bool Modificar()
        {
            entidad!.Nombre = "Categoria Modificada";
            var entry = iConexion!.Entry<Categorias>(entidad);
            entry.State = EntityState.Modified;
            iConexion!.SaveChanges();
            return true;
        }
        public bool Borrar()
        {
            iConexion!.Categorias!.Remove(entidad!);
            iConexion!.SaveChanges();
            return true;
        }
    }
}