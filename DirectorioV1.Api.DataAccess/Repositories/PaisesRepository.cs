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
    public class PaisesRepository : IPaisesRepository
    {
        private readonly DirectorioV1DBContext _directorioV1DBContext;
        public PaisesRepository(DirectorioV1DBContext directorioV1DBContext)
        {
            this._directorioV1DBContext = directorioV1DBContext;
        }

        public async Task<PaisesEntity> Add(PaisesEntity paisesEntity)
        {
            await _directorioV1DBContext.Paises.AddAsync(paisesEntity);
            await _directorioV1DBContext.SaveChangesAsync();
            return paisesEntity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _directorioV1DBContext.Paises.SingleAsync(x=>x.Id == id);
            _directorioV1DBContext.Paises.Remove(entity);
            await _directorioV1DBContext.SaveChangesAsync();
        }

        public async Task<bool> Exist(int id)
        {
            var entity = await _directorioV1DBContext.Paises.FirstOrDefaultAsync(x => x.Id == id);
            if(entity != null) {
                return true;
            }
            return false;
        }

        public async Task<PaisesEntity> Get(int id)
        {
            var result = await _directorioV1DBContext.Paises.FirstOrDefaultAsync(r => r.Id == id);
            return result;
        }

        public async Task<IEnumerable<PaisesEntity>> GetAll()
        {
            return await _directorioV1DBContext.Paises.ToListAsync();
        }

        public async Task<PaisesEntity> Update(int id, PaisesEntity element)
        {
            var entity = await Get(id);
            entity.Descripcion = element.Descripcion;
            return await Update(entity);

        }

        public async Task<PaisesEntity> Update(PaisesEntity element)
        {
            var updatePaises = _directorioV1DBContext.Paises.Update(element);
            await _directorioV1DBContext.SaveChangesAsync();
            return updatePaises.Entity;
        }
    }
}
