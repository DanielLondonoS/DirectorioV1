using DirectorioV1.Api.DataAccess.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DirectorioV1.Api.DataAccess.EntityConfig
{
    public class Clientes2DireccionesEntityConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<Clientes2DireccionesEntity> entityBuilder)
        {
            entityBuilder.ToTable("Clientes2Direcciones");

            entityBuilder.HasOne(x => x.Cliente).WithMany(x => x.Clientes2Direcciones).HasForeignKey(x => x.Cliente_Id);
            entityBuilder.HasOne(x => x.ClienteDirecciones).WithMany(x => x.Clientes2Direcciones).HasForeignKey(x => x.Direccion_Id);

            entityBuilder.HasKey(x => new { x.Cliente_Id, x.Direccion_Id });
            entityBuilder.Property(x => x.Cliente_Id).IsRequired();
            entityBuilder.Property(x => x.Direccion_Id).IsRequired();
        }
    }
}
