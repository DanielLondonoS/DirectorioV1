using DirectorioV1.Api.DataAccess.Contracts.Entities;
using DirectorioV1.Api.DataAccess.Contracts.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

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
    }
}
