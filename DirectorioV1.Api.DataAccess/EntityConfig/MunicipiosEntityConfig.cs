using DirectorioV1.Api.DataAccess.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DirectorioV1.Api.DataAccess.EntityConfig
{
    public class MunicipiosEntityConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<MunicipiosEntity> entityBuilder)
        {
            entityBuilder.ToTable("Municipios");
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Id).IsRequired();

            entityBuilder.HasOne(x => x.Ciudades).WithOne(x => x.Municipios);
            entityBuilder.HasOne(x => x.Barrios).WithOne(x => x.Municipios);
            entityBuilder.HasOne(x => x.ClientesDirecciones).WithOne(x => x.Municipios);

        }
    }
}
