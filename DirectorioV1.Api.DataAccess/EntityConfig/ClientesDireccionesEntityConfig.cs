using DirectorioV1.Api.DataAccess.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DirectorioV1.Api.DataAccess.EntityConfig
{
    public class ClientesDireccionEntityConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<ClientesDireccionesEntity> entityBuilder)
        {
            entityBuilder.ToTable("ClientesDirecciones");
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Id).IsRequired();
        }
    }
}
