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
    public class CategoriasRepository : ICategoriasRepository
    {
        private readonly DirectorioV1DBContext _directorioV1DBContext;
        public CategoriasRepository(DirectorioV1DBContext directorioV1DBContext)
        {
            this._directorioV1DBContext = directorioV1DBContext;
        }

        public async Task<CategoriasEntity> Add(CategoriasEntity categoriaEntity)
        {
            await _directorioV1DBContext.Categorias.AddAsync(categoriaEntity);
            await _directorioV1DBContext.SaveChangesAsync();
            return categoriaEntity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _directorioV1DBContext.Categorias.SingleAsync(x=>x.Id == id);
            _directorioV1DBContext.Categorias.Remove(entity);
            await _directorioV1DBContext.SaveChangesAsync();
        }

        public async Task<bool> Exist(int id)
        {
            var entity = await _directorioV1DBContext.Categorias.FirstOrDefaultAsync(x => x.Id == id);
            if(entity != null) {
                return true;
            }
            return false;
        }

        public async Task<CategoriasEntity> Get(int id)
        {
            var result = await _directorioV1DBContext.Categorias.FirstOrDefaultAsync(r => r.Id == id);
            return result;
        }

        public async Task<IEnumerable<CategoriasEntity>> GetAll()
        {
            return await _directorioV1DBContext.Categorias.ToListAsync();
        }

        public async Task<CategoriasEntity> Update(int id, CategoriasEntity element)
        {
            var entity = await Get(id);
            entity.Descripcion = element.Descripcion;
            return await Update(entity);

        }

        public async Task<CategoriasEntity> Update(CategoriasEntity element)
        {
            var updateCategoria = _directorioV1DBContext.Categorias.Update(element);
            await _directorioV1DBContext.SaveChangesAsync();
            return updateCategoria.Entity;
        }
    }
}
