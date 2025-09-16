﻿using Lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IDevolucionesAplicacion
    {
        void Configurar(string StringConexion);
        List<Devoluciones> Listar();
        Devoluciones? Guardar(Devoluciones? entidad);
        Devoluciones? Modificar(Devoluciones? entidad);
        Devoluciones? Borrar(Devoluciones? entidad);
    }
}