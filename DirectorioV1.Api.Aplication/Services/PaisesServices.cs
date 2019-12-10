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
    
    public class PaisesServices : IPaisesServices
    {
        private readonly IPaisesRepository _paisesRepository;
        public PaisesServices(IPaisesRepository paisesRepository)
        {
            this._paisesRepository = paisesRepository;
        }

        public async Task<List<Paises>> ListadoDePaises()
        {
            var listaDePaises =  await _paisesRepository.GetAll();
            return PaisesMapper.map(listaDePaises);
        }

        public async Task<Paises> PaisPorId(int id)
        {
            var Pais = await _paisesRepository.Get(id);
            return PaisesMapper.map(Pais);
        }

        public async Task<Paises> CrearNuevoPais(Paises dto)
        {
            PaisesEntity paisesMap = PaisesMapper.map(dto);
            var paises = await _paisesRepository.Add(paisesMap);
            return PaisesMapper.map(paises);
        }

        public async Task<Paises> EditarPais(int id, Paises dto)
        {
            PaisesEntity paisMap = PaisesMapper.map(dto);
            var pais = await _paisesRepository.Update(id, paisMap);
            return PaisesMapper.map(pais);
        }
    }
}
