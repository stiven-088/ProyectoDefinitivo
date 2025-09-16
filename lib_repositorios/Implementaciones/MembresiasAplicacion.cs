﻿using Lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class MembresiasAplicacion : IMembresiasAplicacion
    {
        private IConexion? IConexion = null;

        public MembresiasAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Membresias? Borrar(Membresias? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id_membresia== 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            this.IConexion!.Membresias!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Membresias? Guardar(Membresias? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id_membresia != 0)
                throw new Exception("lbYaSeGuardo");

            // Operaciones

            this.IConexion!.Membresias!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Membresias> Listar()
        {
            return this.IConexion!.Membresias!.Take(20).ToList();
        }

        public Membresias? Modificar(Membresias? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id_membresia == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            var entry = this.IConexion!.Entry<Membresias>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
