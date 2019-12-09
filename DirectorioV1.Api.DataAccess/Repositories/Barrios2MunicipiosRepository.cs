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
    public class Barrios2MunicipiosRepository : IBarrios2MunicipiosRepository
    {
        private readonly DirectorioV1DBContext _directorioV1DBContext;
        public Barrios2MunicipiosRepository(DirectorioV1DBContext directorioV1DBContext)
        {
            this._directorioV1DBContext = directorioV1DBContext;
        }

        public async Task<Barrios2MunicipiosEntity> Add(Barrios2MunicipiosEntity barriosEntity)
        {
            await _directorioV1DBContext.Barrios2Municipios.AddAsync(barriosEntity);
            await _directorioV1DBContext.SaveChangesAsync();
            return barriosEntity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _directorioV1DBContext.Barrios2Municipios.SingleAsync(x=>x.Barrio_Id == id);
            _directorioV1DBContext.Barrios2Municipios.Remove(entity);
            await _directorioV1DBContext.SaveChangesAsync();
        }

        public async Task<bool> Exist(int id)
        {
            var entity = await _directorioV1DBContext.Barrios2Municipios.FirstOrDefaultAsync(x => x.Barrio_Id == id);
            if(entity != null) {
                return true;
            }
            return false;
        }

        public async Task<Barrios2MunicipiosEntity> Get(int id)
        {
            var result = await _directorioV1DBContext.Barrios2Municipios.Include(r => r.Municipios)
                .FirstOrDefaultAsync(r => r.Barrio_Id == id);
            return result;
        }

        public async Task<IEnumerable<Barrios2MunicipiosEntity>> GetAll()
        {
            return await _directorioV1DBContext.Barrios2Municipios.ToListAsync();
        }

        public async Task<Barrios2MunicipiosEntity> Update(int id, Barrios2MunicipiosEntity element)
        {
            var entity = await Get(id);

            return await Update(entity);

        }

        public async Task<Barrios2MunicipiosEntity> Update(Barrios2MunicipiosEntity element)
        {
            var updateBarrio = _directorioV1DBContext.Barrios2Municipios.Update(element);
            await _directorioV1DBContext.SaveChangesAsync();
            return updateBarrio.Entity;
        }
    }
}
