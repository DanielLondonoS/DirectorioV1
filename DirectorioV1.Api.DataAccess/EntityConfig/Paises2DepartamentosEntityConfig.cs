using DirectorioV1.Api.DataAccess.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DirectorioV1.Api.DataAccess.EntityConfig
{
    public class Paises2DepartamentosEntityConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<Paises2DepartamentosEntity> entityBuilder)
        {
            entityBuilder.ToTable("Paises2Departamentos");

            entityBuilder.HasOne(x => x.Departamentos).WithMany(x => x.Paises2Departamentos).HasForeignKey(x => x.Departamento_Id);
            entityBuilder.HasOne(x => x.Paises).WithMany(x => x.Paises2Departamentos).HasForeignKey(x => x.Pais_Id);

            entityBuilder.HasKey(x => new { x.Pais_Id, x.Departamento_Id });
            entityBuilder.Property(x => x.Pais_Id).IsRequired();
            entityBuilder.Property(x => x.Departamento_Id).IsRequired();



        }
    }
}
