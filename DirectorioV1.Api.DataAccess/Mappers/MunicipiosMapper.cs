using DirectorioV1.Api.Business.Models;
using DirectorioV1.Api.DataAccess.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DirectorioV1.Api.DataAccess.Mappers
{
    public static class MunicipiosMapper
    {
        public static MunicipiosEntity map(Municipios dto)
        {
            return new MunicipiosEntity()
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

        public static Municipios map(MunicipiosEntity dto)
        {
            return new Municipios()
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

        public static List<Municipios> map(IEnumerable<MunicipiosEntity> lista)
        {
            List<Municipios> listaResultante = new List<Municipios>();
            foreach (var item in lista)
            {
                var dto = map(item);
                listaResultante.Add(dto);
            }
            return listaResultante;
        }

        public static List<MunicipiosEntity> map(IEnumerable<Municipios> lista)
        {
            List<MunicipiosEntity> listaResultante = new List<MunicipiosEntity>();
            foreach (var item in lista)
            {
                var dto = map(item);
                listaResultante.Add(dto);
            }
            return listaResultante;
        }
    }
}
