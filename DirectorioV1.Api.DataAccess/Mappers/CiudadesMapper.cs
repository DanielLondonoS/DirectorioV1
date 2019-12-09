using DirectorioV1.Api.Business.Models;
using DirectorioV1.Api.DataAccess.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DirectorioV1.Api.DataAccess.Mappers
{
    public static class CiudadesMapper
    {
        public static CiudadesEntity map(Ciudades dto)
        {
            return new CiudadesEntity()
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

        public static Ciudades map(CiudadesEntity dto)
        {
            return new Ciudades()
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

        public static List<Ciudades> map(IEnumerable<CiudadesEntity> lista)
        {
            List<Ciudades> listaResultante = new List<Ciudades>();
            foreach (var item in lista)
            {
                var dto = map(item);
                listaResultante.Add(dto);
            }
            return listaResultante;
        }

        public static List<CiudadesEntity> map(IEnumerable<Ciudades> lista)
        {
            List<CiudadesEntity> listaResultante = new List<CiudadesEntity>();
            foreach (var item in lista)
            {
                var dto = map(item);
                listaResultante.Add(dto);
            }
            return listaResultante;
        }
    }
}
