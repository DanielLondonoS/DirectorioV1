using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DirectorioV1.Api.DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(maxLength: 100, nullable: true),
                    Estado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 150, nullable: true),
                    Tipo_Documento = table.Column<string>(maxLength: 100, nullable: true),
                    Documento = table.Column<string>(maxLength: 20, nullable: true),
                    Categoria_Id = table.Column<int>(maxLength: 100, nullable: false),
                    Fecha_Creacion = table.Column<DateTime>(maxLength: 100, nullable: true),
                    Estado = table.Column<bool>(nullable: false),
                    Correo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(maxLength: 100, nullable: true),
                    Codigo = table.Column<string>(nullable: true),
                    Estado = table.Column<bool>(nullable: false),
                    Longitud = table.Column<string>(nullable: true),
                    Latitud = table.Column<string>(nullable: true),
                    Codigo_Postal = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientesDirecciones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cliente_Id = table.Column<int>(nullable: false),
                    Direccion_Tipo_A = table.Column<string>(nullable: true),
                    Direccion_A = table.Column<string>(nullable: true),
                    Direccion_Tipo_B = table.Column<string>(nullable: true),
                    Direccion_B = table.Column<string>(nullable: true),
                    Direccion_Observacion = table.Column<string>(maxLength: 250, nullable: true),
                    Direccion_Compuesta = table.Column<string>(maxLength: 400, nullable: true),
                    Pais_Id = table.Column<int>(nullable: false),
                    Departamento_Id = table.Column<int>(nullable: false),
                    Ciudad_Id = table.Column<int>(nullable: false),
                    Municipio_Id = table.Column<int>(nullable: false),
                    Barrio_Id = table.Column<int>(nullable: false),
                    Latitud = table.Column<string>(nullable: true),
                    Longitud = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    Servicio_Domicilio = table.Column<bool>(nullable: false),
                    Estado = table.Column<bool>(nullable: false),
                    ClientesEntityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientesDirecciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientesDirecciones_Clientes_ClientesEntityId",
                        column: x => x.ClientesEntityId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pais_Id = table.Column<int>(maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(maxLength: 100, nullable: true),
                    Codigo = table.Column<string>(nullable: true),
                    Estado = table.Column<bool>(nullable: false),
                    Longitud = table.Column<string>(nullable: true),
                    Latitud = table.Column<string>(nullable: true),
                    Codigo_Postal = table.Column<string>(maxLength: 10, nullable: true),
                    PaisesEntityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departamentos_Paises_PaisesEntityId",
                        column: x => x.PaisesEntityId,
                        principalTable: "Paises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ciudades",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Departamento_Id = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(maxLength: 100, nullable: true),
                    Codigo = table.Column<string>(nullable: true),
                    Estado = table.Column<bool>(nullable: false),
                    Longitud = table.Column<string>(nullable: true),
                    Latitud = table.Column<string>(nullable: true),
                    Codigo_Postal = table.Column<string>(maxLength: 10, nullable: true),
                    DepartamentosEntityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ciudades_Departamentos_DepartamentosEntityId",
                        column: x => x.DepartamentosEntityId,
                        principalTable: "Departamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Barrios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ciudad_Id = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(maxLength: 100, nullable: true),
                    Codigo = table.Column<string>(maxLength: 10, nullable: true),
                    Estado = table.Column<bool>(nullable: false),
                    Longitud = table.Column<string>(nullable: true),
                    Latitud = table.Column<string>(nullable: true),
                    Codigo_Postal = table.Column<string>(maxLength: 10, nullable: true),
                    CiudadesEntityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barrios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Barrios_Ciudades_CiudadesEntityId",
                        column: x => x.CiudadesEntityId,
                        principalTable: "Ciudades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Barrios_CiudadesEntityId",
                table: "Barrios",
                column: "CiudadesEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Ciudades_DepartamentosEntityId",
                table: "Ciudades",
                column: "DepartamentosEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientesDirecciones_ClientesEntityId",
                table: "ClientesDirecciones",
                column: "ClientesEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Departamentos_PaisesEntityId",
                table: "Departamentos",
                column: "PaisesEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Barrios");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "ClientesDirecciones");

            migrationBuilder.DropTable(
                name: "Ciudades");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Departamentos");

            migrationBuilder.DropTable(
                name: "Paises");
        }
    }
}
