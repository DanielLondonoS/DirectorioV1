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
    public class CiudadesRepository : ICiudadesRepository
    {
        private readonly DirectorioV1DBContext _directorioV1DBContext;
        public CiudadesRepository(DirectorioV1DBContext directorioV1DBContext)
        {
            this._directorioV1DBContext = directorioV1DBContext;
        }

        public async Task<CiudadesEntity> Add(CiudadesEntity ciudadEntity)
        {
            await _directorioV1DBContext.Ciudades.AddAsync(ciudadEntity);
            await _directorioV1DBContext.SaveChangesAsync();
            return ciudadEntity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _directorioV1DBContext.Ciudades.SingleAsync(x=>x.Id == id);
            _directorioV1DBContext.Ciudades.Remove(entity);
            await _directorioV1DBContext.SaveChangesAsync();
        }

        public async Task<bool> Exist(int id)
        {
            var entity = await _directorioV1DBContext.Ciudades.FirstOrDefaultAsync(x => x.Id == id);
            if(entity != null) {
                return true;
            }
            return false;
        }

        public async Task<CiudadesEntity> Get(int id)
        {
            var result = await _directorioV1DBContext.Ciudades.FirstOrDefaultAsync(r => r.Id == id);
            return result;
        }

        public async Task<IEnumerable<CiudadesEntity>> GetAll()
        {
            return await _directorioV1DBContext.Ciudades.ToListAsync();
        }

        public async Task<CiudadesEntity> Update(int id, CiudadesEntity element)
        {
            var entity = await Get(id);
            entity.Descripcion = element.Descripcion;
            return await Update(entity);

        }

        public async Task<CiudadesEntity> Update(CiudadesEntity element)
        {
            var updateCiudad = _directorioV1DBContext.Ciudades.Update(element);
            await _directorioV1DBContext.SaveChangesAsync();
            return updateCiudad.Entity;
        }
    }
}
