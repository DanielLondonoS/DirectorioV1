using DirectorioV1.Api.DataAccess.Contracts.Entities;
using DirectorioV1.Api.DataAccess.Contracts.Repositories;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DirectorioV1.Api.DataAccess.Repositories
{
    public class BarriosRepository : GenericRepository<BarriosEntity>, IBarriosRepository
    {
        private readonly DirectorioV1DBContext _directorioV1DBContext;
        public BarriosRepository(DirectorioV1DBContext directorioV1DBContext) : base(directorioV1DBContext)
        {
            this._directorioV1DBContext = directorioV1DBContext;
        }

        public IEnumerable<SelectListItem> ComboBarrios()
        {
            return this._directorioV1DBContext.Barrios.Select(a =>

                new SelectListItem
                {
                    Value = a.Id.ToString(),
                    Text = a.Descripcion
                }).ToList();
        }

        public async Task<ICollection<BarriosEntity>> ListaBarriosConCiudades()
        {
            return await this._directorioV1DBContext.Barrios.Include(p => p.Ciudad).ToListAsync();
        }

        //public async Task<BarriosEntity> Add(BarriosEntity barriosEntity)
        //{
        //    await _directorioV1DBContext.Barrios.AddAsync(barriosEntity);
        //    await _directorioV1DBContext.SaveChangesAsync();
        //    return barriosEntity;
        //}

        //public async Task DeleteAsync(int id)
        //{
        //    var entity = await _directorioV1DBContext.Barrios.SingleAsync(x=>x.Id == id);
        //    _directorioV1DBContext.Barrios.Remove(entity);
        //    await _directorioV1DBContext.SaveChangesAsync();
        //}

        //public async Task<bool> Exist(int id)
        //{
        //    var entity = await _directorioV1DBContext.Barrios.FirstOrDefaultAsync(x => x.Id == id);
        //    if(entity != null) {
        //        return true;
        //    }
        //    return false;
        //}

        //public async Task<BarriosEntity> Get(int id)
        //{
        //    var result = await _directorioV1DBContext.Barrios.FirstOrDefaultAsync(r => r.Id == id);
        //    return result;
        //}

        //public async Task<IEnumerable<BarriosEntity>> GetAll()
        //{
        //    return await _directorioV1DBContext.Barrios.ToListAsync();
        //}

        //public async Task<BarriosEntity> Update(int id, BarriosEntity element)
        //{
        //    var entity = await Get(id);
        //    entity.Descripcion = element.Descripcion;
        //    entity.Codigo = element.Codigo;
        //    entity.Codigo_Postal = element.Codigo_Postal;
        //    entity.Latitud = element.Latitud;
        //    entity.Longitud = element.Longitud;
        //    entity.Estado = element.Estado;            
        //    return await Update(entity);

        //}

        //public async Task<BarriosEntity> Update(BarriosEntity element)
        //{
        //    var updateBarrio = _directorioV1DBContext.Barrios.Update(element);
        //    await _directorioV1DBContext.SaveChangesAsync();
        //    return updateBarrio.Entity;
        //}
    }
}
