using DirectorioV1.Api.Aplication.Contracts.Services;
using DirectorioV1.Api.Business.Models;
using DirectorioV1.Api.DataAccess.Contracts.Entities;
using DirectorioV1.Api.DataAccess.Contracts.Repositories;
using DirectorioV1.Api.Business.Mappers;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DirectorioV1.Api.Aplication.Services
{
    
    public class DepartamentosServices : IDepartamentosServices
    {
        private readonly IDepartamentosRepository _departamentosRepository;
        private readonly ICiudadesRepository ciudadesRepository;
        private readonly IPaisesRepository paisesRepository;

        public DepartamentosServices(
            IDepartamentosRepository departamentosRepository,
            ICiudadesRepository ciudadesRepository,
            IPaisesRepository paisesRepository
            )
        {
            this._departamentosRepository = departamentosRepository;
            this.ciudadesRepository = ciudadesRepository;
            this.paisesRepository = paisesRepository;
        }

        public List<Departamentos> ListadoDeDepartamentos()
        {
            var listaDeDepartamentos =  _departamentosRepository.GetAll();
            return DepartamentosMapper.map(listaDeDepartamentos);
        }

        public async Task<Departamentos> DepartamentoPorId(int? id)
        {
            if (id == null)
                return null;
            var departamentos = await _departamentosRepository.GetByIdAsync(id.Value);
            return DepartamentosMapper.map(departamentos);
        }

        public async Task<Departamentos> CrearNuevoDepartamento(Departamentos dto)
        {
            if (dto == null)
                return null;
            DepartamentosEntity departamentosMap = DepartamentosMapper.map(dto);
            var departamento = await _departamentosRepository.CreateAsync(departamentosMap);
            return DepartamentosMapper.map(departamento);
        }

        public async Task<Departamentos> EditarDepartamento(Departamentos dto)
        {
            if (dto == null)
                return null;
            DepartamentosEntity departamentosMap = DepartamentosMapper.map(dto);
            var departamentos = await _departamentosRepository.UpdateAsync(departamentosMap);
            return DepartamentosMapper.map(departamentos);
        }

        public void EliminarDepartamento(Departamentos dto)
        {
            if (dto == null)
                return;
            var departamentos = DepartamentosMapper.map(dto);
            this._departamentosRepository.DeleteAsync(departamentos);

        }

        public async Task<bool> ExisteDepartamento(int? id)
        {
            return await this._departamentosRepository.ExistAsync(id.Value);
        }

        public async Task<List<Departamentos>> DepartamentosConPais()
        {

             var departamentos = await this._departamentosRepository.ListaDepartamentosConPaises();
            List<Departamentos> rta = new List<Departamentos>();
            foreach (var item in departamentos)
            {
                Departamentos dp = new Departamentos();
                dp.Ciudades = CiudadesMapper.map(this.ciudadesRepository.GetAll());
                dp.Codigo = item.Codigo;
                dp.Codigo_Postal = item.Codigo_Postal;
                dp.Descripcion = item.Descripcion;
                dp.Estado = item.Estado;
                dp.Id = item.Id;
                dp.Latitud = item.Latitud;
                dp.Longitud = item.Longitud;
                dp.Pais =  PaisesMapper.map(await this.paisesRepository.GetByIdAsync(item.PaisId));
                dp.PaisId = item.PaisId.ToString();
                rta.Add(dp);
            }
            return rta;
        }

        public IEnumerable<SelectListItem> ObtenerComboDepartamentos()
        {
            return this._departamentosRepository.ComboDepartamentos();
        }
    }
}
