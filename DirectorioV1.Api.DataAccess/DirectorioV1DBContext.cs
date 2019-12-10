using DirectorioV1.Api.DataAccess.Contracts;
using DirectorioV1.Api.DataAccess.Contracts.Entities;
using DirectorioV1.Api.DataAccess.EntityConfig;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DirectorioV1.Api.DataAccess
{
    public class DirectorioV1DBContext : DbContext, IDirectorioV1DBContext
    {

        public DbSet<UsuariosEntity> Usuarios { get; set; }
        public DbSet<BarriosEntity> Barrios { get; set; }
        public DbSet<CategoriasEntity> Categorias { get; set; }
        public DbSet<CiudadesEntity> Ciudades { get; set; }
        public DbSet<ClientesDireccionesEntity> ClientesDirecciones { get; set; }
        public DbSet<ClientesEntity> Clientes { get; set; }
        public DbSet<DepartamentosEntity> Departamentos { get; set; }
        public DbSet<PaisesEntity> Paises { get; set; }

        public DirectorioV1DBContext(DbContextOptions options) : base(options)
        {

        }

        public DirectorioV1DBContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            BarriosEntityConfig.SetEntityBuilder(modelBuilder.Entity<BarriosEntity>());
            CategoriaEntityConfig.SetEntityBuilder(modelBuilder.Entity<CategoriasEntity>());
            CiudadesEntityConfig.SetEntityBuilder(modelBuilder.Entity<CiudadesEntity>());
            ClientesDireccionEntityConfig.SetEntityBuilder(modelBuilder.Entity<ClientesDireccionesEntity>());
            ClientesEntityConfig.SetEntityBuilder(modelBuilder.Entity<ClientesEntity>());
            DepartamentosEntityConfig.SetEntityBuilder(modelBuilder.Entity<DepartamentosEntity>());
            PaisesEntityConfig.SetEntityBuilder(modelBuilder.Entity<PaisesEntity>());
            UsuarioEntityConfig.SetEntityBuilder(modelBuilder.Entity<UsuariosEntity>());

            base.OnModelCreating(modelBuilder);
        }
    }
}
