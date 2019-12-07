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
        public DbSet<Barrios2MunicipiosEntity> Barrios2Municipios { get; set; }
        public DbSet<CategoriasEntity> Categorias { get; set; }
        public DbSet<Ciudades2DepartamentosEntity> Ciudades2Departamentos { get; set; }
        public DbSet<CiudadesEntity> Ciudades { get; set; }
        public DbSet<Clientes2DireccionesEntity> Clientes2Direcciones { get; set; }
        public DbSet<ClientesDireccionesEntity> ClientesDirecciones { get; set; }
        public DbSet<ClientesEntity> Clientes { get; set; }
        public DbSet<DepartamentosEntity> Departamentos { get; set; }
        public DbSet<Municipios2CiudadesEntity> Municipios2Ciudades { get; set; }
        public DbSet<MunicipiosEntity> Municipios { get; set; }
        public DbSet<Paises2DepartamentosEntity> Paises2Departamentos { get; set; }
        public DbSet<PaisesEntity> Paises { get; set; }

        public DirectorioV1DBContext(DbContextOptions options) : base(options)
        {

        }

        public DirectorioV1DBContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Barrios2MunicipiosEntityConfig.SetEntityBuilder(modelBuilder.Entity<Barrios2MunicipiosEntity>());
            BarriosEntityConfig.SetEntityBuilder(modelBuilder.Entity<BarriosEntity>());
            CategoriaEntityConfig.SetEntityBuilder(modelBuilder.Entity<CategoriasEntity>());
            Ciudades2DepartamentosEntityConfig.SetEntityBuilder(modelBuilder.Entity<Ciudades2DepartamentosEntity>());
            CiudadesEntityConfig.SetEntityBuilder(modelBuilder.Entity<CiudadesEntity>());
            Clientes2DireccionesEntityConfig.SetEntityBuilder(modelBuilder.Entity<Clientes2DireccionesEntity>());
            ClientesDireccionEntityConfig.SetEntityBuilder(modelBuilder.Entity<ClientesDireccionesEntity>());
            ClientesEntityConfig.SetEntityBuilder(modelBuilder.Entity<ClientesEntity>());
            DepartamentosEntityConfig.SetEntityBuilder(modelBuilder.Entity<DepartamentosEntity>());
            Municipios2CiudadesEntityConfig.SetEntityBuilder(modelBuilder.Entity<Municipios2CiudadesEntity>());
            MunicipiosEntityConfig.SetEntityBuilder(modelBuilder.Entity<MunicipiosEntity>());
            Paises2DepartamentosEntityConfig.SetEntityBuilder(modelBuilder.Entity<Paises2DepartamentosEntity>());
            PaisesEntityConfig.SetEntityBuilder(modelBuilder.Entity<PaisesEntity>());
            UsuarioEntityConfig.SetEntityBuilder(modelBuilder.Entity<UsuariosEntity>());

            base.OnModelCreating(modelBuilder);
        }
    }
}
