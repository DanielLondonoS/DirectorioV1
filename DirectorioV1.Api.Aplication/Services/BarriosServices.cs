using DirectorioV1.Api.Aplication.Contracts.Services;
using DirectorioV1.Api.Business.Models;
using DirectorioV1.Api.DataAccess.Contracts.Entities;
using DirectorioV1.Api.DataAccess.Contracts.Repositories;
using DirectorioV1.Api.DataAccess.Mappers;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<Barrios> ListadoDeBarrios()
        {
            var listaDeBarrios =  _barriosRepository.GetAll().ToList();
            return BarriosMapper.map(listaDeBarrios);
        }

        public async Task<Barrios> BarrioPorId(int? id)
        {
            if (id == null)
            {
                return null;
            }
            var Barrios = await _barriosRepository.GetByIdAsync(id.Value);
            return BarriosMapper.map(Barrios);
        }

        public async Task<Barrios> CrearNuevoBarrio(Barrios dto)
        {
            if (dto == null)
                return null;
            BarriosEntity barrioMap = BarriosMapper.map(dto);
            var Barrios = await _barriosRepository.CreateAsync(barrioMap);
            return BarriosMapper.map(Barrios);
        }

        public async Task<Barrios> EditarBarrio(Barrios dto)
        {
            if (dto == null)
                return null;
            BarriosEntity barrioMap = BarriosMapper.map(dto);
            var Barrios = await _barriosRepository.UpdateAsync(barrioMap);
            return BarriosMapper.map(Barrios);
        }

        public void EliminarBarrio(Barrios dto)
        {
            if (dto == null)
                return;
            var barrio = BarriosMapper.map(dto);
            this._barriosRepository.DeleteAsync(barrio);

        }

        public async Task<bool> ExisteBarrio(int? id)
        {
            return await this._barriosRepository.ExistAsync(id.Value);
        }

        public IEnumerable<SelectListItem> ObtenerComboBarrios()
        {
            return this._barriosRepository.ComboBarrios();
        }
    }
}
