using DirectorioV1.Api.DataAccess.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DirectorioV1.Api.DataAccess.EntityConfig
{
    public class CiudadesEntityConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<CiudadesEntity> entityBuilder)
        {
            entityBuilder.ToTable("Ciudades");
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Id).IsRequired();
            



        }
    }
}
