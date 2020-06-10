using DirectorioV1.Api.DataAccess.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DirectorioV1.Api.DataAccess.EntityConfig
{
    public class ClientesImagenesEntityConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<ClientesImagenesEntity> entityBuilder)
        {
            entityBuilder.ToTable("ClientesImagenes");
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.HasOne(x => x.Cliente).WithMany(x => x.Imagenes).OnDelete(DeleteBehavior.Cascade);
            entityBuilder.Property(x => x.Id).IsRequired();


        }
    }
}
