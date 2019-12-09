﻿using DirectorioV1.Api.Business.Models;
using DirectorioV1.Api.DataAccess.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DirectorioV1.Api.DataAccess.Mappers
{
    public static class CategoriasMapper
    {
        public static CategoriasEntity map(Categorias dto)
        {
            return new CategoriasEntity()
            {
                Id = dto.Id,
                Estado = dto.Estado,
                Descripcion = dto.Descripcion
            };
        }

        public static Categorias map(CategoriasEntity dto)
        {
            return new Categorias()
            {
                Id = dto.Id,
                Estado = dto.Estado,
                Descripcion = dto.Descripcion
            };
        }

        public static List<Categorias> map(IEnumerable<CategoriasEntity> lista)
        {
            List<Categorias> listaResultante = new List<Categorias>();
            foreach (var item in lista)
            {
                var dto = map(item);
                listaResultante.Add(dto);
            }
            return listaResultante;
        }

        public static List<CategoriasEntity> map(IEnumerable<Categorias> lista)
        {
            List<CategoriasEntity> listaResultante = new List<CategoriasEntity>();
            foreach (var item in lista)
            {
                var dto = map(item);
                listaResultante.Add(dto);
            }
            return listaResultante;
        }
    }
}
