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
    
    public class DepartamentosServices : IDepartamentosServices
    {
        private readonly IDepartamentosRepository _departamentosRepository;
        public DepartamentosServices(IDepartamentosRepository departamentosRepository)
        {
            this._departamentosRepository = departamentosRepository;
        }

        public async Task<List<Departamentos>> ListadoDeDepartamentos()
        {
            var listaDeDepartamentos =  await _departamentosRepository.GetAll();
            return DepartamentosMapper.map(listaDeDepartamentos);
        }

        public async Task<Departamentos> DepartamentoPorId(int id)
        {
            var Pais = await _departamentosRepository.Get(id);
            return DepartamentosMapper.map(Pais);
        }

        public async Task<Departamentos> CrearNuevoDepartamento(Departamentos dto)
        {
            DepartamentosEntity paisesMap = DepartamentosMapper.map(dto);
            var paises = await _departamentosRepository.Add(paisesMap);
            return DepartamentosMapper.map(paises);
        }

        public async Task<Departamentos> EditarDepartamento(int id, Departamentos dto)
        {
            DepartamentosEntity paisMap = DepartamentosMapper.map(dto);
            var pais = await _departamentosRepository.Update(id, paisMap);
            return DepartamentosMapper.map(pais);
        }
    }
}
