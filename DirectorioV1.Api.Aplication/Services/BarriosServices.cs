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
    
    public class BarriosServices : IBarriosServices
    {
        private readonly IBarriosRepository _barriosRepository;
        public BarriosServices(IBarriosRepository barriosRepository)
        {
            this._barriosRepository = barriosRepository;
        }

        public async Task<List<Barrios>> ListadoDeBarrios()
        {
            var listaDeBarrios =  await _barriosRepository.GetAll();
            return BarriosMapper.map(listaDeBarrios);
        }

        public async Task<Barrios> BarrioPorId(int id)
        {
            var Barrios = await _barriosRepository.Get(id);
            return BarriosMapper.map(Barrios);
        }

        public async Task<Barrios> CrearNuevoBarrio(Barrios dto)
        {
            BarriosEntity barrioMap = BarriosMapper.map(dto);
            var Barrios = await _barriosRepository.Add(barrioMap);
            return BarriosMapper.map(Barrios);
        }

        public async Task<Barrios> EditarBarrio(int id,Barrios dto)
        {
            BarriosEntity barrioMap = BarriosMapper.map(dto);
            var Barrios = await _barriosRepository.Update(id,barrioMap);
            return BarriosMapper.map(Barrios);
        }
    }
}
