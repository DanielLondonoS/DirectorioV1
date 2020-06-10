using DirectorioV1.Api.DataAccess.Contracts.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DirectorioV1.Api.DataAccess.Contracts.Repositories
{
    public interface IClientesRepository : IGenericRepository<ClientesEntity>
    {
        IEnumerable<SelectListItem> ComboClientes();
        Task<ICollection<ClientesEntity>> ListaClientesConCategorias();
        Task<ICollection<ClientesEntity>> ListaClientesConTodo();
    }
}
