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
    public class CategoriasRepository : GenericRepository<CategoriasEntity>, ICategoriasRepository
    {
        private readonly DirectorioV1DBContext _directorioV1DBContext;
        public CategoriasRepository(DirectorioV1DBContext directorioV1DBContext):base(directorioV1DBContext)
        {
            this._directorioV1DBContext = directorioV1DBContext;
        }

        public IEnumerable<SelectListItem> ComboCategorias()
        {
            return this._directorioV1DBContext.Categorias.Select(r => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Text = r.Descripcion,
                Value = r.Id.ToString()
            });
        }


    }
}
