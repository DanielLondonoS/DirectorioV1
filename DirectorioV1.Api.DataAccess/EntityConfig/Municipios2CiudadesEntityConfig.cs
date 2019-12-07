using DirectorioV1.Api.DataAccess.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DirectorioV1.Api.DataAccess.EntityConfig
{
    public class Municipios2CiudadesEntityConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<Municipios2CiudadesEntity> entityBuilder)
        {
            entityBuilder.ToTable("Municipios2Ciudades");

            entityBuilder.HasOne(x => x.Municipios).WithMany(x => x.Municipios2Ciudades).HasForeignKey(x => x.Muncipio_Id);
            entityBuilder.HasOne(x => x.Ciudades).WithMany(x => x.Municipios2Ciudades).HasForeignKey(x => x.Ciudad_Id);

            entityBuilder.HasKey(x => new { x.Ciudad_Id, x.Muncipio_Id });
            entityBuilder.Property(x => x.Ciudad_Id).IsRequired();
            entityBuilder.Property(x => x.Muncipio_Id).IsRequired();
        }
    }
}
