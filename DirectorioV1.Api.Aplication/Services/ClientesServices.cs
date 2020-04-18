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
    
    public class ClientesServices : IClientesServices
    {
        private readonly IClientesRepository _clientesRepository;
        public ClientesServices(IClientesRepository clientesRepository)
        {
            this._clientesRepository = clientesRepository;
        }

        public async Task<List<ClientesForDirecciones>> ListadoDeClientes()
        {
            var cliente =  await _clientesRepository.GetAll();
            ClientesForDirecciones resultado = new ClientesForDirecciones();
            resultado.Cliente = ClientesMapper.map(cliente);
            return PaisesMapper.map(listaDePaises);
        }

        public async Task<Clientes> ClientePorId(int id)
        {
            var Pais = await _paisesRepository.Get(id);
            return PaisesMapper.map(Pais);
        }

        public async Task<Clientes> CrearNuevoCliente(Clientes dto)
        {
            PaisesEntity paisesMap = PaisesMapper.map(dto);
            var paises = await _paisesRepository.Add(paisesMap);
            return PaisesMapper.map(paises);
        }

        public async Task<Clientes> EditarCliente(int id, Clientes dto)
        {
            PaisesEntity paisMap = PaisesMapper.map(dto);
            var pais = await _paisesRepository.Update(id, paisMap);
            return PaisesMapper.map(pais);
        }
    }
}
