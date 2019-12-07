using DirectorioV1.Api.DataAccess.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DirectorioV1.Api.DataAccess.EntityConfig
{
    public class Barrios2MunicipiosEntityConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<Barrios2MunicipiosEntity> entityBuilder)
        {
            entityBuilder.ToTable("Barrios2Municipios");

            entityBuilder.HasOne(x => x.Barrios).WithMany(x => x.Barrios2Municipios).HasForeignKey(x => x.Barrio_Id);
            entityBuilder.HasOne(x => x.Municipios).WithMany(x => x.Barrios2Municipios).HasForeignKey(x => x.Municipio_Id);

            entityBuilder.HasKey(x => new { x.Barrio_Id, x.Municipio_Id });
            entityBuilder.Property(x => x.Barrio_Id).IsRequired();
            entityBuilder.Property(x => x.Municipio_Id).IsRequired();
        }
    }
}
