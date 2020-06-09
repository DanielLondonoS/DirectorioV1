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
    
    public class ClientesServices : IClientesServices
    {
        private readonly IClientesRepository _clientesRepository;
        public ClientesServices(IClientesRepository clientesRepository)
        {
            this._clientesRepository = clientesRepository;
        }

        public List<Clientes> ListadoDeClientes()
        {
            var cliente =  _clientesRepository.GetAll().ToList();            
            return ClientesMapper.map(cliente);
        }

        public async Task<Clientes> ClientePorId(int? id)
        {
            if (id == null)
                return null;
            var cliente = await _clientesRepository.GetByIdAsync(id.Value);
            return ClientesMapper.map(cliente);
        }

        public async Task<Clientes> CrearNuevoCliente(Clientes dto)
        {
            if (dto == null)
                return null;
            ClientesEntity clientesMap = ClientesMapper.map(dto);
            var cliente = await _clientesRepository.CreateAsync(clientesMap);
            return ClientesMapper.map(cliente);
        }

        public async Task<Clientes> EditarCliente(Clientes dto)
        {
            if (dto == null)
                return null;
            ClientesEntity clienteMap = ClientesMapper.map(dto);
            var pais = await _clientesRepository.UpdateAsync(clienteMap);
            return ClientesMapper.map(pais);
        }

        public void EliminarCliente(Clientes dto)
        {
            if (dto == null)
                return;
            var clientes = ClientesMapper.map(dto);
            this._clientesRepository.DeleteAsync(clientes);

        }

        public async Task<bool> ExisteCliente(int? id)
        {
            return await this._clientesRepository.ExistAsync(id.Value);
        }

        public IEnumerable<SelectListItem> ObtenerComboClientes()
        {
            return this._clientesRepository.ComboClientes();
        }
    }
}
