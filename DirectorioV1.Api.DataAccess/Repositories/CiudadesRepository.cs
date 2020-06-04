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
    public class CiudadesRepository : GenericRepository<CiudadesEntity>, ICiudadesRepository
    {
        private readonly DirectorioV1DBContext _directorioV1DBContext;
        public CiudadesRepository(DirectorioV1DBContext directorioV1DBContext):base(directorioV1DBContext)
        {
            this._directorioV1DBContext = directorioV1DBContext;
        }

       
    }
}
