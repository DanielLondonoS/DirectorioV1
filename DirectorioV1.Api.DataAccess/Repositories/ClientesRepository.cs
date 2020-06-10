using DirectorioV1.Api.DataAccess.Contracts.Entities;
using DirectorioV1.Api.DataAccess.Contracts.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectorioV1.Api.DataAccess.Repositories
{
    public class ClientesRepository : GenericRepository<ClientesEntity>, IClientesRepository
    {
        private readonly DirectorioV1DBContext _directorioV1DBContext;
        public ClientesRepository(DirectorioV1DBContext directorioV1DBContext):base(directorioV1DBContext)
        {
            this._directorioV1DBContext = directorioV1DBContext;
        }

        public IEnumerable<SelectListItem> ComboClientes()
        {
            return this._directorioV1DBContext.Clientes.Select(r => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Text = r.Nombre,
                Value = r.Id.ToString()
            });
        }

        public async Task<ICollection<ClientesEntity>> ListaClientesConCategorias()
        {
            return await this._directorioV1DBContext.Clientes.Include(p => p.Categoria).ToListAsync();
        }

        public async Task<ICollection<ClientesEntity>> ListaClientesConTodo()
        {
            return await this._directorioV1DBContext.Clientes
                //.Include(p => p.Categoria)
                //.Include(p => p.Imagenes)
                //.Include(p => p.Direcciones)
                .ToListAsync();
        }
    }
}
