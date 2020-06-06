using DirectorioV1.Api.Business.Models;
using DirectorioV1.Api.DataAccess.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DirectorioV1.Api.DataAccess.Mappers
{
    public static class DepartamentosMapper
    {
        public static DepartamentosEntity map(Departamentos dto)
        {
            if (dto == null)
                return null;
            return new DepartamentosEntity()
            {
                Id = dto.Id,
                Estado = dto.Estado,
                Codigo = dto.Codigo,
                Codigo_Postal = dto.Codigo_Postal,
                Descripcion = dto.Descripcion,
                Latitud = dto.Latitud,
                Longitud = dto.Longitud,
                PaisId = int.Parse(dto.PaisId),
                Ciudades = CiudadesMapper.map(dto.Ciudades),
                Pais = PaisesMapper.map(dto.Pais)
            };
        }

        public static Departamentos map(DepartamentosEntity dto)
        {
            if (dto == null)
                return null;
            return new Departamentos()
            {
                Id = dto.Id,
                Estado = dto.Estado,
                Codigo = dto.Codigo,
                Codigo_Postal = dto.Codigo_Postal,
                Descripcion = dto.Descripcion,
                Latitud = dto.Latitud,
                Longitud = dto.Longitud,
                PaisId = dto.PaisId.ToString(),
                Ciudades = CiudadesMapper.map(dto.Ciudades),
                Pais = PaisesMapper.map(dto.Pais)
            };
        }

        public static List<Departamentos> map(IEnumerable<DepartamentosEntity> lista)
        {
            if (lista == null)
                return null;
            List<Departamentos> listaResultante = new List<Departamentos>();
            foreach (var item in lista)
            {
                var dto = map(item);
                listaResultante.Add(dto);
            }
            return listaResultante;
        }

        public static List<DepartamentosEntity> map(IEnumerable<Departamentos> lista)
        {
            if (lista == null)
                return null;
            List<DepartamentosEntity> listaResultante = new List<DepartamentosEntity>();
            foreach (var item in lista)
            {
                var dto = map(item);
                listaResultante.Add(dto);
            }
            return listaResultante;
        }
    }
}
