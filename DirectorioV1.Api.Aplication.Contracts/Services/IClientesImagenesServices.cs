using DirectorioV1.Api.Business.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DirectorioV1.Api.Aplication.Contracts.Services
{
    public interface IClientesImagenesServices
    {
        Task<ClientesImagenes> EditarImagenCliente(ClientesImagenes dto);

        Task<ClientesImagenes> CrearNuevaImagenCliente(ClientesImagenes dto);

        Task<ClientesImagenes> ImagenClientePorId(int? id);

        List<ClientesImagenes> ListadoDeImagenesClientes();

        Task<bool> ExisteImagenCliente(int? id);

        void EliminarImagenCliente(ClientesImagenes dto);

        Task<List<ClientesImagenes>> ListadoDeImagenesConClientes();
    }
}
