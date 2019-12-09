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
            return new DepartamentosEntity()
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

        public static Departamentos map(DepartamentosEntity dto)
        {
            return new Departamentos()
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

        public static List<Departamentos> map(IEnumerable<DepartamentosEntity> lista)
        {
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
