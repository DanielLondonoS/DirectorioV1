using DirectorioV1.Api.Business.Models;
using DirectorioV1.Api.DataAccess.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DirectorioV1.Api.Business.Mappers
{
    public static class CiudadesMapper
    {
        public static CiudadesEntity map(Ciudades dto)
        {
            if (dto == null)
                return null;
            return new CiudadesEntity()
            {
                Id = dto.Id,
                Estado = dto.Estado,
                Codigo = dto.Codigo,
                Codigo_Postal = dto.Codigo_Postal,
                Descripcion = dto.Descripcion,
                Latitud = dto.Latitud,
                Longitud = dto.Longitud,
                DepartamentoId = int.Parse(dto.DepartamentoId),
                //Barrios = BarriosMapper.map(dto.Barrios),
                //Departamento = DepartamentosMapper.map(dto.Departamento)
            };
        }

        public static Ciudades map(CiudadesEntity dto)
        {
            if (dto == null)
                return null;
            return new Ciudades()
            {
                Id = dto.Id,
                Estado = dto.Estado,
                Codigo = dto.Codigo,
                Codigo_Postal = dto.Codigo_Postal,
                Descripcion = dto.Descripcion,
                Latitud = dto.Latitud,
                Longitud = dto.Longitud,
                DepartamentoId = dto.DepartamentoId.ToString(),
                //Barrios = BarriosMapper.map(dto.Barrios),
                //Departamento = DepartamentosMapper.map(dto.Departamento)

            };
        }

        public static List<Ciudades> map(IEnumerable<CiudadesEntity> lista)
        {
            if (lista == null)
                return null;
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
            if (lista == null)
                return null;
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
