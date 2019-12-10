using DirectorioV1.Api.DataAccess.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DirectorioV1.Api.DataAccess.EntityConfig
{
    public class PaisesEntityConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<PaisesEntity> entityBuilder)
        {
            entityBuilder.ToTable("Paises");
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Id).IsRequired();

        }
    }
}
