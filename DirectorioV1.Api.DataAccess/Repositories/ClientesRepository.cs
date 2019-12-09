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
    public class ClientesRepository : IClientesRepository
    {
        private readonly DirectorioV1DBContext _directorioV1DBContext;
        public ClientesRepository(DirectorioV1DBContext directorioV1DBContext)
        {
            this._directorioV1DBContext = directorioV1DBContext;
        }

        public async Task<ClientesEntity> Add(ClientesEntity clientesEntity)
        {
            await _directorioV1DBContext.Clientes.AddAsync(clientesEntity);
            await _directorioV1DBContext.SaveChangesAsync();
            return clientesEntity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _directorioV1DBContext.Clientes.SingleAsync(x=>x.Id == id);
            _directorioV1DBContext.Clientes.Remove(entity);
            await _directorioV1DBContext.SaveChangesAsync();
        }

        public async Task<bool> Exist(int id)
        {
            var entity = await _directorioV1DBContext.Clientes.FirstOrDefaultAsync(x => x.Id == id);
            if(entity != null) {
                return true;
            }
            return false;
        }

        public async Task<ClientesEntity> Get(int id)
        {
            var result = await _directorioV1DBContext.Clientes.FirstOrDefaultAsync(r => r.Id == id);
            return result;
        }

        public async Task<IEnumerable<ClientesEntity>> GetAll()
        {
            return await _directorioV1DBContext.Clientes.ToListAsync();
        }

        public async Task<ClientesEntity> Update(int id, ClientesEntity element)
        {
            var entity = await Get(id);
            entity.Nombre = element.Nombre;
            return await Update(entity);

        }

        public async Task<ClientesEntity> Update(ClientesEntity element)
        {
            var updateClientes = _directorioV1DBContext.Clientes.Update(element);
            await _directorioV1DBContext.SaveChangesAsync();
            return updateClientes.Entity;
        }
    }
}
