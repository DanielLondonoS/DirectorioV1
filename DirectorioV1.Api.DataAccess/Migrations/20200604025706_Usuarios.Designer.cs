﻿// <auto-generated />
using System;
using DirectorioV1.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DirectorioV1.Api.DataAccess.Migrations
{
    [DbContext(typeof(DirectorioV1DBContext))]
    [Migration("20200604025706_Usuarios")]
    partial class Usuarios
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DirectorioV1.Api.DataAccess.Contracts.Entities.BarriosEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ciudad_Id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CiudadesEntityId")
                        .HasColumnType("int");

                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Codigo_Postal")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<string>("Latitud")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Longitud")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CiudadesEntityId");

                    b.ToTable("Barrios");
                });

            modelBuilder.Entity("DirectorioV1.Api.DataAccess.Contracts.Entities.CategoriasEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("DirectorioV1.Api.DataAccess.Contracts.Entities.CiudadesEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Codigo_Postal")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<int>("Departamento_Id")
                        .HasColumnType("int");

                    b.Property<int?>("DepartamentosEntityId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<string>("Latitud")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Longitud")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartamentosEntityId");

                    b.ToTable("Ciudades");
                });

            modelBuilder.Entity("DirectorioV1.Api.DataAccess.Contracts.Entities.ClientesDireccionesEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Barrio_Id")
                        .HasColumnType("int");

                    b.Property<int>("Ciudad_Id")
                        .HasColumnType("int");

                    b.Property<int>("Cliente_Id")
                        .HasColumnType("int");

                    b.Property<int?>("ClientesEntityId")
                        .HasColumnType("int");

                    b.Property<int>("Departamento_Id")
                        .HasColumnType("int");

                    b.Property<string>("Direccion_A")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion_B")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion_Compuesta")
                        .HasColumnType("nvarchar(400)")
                        .HasMaxLength(400);

                    b.Property<string>("Direccion_Observacion")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Direccion_Tipo_A")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion_Tipo_B")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<string>("Latitud")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Longitud")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Municipio_Id")
                        .HasColumnType("int");

                    b.Property<int>("Pais_Id")
                        .HasColumnType("int");

                    b.Property<bool>("Servicio_Domicilio")
                        .HasColumnType("bit");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClientesEntityId");

                    b.ToTable("ClientesDirecciones");
                });

            modelBuilder.Entity("DirectorioV1.Api.DataAccess.Contracts.Entities.ClientesEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Categoria_Id")
                        .HasColumnType("int")
                        .HasMaxLength(100);

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Documento")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Fecha_Creacion")
                        .HasColumnType("datetime2")
                        .HasMaxLength(100);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("Tipo_Documento")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("DirectorioV1.Api.DataAccess.Contracts.Entities.DepartamentosEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Codigo_Postal")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<string>("Latitud")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Longitud")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Pais_Id")
                        .HasColumnType("int")
                        .HasMaxLength(100);

                    b.Property<int?>("PaisesEntityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PaisesEntityId");

                    b.ToTable("Departamentos");
                });

            modelBuilder.Entity("DirectorioV1.Api.DataAccess.Contracts.Entities.PaisesEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Codigo_Postal")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<string>("Latitud")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Longitud")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Paises");
                });

            modelBuilder.Entity("DirectorioV1.Api.DataAccess.Contracts.Entities.BarriosEntity", b =>
                {
                    b.HasOne("DirectorioV1.Api.DataAccess.Contracts.Entities.CiudadesEntity", null)
                        .WithMany("Barrios")
                        .HasForeignKey("CiudadesEntityId");
                });

            modelBuilder.Entity("DirectorioV1.Api.DataAccess.Contracts.Entities.CiudadesEntity", b =>
                {
                    b.HasOne("DirectorioV1.Api.DataAccess.Contracts.Entities.DepartamentosEntity", null)
                        .WithMany("Ciudades")
                        .HasForeignKey("DepartamentosEntityId");
                });

            modelBuilder.Entity("DirectorioV1.Api.DataAccess.Contracts.Entities.ClientesDireccionesEntity", b =>
                {
                    b.HasOne("DirectorioV1.Api.DataAccess.Contracts.Entities.ClientesEntity", null)
                        .WithMany("Direcciones")
                        .HasForeignKey("ClientesEntityId");
                });

            modelBuilder.Entity("DirectorioV1.Api.DataAccess.Contracts.Entities.DepartamentosEntity", b =>
                {
                    b.HasOne("DirectorioV1.Api.DataAccess.Contracts.Entities.PaisesEntity", null)
                        .WithMany("Departamentos")
                        .HasForeignKey("PaisesEntityId");
                });
#pragma warning restore 612, 618
        }
    }
}
