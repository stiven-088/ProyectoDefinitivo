﻿using Lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class ClientesPrueba
    {
        private readonly IConexion? iConexion;
        private List<Clientes>? lista;
        private Clientes? entidad;

        public ClientesPrueba()
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
            lista = iConexion!.Clientes!.ToList();
            return lista.Count > 0;
        }
        public bool Guardar()
        {
            entidad = EntidadesNucleo.Clientes()!;
            iConexion!.Clientes!.Add(entidad);
            iConexion!.SaveChanges();
            return true;
        }
        public bool Modificar()
        {
            entidad!.Nombre = "Cliente Modificado";
            var entry = iConexion!.Entry<Clientes>(entidad);
            entry.State = EntityState.Modified;
            iConexion!.SaveChanges();
            return true;
        }
        public bool Borrar()
        {
            iConexion!.Clientes!.Remove(entidad!);
            iConexion!.SaveChanges();
            return true;
        }
    }
}