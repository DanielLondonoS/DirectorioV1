using DirectorioV1.Api.Aplication.Contracts.Services;
using DirectorioV1.Api.Business.Models;
using DirectorioV1.Api.DataAccess.Contracts.Entities;
using DirectorioV1.Api.DataAccess.Contracts.Repositories;
using DirectorioV1.Api.Business.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DirectorioV1.Api.Aplication.Services
{
    
    public class ClientesDireccionesServices : IClientesDireccionesServices
    {
        private readonly IClientesDireccionesRepository _clientesDireccionesRepository;
        private readonly IClientesRepository clientesRepository;

        public ClientesDireccionesServices(
            IClientesDireccionesRepository clientesDireccionesRepository,
            IClientesRepository clientesRepository)
        {
            this._clientesDireccionesRepository = clientesDireccionesRepository;
            this.clientesRepository = clientesRepository;
        }

        public List<ClientesDirecciones> ListadoDeDireccionesClientes()
        {
            var cliente = _clientesDireccionesRepository.GetAll().ToList();            
            return ClientesDireccionesMapper.map(cliente);
        }

        public async Task<ClientesDirecciones> DireccionClientePorId(int? id)
        {
            if (id == null)
                return null;
            var cliente = await _clientesDireccionesRepository.GetByIdAsync(id.Value);
            return ClientesDireccionesMapper.map(cliente);
        }

        public async Task<ClientesDirecciones> CrearNuevaDireccionCliente(ClientesDirecciones dto)
        {
            if (dto == null)
                return null;
            ClientesDireccionesEntity clientesMap = ClientesDireccionesMapper.map(dto);
            var cliente = await _clientesDireccionesRepository.CreateAsync(clientesMap);
            return ClientesDireccionesMapper.map(cliente);
        }

        public async Task<ClientesDirecciones> EditarDireccionCliente(ClientesDirecciones dto)
        {
            if (dto == null)
                return null;
            ClientesDireccionesEntity clienteMap = ClientesDireccionesMapper.map(dto);
            var pais = await _clientesDireccionesRepository.UpdateAsync(clienteMap);
            return ClientesDireccionesMapper.map(pais);
        }

        public void EliminarDireccionCliente(ClientesDirecciones dto)
        {
            if (dto == null)
                return;
            var direcciones = ClientesDireccionesMapper.map(dto);
            this._clientesDireccionesRepository.DeleteAsync(direcciones);

        }

        public async Task<bool> ExisteDireccionCliente(int? id)
        {
            return await this._clientesDireccionesRepository.ExistAsync(id.Value);
        }

        public async Task<List<ClientesDirecciones>> ListadoDeDireccionesConClientes()
        {
            var clientesDir = await _clientesDireccionesRepository.ListaDireccionesConClientes();
            List<ClientesDirecciones> rta = new List<ClientesDirecciones>();

            foreach (var item in clientesDir)
            {
                ClientesDirecciones ci = new ClientesDirecciones();
                
                ci.Estado = item.Estado;
                ci.Id = item.Id;
                ci.Latitud = item.Latitud;
                ci.Longitud = item.Longitud;
                ci.Cliente = ClientesMapper.map(await this.clientesRepository.GetByIdAsync(item.ClienteId));
                ci.ClienteId = item.ClienteId;
                //ci.BarrioId = item.BarrioId;
                //ci.CiudadId = item.CiudadId;
                //ci.DepartamentoId = item.DepartamentoId;
                ci.Direccion_A = item.Direccion_A;
                ci.Direccion_B = item.Direccion_B;
                ci.Direccion_Compuesta = item.Direccion_Compuesta;
                ci.Direccion_Observacion = item.Direccion_Observacion;
                ci.Direccion_Tipo_A = item.Direccion_Tipo_A;
                ci.Direccion_Tipo_B = item.Direccion_Tipo_B;
                ci.Horario = item.Horario;
                rta.Add(ci);
            }
            return rta;
        }


    }
}
