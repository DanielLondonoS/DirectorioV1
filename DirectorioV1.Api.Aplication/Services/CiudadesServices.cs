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
    
    public class CiudadesServices : ICiudadesServices
    {
        private readonly ICiudadesRepository _ciudadesRepository;
        public CiudadesServices(ICiudadesRepository ciudadesRepository)
        {
            this._ciudadesRepository = ciudadesRepository;
        }

        public async Task<List<Ciudades>> ListadoDeCiudades()
        {
            var listaDeCiudades =  await _ciudadesRepository.GetAll();
            return CiudadesMapper.map(listaDeCiudades);
        }

        public async Task<Ciudades> CiudadPorId(int id)
        {
            var Pais = await _ciudadesRepository.Get(id);
            return CiudadesMapper.map(Pais);
        }

        public async Task<Ciudades> CrearNuevoCiudad(Ciudades dto)
        {
            CiudadesEntity paisesMap = CiudadesMapper.map(dto);
            var paises = await _ciudadesRepository.Add(paisesMap);
            return CiudadesMapper.map(paises);
        }

        public async Task<Ciudades> EditarCiudad(int id, Ciudades dto)
        {
            CiudadesEntity paisMap = CiudadesMapper.map(dto);
            var pais = await _ciudadesRepository.Update(id, paisMap);
            return CiudadesMapper.map(pais);
        }
    }
}
