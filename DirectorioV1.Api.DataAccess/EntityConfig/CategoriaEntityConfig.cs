using DirectorioV1.Api.DataAccess.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DirectorioV1.Api.DataAccess.EntityConfig
{
    public class CategoriaEntityConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<CategoriasEntity> entityBuilder)
        {
            entityBuilder.ToTable("Categorias");
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Id).IsRequired();

            entityBuilder.HasOne(x => x.Clientes).WithOne(x => x.Categorias);
        }
    }
}
