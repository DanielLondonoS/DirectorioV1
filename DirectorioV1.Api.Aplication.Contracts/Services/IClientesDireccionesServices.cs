using DirectorioV1.Api.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DirectorioV1.Api.Aplication.Contracts.Services
{
    public interface IClientesDireccionesServices
    {
        Task<ClientesDirecciones> EditarDireccionCliente(ClientesDirecciones dto);

        Task<ClientesDirecciones> CrearNuevaDireccionCliente(ClientesDirecciones dto);

        Task<ClientesDirecciones> DireccionClientePorId(int? id);

        List<ClientesDirecciones> ListadoDeDireccionesClientes();
        Task<List<ClientesDirecciones>> ListadoDeDireccionesConClientes();

        Task<bool> ExisteDireccionCliente(int? id);

        void EliminarDireccionCliente(ClientesDirecciones dto);
    }
}
