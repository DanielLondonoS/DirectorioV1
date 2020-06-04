using DirectorioV1.Api.Business.Models;
using DirectorioV1.Api.DataAccess.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DirectorioV1.Api.DataAccess.Mappers
{
    public static class ClientesMapper
    {
        public static ClientesEntity map(Clientes dto)
        {
            return new ClientesEntity()
            {
                Id = dto.Id,
                Estado = dto.Estado,
                Categoria_Id = dto.Categoria_Id,
                Correo = dto.Correo,
                Documento = dto.Documento,
                Fecha_Creacion = dto.Fecha_Creacion,
                Nombre = dto.Nombre,
                Tipo_Documento = dto.Tipo_Documento
            };
        }

        public static Clientes map(ClientesEntity dto)
        {
            return new Clientes()
            {
                Id = dto.Id,
                Estado = dto.Estado,
                Categoria_Id = dto.Categoria_Id,
                Correo = dto.Correo,
                Documento = dto.Documento,
                Fecha_Creacion = dto.Fecha_Creacion.Value,
                Nombre = dto.Nombre,
                Tipo_Documento = dto.Tipo_Documento
            };
        }

        public static List<Clientes> map(IEnumerable<ClientesEntity> lista)
        {
            List<Clientes> listaResultante = new List<Clientes>();
            foreach (var item in lista)
            {
                var dto = map(item);
                listaResultante.Add(dto);
            }
            return listaResultante;
        }

        public static List<ClientesEntity> map(IEnumerable<Clientes> lista)
        {
            List<ClientesEntity> listaResultante = new List<ClientesEntity>();
            foreach (var item in lista)
            {
                var dto = map(item);
                listaResultante.Add(dto);
            }
            return listaResultante;
        }
    }
}
