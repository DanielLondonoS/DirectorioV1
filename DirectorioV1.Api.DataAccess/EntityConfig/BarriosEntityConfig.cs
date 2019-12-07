using DirectorioV1.Api.DataAccess.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DirectorioV1.Api.DataAccess.EntityConfig
{
    public class BarriosEntityConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<BarriosEntity> entityBuilder)
        {
            entityBuilder.ToTable("Barrios");
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Id).IsRequired();

            //entityBuilder.HasOne(x => x.Municipios).WithOne(x => x.Barrios);
            //entityBuilder.HasOne(x => x.ClientesDirecciones).WithOne(x => x.Barrios);

        }
    }
}
