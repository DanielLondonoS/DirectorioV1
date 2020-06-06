using DirectorioV1.Api.Business.Models;
using DirectorioV1.Api.DataAccess.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DirectorioV1.Api.DataAccess.Mappers
{
    public static class BarriosMapper
    {
        public static BarriosEntity map(Barrios dto)
        {
            if (dto == null)
                return null;
            return new BarriosEntity()
            {
                Id = dto.Id,
                Estado = dto.Estado,
                Codigo = dto.Codigo,
                Codigo_Postal = dto.Codigo_Postal,
                Descripcion = dto.Descripcion,
                Latitud = dto.Latitud,
                Longitud = dto.Longitud,
                CiudadId = dto.CiudadId,
                Ciudad = CiudadesMapper.map(dto.Ciudad)

            };
        }

        public static Barrios map(BarriosEntity dto)
        {
            if (dto == null)
                return null;
            return new Barrios()
            {
                Id = dto.Id,
                Estado = dto.Estado,
                Codigo = dto.Codigo,
                Codigo_Postal = dto.Codigo_Postal,
                Descripcion = dto.Descripcion,
                Latitud = dto.Latitud,
                Longitud = dto.Longitud,
                CiudadId = dto.CiudadId,
                Ciudad = CiudadesMapper.map(dto.Ciudad)
            };
        }

        public static List<Barrios> map(IEnumerable<BarriosEntity> listaBarrios)
        {
            List<Barrios> listaResultante = new List<Barrios>();
            if (listaBarrios == null)
                return listaResultante;
            foreach (var item in listaBarrios)
            {
                var barrio = map(item);
                listaResultante.Add(barrio);
            }
            return listaResultante;
        }

        public static List<BarriosEntity> map(IEnumerable<Barrios> listaBarrios)
        {
            List<BarriosEntity> listaResultante = new List<BarriosEntity>();
            if (listaBarrios == null)
                return listaResultante;
            foreach (var item in listaBarrios)
            {
                var barrio = map(item);
                listaResultante.Add(barrio);
            }
            return listaResultante;
        }
    }
}
