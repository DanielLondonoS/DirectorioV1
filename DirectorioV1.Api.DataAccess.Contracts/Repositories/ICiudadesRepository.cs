using DirectorioV1.Api.DataAccess.Contracts.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;


namespace DirectorioV1.Api.DataAccess.Contracts.Repositories
{
    public interface ICiudadesRepository : IGenericRepository<CiudadesEntity>
    {
        IEnumerable<SelectListItem> ComboCiudades();
    }
}
