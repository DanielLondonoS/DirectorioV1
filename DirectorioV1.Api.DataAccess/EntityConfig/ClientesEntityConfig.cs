using DirectorioV1.Api.DataAccess.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DirectorioV1.Api.DataAccess.EntityConfig
{
    public class ClientesEntityConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<ClientesEntity> entityBuilder)
        {
            entityBuilder.ToTable("Clientes");
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Id).IsRequired();

            //entityBuilder.HasOne(x => x.Categorias).WithOne(x => x.Clientes);
            //entityBuilder.HasOne(x => x.ClientesDirecciones).WithOne(x => x.Clientes);
        }
    }
}
