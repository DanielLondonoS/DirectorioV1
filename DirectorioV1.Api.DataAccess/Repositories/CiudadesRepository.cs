using DirectorioV1.Api.DataAccess.Contracts.Entities;
using DirectorioV1.Api.DataAccess.Contracts.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirectorioV1.Api.DataAccess.Repositories
{
    public class CiudadesRepository : GenericRepository<CiudadesEntity>, ICiudadesRepository
    {
        private readonly DirectorioV1DBContext _directorioV1DBContext;
        public CiudadesRepository(DirectorioV1DBContext directorioV1DBContext) : base(directorioV1DBContext)
        {
            this._directorioV1DBContext = directorioV1DBContext;
        }

        public IEnumerable<SelectListItem> ComboCiudades()
        {
            return this._directorioV1DBContext.Ciudades.Select(r => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Text = r.Descripcion,
                Value = r.Id.ToString()
            });
        }

        public async Task<ICollection<CiudadesEntity>> ListaCiudadesConDepartamentos()
        {
            return await this._directorioV1DBContext.Ciudades.Include(p => p.Departamento).ToListAsync();
        }
    }
}
