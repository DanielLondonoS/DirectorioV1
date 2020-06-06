using DirectorioV1.Api.DataAccess.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DirectorioV1.Api.DataAccess.Contracts.Repositories
{
    public interface IBarriosRepository : IGenericRepository<BarriosEntity>
    {
        IEnumerable<SelectListItem> ComboBarrios();
    }

}
