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
    
    public class CiudadesServices : ICiudadesServices
    {
        private readonly ICiudadesRepository _ciudadesRepository;
        private readonly IBarriosRepository barriosRepository;
        private readonly IDepartamentosRepository departamentosRepository;

        public CiudadesServices(
            ICiudadesRepository ciudadesRepository,
            IBarriosRepository barriosRepository,
            IDepartamentosRepository departamentosRepository
            )
        {
            this._ciudadesRepository = ciudadesRepository;
            this.barriosRepository = barriosRepository;
            this.departamentosRepository = departamentosRepository;
        }

        public List<Ciudades> ListadoDeCiudades()
        {
            var listaDeCiudades =  _ciudadesRepository.GetAll();
            return CiudadesMapper.map(listaDeCiudades);
        }

        public async Task<Ciudades> CiudadPorId(int? id)
        {
            if (id == null)
                return null;
            var Pais = await _ciudadesRepository.GetByIdAsync(id.Value);
            return CiudadesMapper.map(Pais);
        }

        public async Task<Ciudades> CrearNuevoCiudad(Ciudades dto)
        {
            if (dto == null)
                return null;
            CiudadesEntity paisesMap = CiudadesMapper.map(dto);
            var paises = await _ciudadesRepository.CreateAsync(paisesMap);
            return CiudadesMapper.map(paises);
        }

        public async Task<Ciudades> EditarCiudad(Ciudades dto)
        {
            if (dto == null)
                return null;
            CiudadesEntity paisMap = CiudadesMapper.map(dto);
            var pais = await _ciudadesRepository.UpdateAsync(paisMap);
            return CiudadesMapper.map(pais);
        }

        public void EliminarCiudad(Ciudades dto)
        {
            if (dto == null)
                return;
            var ciudad = CiudadesMapper.map(dto);
            this._ciudadesRepository.DeleteAsync(ciudad);

        }

        public async Task<bool> ExisteCiudad(int? id)
        {
            return await this._ciudadesRepository.ExistAsync(id.Value);
        }

        public IEnumerable<SelectListItem> ObtenerComboCiudades()
        {
            return this._ciudadesRepository.ComboCiudades();
        }

        public async Task<List<Ciudades>> CiudadesConDepartamentos()
        {
            var ciudades = await this._ciudadesRepository.ListaCiudadesConDepartamentos();
            List<Ciudades> rta = new List<Ciudades>();
            foreach (var item in ciudades)
            {
                Ciudades ci = new Ciudades();
                ci.Barrios = BarriosMapper.map(this.barriosRepository.GetAll());
                ci.Codigo = item.Codigo;
                ci.Codigo_Postal = item.Codigo_Postal;
                ci.Descripcion = item.Descripcion;
                ci.Estado = item.Estado;
                ci.Id = item.Id;
                ci.Latitud = item.Latitud;
                ci.Longitud = item.Longitud;
                ci.Departamento = DepartamentosMapper.map( await this.departamentosRepository.GetByIdAsync(item.DepartamentoId));
                ci.DepartamentoId = item.DepartamentoId.ToString();
                rta.Add(ci);
            }
            return rta;
        }
    }
}
