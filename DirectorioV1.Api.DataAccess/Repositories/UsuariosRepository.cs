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
    public class UsuariosRepository : IUsuariosRepository
    {
        private readonly DirectorioV1DBContext _directorioV1DBContext;
        public UsuariosRepository(DirectorioV1DBContext directorioV1DBContext)
        {
            this._directorioV1DBContext = directorioV1DBContext;
        }

        public async Task<UsuariosEntity> Add(UsuariosEntity usuariosEntity)
        {
            await _directorioV1DBContext.Usuarios.AddAsync(usuariosEntity);
            await _directorioV1DBContext.SaveChangesAsync();
            return usuariosEntity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _directorioV1DBContext.Usuarios.SingleAsync(x=>x.Id == id);
            _directorioV1DBContext.Usuarios.Remove(entity);
            await _directorioV1DBContext.SaveChangesAsync();
        }

        public async Task<bool> Exist(int id)
        {
            var entity = await _directorioV1DBContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
            if(entity != null) {
                return true;
            }
            return false;
        }

        public async Task<UsuariosEntity> Get(int id)
        {
            var result = await _directorioV1DBContext.Usuarios.FirstOrDefaultAsync(r => r.Id == id);
            return result;
        }

        public async Task<IEnumerable<UsuariosEntity>> GetAll()
        {
            return await _directorioV1DBContext.Usuarios.ToListAsync();
        }

        public async Task<UsuariosEntity> Update(int id, UsuariosEntity element)
        {
            var entity = await Get(id);
            entity.Nombre = element.Nombre;
            return await Update(entity);

        }

        public async Task<UsuariosEntity> Update(UsuariosEntity element)
        {
            var updateUsuarios = _directorioV1DBContext.Usuarios.Update(element);
            await _directorioV1DBContext.SaveChangesAsync();
            return updateUsuarios.Entity;
        }
    }
}
