using DirectorioV1.Api.Aplication.Contracts.Services;
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

        public List<Categorias> ListadoDeCategorias()
        {
            var listaDePaises =  _categoriasRepository.GetAll();
            return CategoriasMapper.map(listaDePaises);
        }

        public async Task<Categorias> CategoriaPorId(int? id)
        {
            if (id == null)
                return null;
            var Pais = await _categoriasRepository.GetByIdAsync(id.Value);
            return CategoriasMapper.map(Pais);
        }

        public async Task<Categorias> CrearNuevoCategoria(Categorias dto)
        {
            if (dto == null)
                return null;
            CategoriasEntity paisesMap = CategoriasMapper.map(dto);
            var paises = await _categoriasRepository.CreateAsync(paisesMap);
            return CategoriasMapper.map(paises);
        }

        public async Task<Categorias> EditarCategoria( Categorias dto)
        {
            if (dto == null)
                return null;
            CategoriasEntity paisMap = CategoriasMapper.map(dto);
            var pais = await _categoriasRepository.UpdateAsync(paisMap);
            return CategoriasMapper.map(pais);
        }

        public void EliminarCategorias(Categorias dto)
        {
            if (dto == null)
                return;
            var categoria = CategoriasMapper.map(dto);
            this._categoriasRepository.DeleteAsync(categoria);

        }

        public async Task<bool> ExisteCategoria(int? id)
        {
            return await this._categoriasRepository.ExistAsync(id.Value);
        }
    }
}
