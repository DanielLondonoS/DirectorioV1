using DirectorioV1.Api.Business.Models;
using DirectorioV1.Api.DataAccess.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DirectorioV1.Api.Business.Mappers
{
    public static class ClientesImagenesMapper
    {
        public static ClientesImagenesEntity map(ClientesImagenes dto)
        {
            if (dto == null)
                return null;
            return new ClientesImagenesEntity()
            {
                Id = dto.Id,
                Estado = dto.Estado,
                ClienteId = dto.ClienteId,
                ImageUrl = dto.ImageUrl,

            };
        }

        public static ClientesImagenes map(ClientesImagenesEntity dto)
        {
            if (dto == null)
                return null;
            return new ClientesImagenes()
            {
                Id = dto.Id,
                Estado = dto.Estado,
                ClienteId = dto.ClienteId,
                ImageUrl = dto.ImageUrl
            };
        }

        public static List<ClientesImagenes> map(IEnumerable<ClientesImagenesEntity> lista)
        {
            if (lista == null)
                return null;
            List<ClientesImagenes> listaResultante = new List<ClientesImagenes>();
            foreach (var item in lista)
            {
                var dto = map(item);
                listaResultante.Add(dto);
            }
            return listaResultante;
        }

        public static List<ClientesImagenesEntity> map(IEnumerable<ClientesImagenes> lista)
        {
            if (lista == null)
                return null;
            List<ClientesImagenesEntity> listaResultante = new List<ClientesImagenesEntity>();
            foreach (var item in lista)
            {
                var dto = map(item);
                listaResultante.Add(dto);
            }
            return listaResultante;
        }
    }
}
