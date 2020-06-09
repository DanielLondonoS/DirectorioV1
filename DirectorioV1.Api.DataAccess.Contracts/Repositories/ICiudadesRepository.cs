using DirectorioV1.Api.DataAccess.Contracts.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DirectorioV1.Api.DataAccess.Contracts.Repositories
{
    public interface ICiudadesRepository : IGenericRepository<CiudadesEntity>
    {
        Task<ICollection<CiudadesEntity>> ListaCiudadesConDepartamentos();
        IEnumerable<SelectListItem> ComboCiudades();
    }
}
