using DirectorioV1.Api.Business.Models;
using DirectorioV1.Api.DataAccess.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DirectorioV1.Api.DataAccess.Mappers
{
    public static class PaisesMapper
    {
        public static PaisesEntity map(Paises dto)
        {
            return new PaisesEntity()
            {
                Id = dto.Id,
                Estado = dto.Estado,
                Codigo = dto.Codigo,
                Codigo_Postal = dto.Codigo_Postal,
                Descripcion = dto.Descripcion,
                Latitud = dto.Latitud,
                Longitud = dto.Longitud            
            };
        }

        public static Paises map(PaisesEntity dto)
        {
            return new Paises()
            {
                Id = dto.Id,
                Estado = dto.Estado,
                Codigo = dto.Codigo,
                Codigo_Postal = dto.Codigo_Postal,
                Descripcion = dto.Descripcion,
                Latitud = dto.Latitud,
                Longitud = dto.Longitud
            };
        }

        public static List<Paises> map(IEnumerable<PaisesEntity> lista)
        {
            List<Paises> listaResultante = new List<Paises>();
            foreach (var item in lista)
            {
                var dto = map(item);
                listaResultante.Add(dto);
            }
            return listaResultante;
        }

        public static List<PaisesEntity> map(IEnumerable<Paises> lista)
        {
            List<PaisesEntity> listaResultante = new List<PaisesEntity>();
            foreach (var item in lista)
            {
                var dto = map(item);
                listaResultante.Add(dto);
            }
            return listaResultante;
        }
    }
}
