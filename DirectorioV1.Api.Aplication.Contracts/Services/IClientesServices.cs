using DirectorioV1.Api.Business.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DirectorioV1.Api.Aplication.Contracts.Services
{
    public interface IClientesServices
    {
        Task<Clientes> EditarCliente(Clientes dto);

        Task<Clientes> CrearNuevoCliente(Clientes dto);

        Task<Clientes> ClientePorId(int? id);

        List<Clientes> ListadoDeClientes();

        Task<bool> ExisteCliente(int? id);

        void EliminarCliente(Clientes dto);
        IEnumerable<SelectListItem> ObtenerComboClientes();
    }
}
