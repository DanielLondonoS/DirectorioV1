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
    public class ClientesImagenesRepository : GenericRepository<ClientesImagenesEntity>, IClientesImagenesRepository
    {
        private readonly DirectorioV1DBContext _directorioV1DBContext;
        public ClientesImagenesRepository(DirectorioV1DBContext directorioV1DBContext):base(directorioV1DBContext)
        {
            this._directorioV1DBContext = directorioV1DBContext;
        }

        public async Task<ICollection<ClientesImagenesEntity>> ListaImagenesConClientes()
        {
            return await this._directorioV1DBContext.ClientesImagenes.Include(p => p.Cliente).ToListAsync();
        }

        public async Task<ICollection<ClientesImagenesEntity>> ListaImagenesPorCliente(int id)
        {
            return await this._directorioV1DBContext.ClientesImagenes.Where(p => p.ClienteId == id).ToListAsync();
        }
    }
}
