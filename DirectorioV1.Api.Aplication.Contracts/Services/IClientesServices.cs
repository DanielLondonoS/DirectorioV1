using DirectorioV1.Api.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DirectorioV1.Api.Aplication.Contracts.Services
{
    public interface IClientesServices
    {
        Task<Clientes> EditarCliente(int id, Clientes dto);

        Task<Clientes> CrearNuevoCliente(Clientes dto);

        Task<Clientes> ClientePorId(int id);

        Task<List<ClientesForDirecciones>> ListadoDeClientes();
    }
}
