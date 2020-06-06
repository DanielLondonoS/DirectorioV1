using DirectorioV1.Api.DataAccess.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DirectorioV1.Api.DataAccess.Contracts.Repositories
{
    public interface IDepartamentosRepository : IGenericRepository<DepartamentosEntity>
    {
        Task<ICollection<DepartamentosEntity>> ListaDepartamentosConPaises();
        IEnumerable<SelectListItem> ComboDepartamentos();
    }
}
