using DirectorioV1.Api.DataAccess.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DirectorioV1.Api.DataAccess.EntityConfig
{
    public class Ciudades2DepartamentosEntityConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<Ciudades2DepartamentosEntity> entityBuilder)
        {
            entityBuilder.ToTable("Ciudades2Departamentos");

            entityBuilder.HasOne(x => x.Departamentos).WithMany(x => x.Ciudades2Departamentos).HasForeignKey(x => x.Departamento_Id);
            entityBuilder.HasOne(x => x.Ciudades).WithMany(x => x.Ciudades2Departamentos).HasForeignKey(x => x.Ciudad_Id);

            entityBuilder.HasKey(x => new { x.Ciudad_Id, x.Departamento_Id });
            entityBuilder.Property(x => x.Ciudad_Id).IsRequired();
            entityBuilder.Property(x => x.Departamento_Id).IsRequired();
        }
    }
}
