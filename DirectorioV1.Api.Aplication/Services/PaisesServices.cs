using DirectorioV1.Api.Aplication.Contracts.Services;
using DirectorioV1.Api.Business.Models;
using DirectorioV1.Api.DataAccess.Contracts.Entities;
using DirectorioV1.Api.DataAccess.Contracts.Repositories;
using DirectorioV1.Api.DataAccess.Mappers;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DirectorioV1.Api.Aplication.Services
{
    
    public class PaisesServices : IPaisesServices
    {
        private readonly IPaisesRepository _paisesRepository;
        public PaisesServices(IPaisesRepository paisesRepository)
        {
            this._paisesRepository = paisesRepository;
        }

        public List<Paises> ListadoDePaises()
        {
            var listaDePaises =  _paisesRepository.GetAll();
            return PaisesMapper.map(listaDePaises);
        }

        public async Task<Paises> PaisPorId(int? id)
        {
            if (id == null)
                return null;
            var Pais = await _paisesRepository.GetByIdAsync(id.Value);
            return PaisesMapper.map(Pais);
        }

        public async Task<Paises> CrearNuevoPais(Paises dto)
        {
            if (dto == null)
                return null;
            PaisesEntity paisesMap = PaisesMapper.map(dto);
            var paises = await _paisesRepository.CreateAsync(paisesMap);
            return PaisesMapper.map(paises);
        }

        public async Task<Paises> EditarPais(Paises dto)
        {
            if (dto == null)
                return null;
            PaisesEntity paisMap = PaisesMapper.map(dto);
            var pais = await _paisesRepository.UpdateAsync(paisMap);
            return PaisesMapper.map(pais);
        }

        public void EliminarPais(Paises dto)
        {
            if (dto == null)
                return;
            var pais = PaisesMapper.map(dto);
            this._paisesRepository.DeleteAsync(pais);

        }

        public async Task<bool> ExistePais(int? id)
        {
            return await this._paisesRepository.ExistAsync(id.Value);
        }

        public IEnumerable<SelectListItem> ObtenerComboPaises()
        {
            return this._paisesRepository.ComboPaises();
        }
    }
}
