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
    public class ClientesDireccionesRepository : IClientesDireccionesRepository
    {
        private readonly DirectorioV1DBContext _directorioV1DBContext;
        public ClientesDireccionesRepository(DirectorioV1DBContext directorioV1DBContext)
        {
            this._directorioV1DBContext = directorioV1DBContext;
        }

        public async Task<ClientesDireccionesEntity> Add(ClientesDireccionesEntity clientesDireccionesEntity)
        {
            await _directorioV1DBContext.ClientesDirecciones.AddAsync(clientesDireccionesEntity);
            await _directorioV1DBContext.SaveChangesAsync();
            return clientesDireccionesEntity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _directorioV1DBContext.ClientesDirecciones.SingleAsync(x=>x.Id == id);
            _directorioV1DBContext.ClientesDirecciones.Remove(entity);
            await _directorioV1DBContext.SaveChangesAsync();
        }

        public async Task<bool> Exist(int id)
        {
            var entity = await _directorioV1DBContext.ClientesDirecciones.FirstOrDefaultAsync(x => x.Id == id);
            if(entity != null) {
                return true;
            }
            return false;
        }

        public async Task<ClientesDireccionesEntity> Get(int id)
        {
            var result = await _directorioV1DBContext.ClientesDirecciones.FirstOrDefaultAsync(r => r.Id == id);
            return result;
        }

        public async Task<IEnumerable<ClientesDireccionesEntity>> GetAll()
        {
            return await _directorioV1DBContext.ClientesDirecciones.ToListAsync();
        }

        public async Task<ClientesDireccionesEntity> Update(int id, ClientesDireccionesEntity element)
        {
            var entity = await Get(id);
            entity.Telefono = element.Telefono;
            return await Update(entity);

        }

        public async Task<ClientesDireccionesEntity> Update(ClientesDireccionesEntity element)
        {
            var updateClientesDirecciones = _directorioV1DBContext.ClientesDirecciones.Update(element);
            await _directorioV1DBContext.SaveChangesAsync();
            return updateClientesDirecciones.Entity;
        }
    }
}
