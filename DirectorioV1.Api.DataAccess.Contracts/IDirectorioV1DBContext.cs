using DirectorioV1.Api.DataAccess.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DirectorioV1.Api.DataAccess.Contracts
{
    public interface IDirectorioV1DBContext
    {
        DbSet<UsuariosEntity> Usuarios { get; set; }
        DbSet<BarriosEntity> Barrios { get; set; }
        DbSet<CategoriasEntity> Categorias { get; set; }
        DbSet<CiudadesEntity> Ciudades { get; set; }
        DbSet<ClientesDireccionesEntity> ClientesDirecciones { get; set; }
        DbSet<ClientesEntity> Clientes { get; set; }
        DbSet<DepartamentosEntity> Departamentos { get; set; }
        DbSet<PaisesEntity> Paises { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DatabaseFacade Database { get; }
        Task<int> SaveChangesAsync(CancellationToken cancelationToken = default(CancellationToken));
        void RemoveRange(IEnumerable<object> entities);
        EntityEntry Update(object entity);
    }
}
