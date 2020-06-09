using DirectorioV1.Api.DataAccess.Contracts.Entities;
using DirectorioV1.Api.DataAccess.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectorioV1.Api.DataAccess.Repositories
{
    public class ClientesDireccionesRepository : GenericRepository<ClientesDireccionesEntity>, IClientesDireccionesRepository
    {
        private readonly DirectorioV1DBContext _directorioV1DBContext;
        public ClientesDireccionesRepository(DirectorioV1DBContext directorioV1DBContext) : base(directorioV1DBContext)
        {
            this._directorioV1DBContext = directorioV1DBContext;
        }

        public async Task<ICollection<ClientesDireccionesEntity>> ListaDireccionesConClientes()
        {
            return await this._directorioV1DBContext.ClientesDirecciones.Include(p => p.Cliente).ToListAsync();
        }

    }
}
