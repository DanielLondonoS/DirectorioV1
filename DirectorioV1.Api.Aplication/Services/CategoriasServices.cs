﻿using DirectorioV1.Api.Aplication.Contracts.Services;
using DirectorioV1.Api.Business.Models;
using DirectorioV1.Api.DataAccess.Contracts.Entities;
using DirectorioV1.Api.DataAccess.Contracts.Repositories;
using DirectorioV1.Api.DataAccess.Mappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DirectorioV1.Api.Aplication.Services
{
    
    public class CategoriasServices : ICategoriasServices
    {
        private readonly ICategoriasRepository _categoriasRepository;
        public CategoriasServices(ICategoriasRepository categoriasRepository)
        {
            this._categoriasRepository = categoriasRepository;
        }

        public async Task<List<Categorias>> ListadoDeCategorias()
        {
            var listaDePaises =  await _categoriasRepository.GetAll();
            return CategoriasMapper.map(listaDePaises);
        }

        public async Task<Categorias> CategoriaPorId(int id)
        {
            var Pais = await _categoriasRepository.Get(id);
            return CategoriasMapper.map(Pais);
        }

        public async Task<Categorias> CrearNuevoCategoria(Categorias dto)
        {
            CategoriasEntity paisesMap = CategoriasMapper.map(dto);
            var paises = await _categoriasRepository.Add(paisesMap);
            return CategoriasMapper.map(paises);
        }

        public async Task<Categorias> EditarCategoria(int id, Categorias dto)
        {
            CategoriasEntity paisMap = CategoriasMapper.map(dto);
            var pais = await _categoriasRepository.Update(id, paisMap);
            return CategoriasMapper.map(pais);
        }
    }
}
