using DirectorioV1.Api.Business.Models;
using DirectorioV1.Api.DataAccess.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DirectorioV1.Api.DataAccess.Mappers
{
    public static class UsuariosMapper
    {
        public static UsuariosEntity map(Usuarios dto)
        {
            if (dto == null)
                return null;
            return new UsuariosEntity()
            {
                Id = dto.Id.ToString(),
                Apellido = dto.Apellido,
                //Contrasena = dto.Contrasena,
                //Correo = dto.Correo,
                Nombre = dto.Nombre
            };
        }

        public static Usuarios map(UsuariosEntity dto)
        {
            if (dto == null)
                return null;
            return new Usuarios()
            {
                Id = int.Parse(dto.Id),
                Apellido = dto.Apellido,
                //Contrasena =dto.Contrasena,
                //Correo = dto.Correo,
                Nombre = dto.Nombre
            };
        }

        public static List<Usuarios> map(IEnumerable<UsuariosEntity> lista)
        {
            if (lista == null)
                return null;
            List<Usuarios> listaResultante = new List<Usuarios>();
            foreach (var item in lista)
            {
                var dto = map(item);
                listaResultante.Add(dto);
            }
            return listaResultante;
        }

        public static List<UsuariosEntity> map(IEnumerable<Usuarios> lista)
        {
            if (lista == null)
                return null;
            List<UsuariosEntity> listaResultante = new List<UsuariosEntity>();
            foreach (var item in lista)
            {
                var dto = map(item);
                listaResultante.Add(dto);
            }
            return listaResultante;
        }
    }
}
