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
    public class MunicipiosRepository : IMunicipioRepository
    {
        private readonly DirectorioV1DBContext _directorioV1DBContext;
        public MunicipiosRepository(DirectorioV1DBContext directorioV1DBContext)
        {
            this._directorioV1DBContext = directorioV1DBContext;
        }

        public async Task<MunicipiosEntity> Add(MunicipiosEntity municipiosEntity)
        {
            await _directorioV1DBContext.Municipios.AddAsync(municipiosEntity);
            await _directorioV1DBContext.SaveChangesAsync();
            return municipiosEntity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _directorioV1DBContext.Municipios.SingleAsync(x=>x.Id == id);
            _directorioV1DBContext.Municipios.Remove(entity);
            await _directorioV1DBContext.SaveChangesAsync();
        }

        public async Task<bool> Exist(int id)
        {
            var entity = await _directorioV1DBContext.Municipios.FirstOrDefaultAsync(x => x.Id == id);
            if(entity != null) {
                return true;
            }
            return false;
        }

        public async Task<MunicipiosEntity> Get(int id)
        {
            var result = await _directorioV1DBContext.Municipios.FirstOrDefaultAsync(r => r.Id == id);
            return result;
        }

        public async Task<IEnumerable<MunicipiosEntity>> GetAll()
        {
            return await _directorioV1DBContext.Municipios.ToListAsync();
        }

        public async Task<MunicipiosEntity> Update(int id, MunicipiosEntity element)
        {
            var entity = await Get(id);
            entity.Descripcion = element.Descripcion;
            return await Update(entity);

        }

        public async Task<MunicipiosEntity> Update(MunicipiosEntity element)
        {
            var updateMunicipios = _directorioV1DBContext.Municipios.Update(element);
            await _directorioV1DBContext.SaveChangesAsync();
            return updateMunicipios.Entity;
        }
    }
}
