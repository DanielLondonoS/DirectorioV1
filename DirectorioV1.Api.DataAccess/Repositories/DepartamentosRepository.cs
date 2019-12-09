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
    public class DepartamentosRepository : IDepartamentosRepository
    {
        private readonly DirectorioV1DBContext _directorioV1DBContext;
        public DepartamentosRepository(DirectorioV1DBContext directorioV1DBContext)
        {
            this._directorioV1DBContext = directorioV1DBContext;
        }

        public async Task<DepartamentosEntity> Add(DepartamentosEntity departamentosEntity)
        {
            await _directorioV1DBContext.Departamentos.AddAsync(departamentosEntity);
            await _directorioV1DBContext.SaveChangesAsync();
            return departamentosEntity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _directorioV1DBContext.Departamentos.SingleAsync(x=>x.Id == id);
            _directorioV1DBContext.Departamentos.Remove(entity);
            await _directorioV1DBContext.SaveChangesAsync();
        }

        public async Task<bool> Exist(int id)
        {
            var entity = await _directorioV1DBContext.Departamentos.FirstOrDefaultAsync(x => x.Id == id);
            if(entity != null) {
                return true;
            }
            return false;
        }

        public async Task<DepartamentosEntity> Get(int id)
        {
            var result = await _directorioV1DBContext.Departamentos.FirstOrDefaultAsync(r => r.Id == id);
            return result;
        }

        public async Task<IEnumerable<DepartamentosEntity>> GetAll()
        {
            return await _directorioV1DBContext.Departamentos.ToListAsync();
        }

        public async Task<DepartamentosEntity> Update(int id, DepartamentosEntity element)
        {
            var entity = await Get(id);
            entity.Descripcion = element.Descripcion;
            return await Update(entity);

        }

        public async Task<DepartamentosEntity> Update(DepartamentosEntity element)
        {
            var updateDepartamentos = _directorioV1DBContext.Departamentos.Update(element);
            await _directorioV1DBContext.SaveChangesAsync();
            return updateDepartamentos.Entity;
        }
    }
}
