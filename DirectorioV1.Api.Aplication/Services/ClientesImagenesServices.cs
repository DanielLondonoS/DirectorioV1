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
    
    public class ClientesImagenesServices : IClientesImagenesServices
    {
        private readonly IClientesImagenesRepository _clientesImagenesRepository;
        private readonly IClientesRepository clientesRepository;

        public ClientesImagenesServices(
            IClientesImagenesRepository clientesImagenesRepository,
            IClientesRepository clientesRepository)
        {
            this._clientesImagenesRepository = clientesImagenesRepository;
            this.clientesRepository = clientesRepository;
        }

        public List<ClientesImagenes> ListadoDeImagenesClientes()
        {
            var clienteImagenes = this._clientesImagenesRepository.GetAll().ToList();            
            return ClientesImagenesMapper.map(clienteImagenes);
        }

        public async Task<ClientesImagenes> ImagenClientePorId(int? id)
        {
            if (id == null)
                return null;
            var clienteImagenes = await this._clientesImagenesRepository.GetByIdAsync(id.Value);
            return ClientesImagenesMapper.map(clienteImagenes);
        }

        public async Task<ClientesImagenes> CrearNuevaImagenCliente(ClientesImagenes dto)
        {
            if (dto == null)
                return null;
            ClientesImagenesEntity clientesImagenesMap = ClientesImagenesMapper.map(dto);
            var clienteImagenes = await this._clientesImagenesRepository.CreateAsync(clientesImagenesMap);
            return ClientesImagenesMapper.map(clienteImagenes);
        }

        public async Task<ClientesImagenes> EditarImagenCliente(ClientesImagenes dto)
        {
            if (dto == null)
                return null;
            ClientesImagenesEntity clienteImagenesMap = ClientesImagenesMapper.map(dto);
            var clienteImagenes = await this._clientesImagenesRepository.UpdateAsync(clienteImagenesMap);
            return ClientesImagenesMapper.map(clienteImagenes);
        }

        public void EliminarImagenCliente(ClientesImagenes dto)
        {
            if (dto == null)
                return;
            var clienteImagenes = ClientesImagenesMapper.map(dto);
            this._clientesImagenesRepository.DeleteAsync(clienteImagenes);

        }

        public async Task<bool> ExisteImagenCliente(int? id)
        {
            return await this._clientesImagenesRepository.ExistAsync(id.Value);
        }

        public async Task<List<ClientesImagenes>> ListadoDeImagenesConClientes()
        {
            var clientesImg = await _clientesImagenesRepository.ListaImagenesConClientes();
            List<ClientesImagenes> rta = new List<ClientesImagenes>();

            foreach (var item in clientesImg)
            {
                ClientesImagenes ci = new ClientesImagenes();

                ci.Estado = item.Estado;
                ci.Id = item.Id;               
                ci.Cliente = ClientesMapper.map(await this.clientesRepository.GetByIdAsync(item.ClienteId));
                ci.ClienteId = item.ClienteId;
                ci.ImageUrl = item.ImageUrl;                

                rta.Add(ci);
            }
            return rta;
        }


    }
}
