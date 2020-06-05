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
    public class DepartamentosRepository : GenericRepository<DepartamentosEntity>, IDepartamentosRepository
    {
        private readonly DirectorioV1DBContext _directorioV1DBContext;
        public DepartamentosRepository(DirectorioV1DBContext directorioV1DBContext):base(directorioV1DBContext)
        {
            this._directorioV1DBContext = directorioV1DBContext;
        }

        public async Task<ICollection<DepartamentosEntity>> ListaDepartamentosConPaises()
        {
            return await this._directorioV1DBContext.Departamentos.Include(p => p.Pais).ToListAsync();
        }
    }
}
