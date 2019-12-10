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
    
    public class MunicipiosServices : IMunicipiosServices
    {
        private readonly IMunicipioRepository _municipioRepository;
        public MunicipiosServices(IMunicipioRepository municipioRepository)
        {
            this._municipioRepository = municipioRepository;
        }

        public async Task<List<Municipios>> ListadoDeMunicipios()
        {
            var listaDeDepartamentos =  await _municipioRepository.GetAll();
            return MunicipiosMapper.map(listaDeDepartamentos);
        }

        public async Task<Municipios> MunicipioPorId(int id)
        {
            var Pais = await _municipioRepository.Get(id);
            return MunicipiosMapper.map(Pais);
        }

        public async Task<Municipios> CrearNuevoMunicipio(Municipios dto)
        {
            MunicipiosEntity paisesMap = MunicipiosMapper.map(dto);
            var paises = await _municipioRepository.Add(paisesMap);
            return MunicipiosMapper.map(paises);
        }

        public async Task<Municipios> EditarMunicipio(int id, Municipios dto)
        {
            MunicipiosEntity paisMap = MunicipiosMapper.map(dto);
            var pais = await _municipioRepository.Update(id, paisMap);
            return MunicipiosMapper.map(pais);
        }
    }
}
