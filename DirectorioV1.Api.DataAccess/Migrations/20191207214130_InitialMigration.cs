using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DirectorioV1.Api.DataAccess.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(nullable: true),
                    Estado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientesDirecciones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cliente_Id = table.Column<int>(nullable: false),
                    Direccion_Tipo_A = table.Column<string>(nullable: true),
                    Direccion_A = table.Column<string>(nullable: true),
                    Direccion_Tipo_B = table.Column<string>(nullable: true),
                    Direccion_B = table.Column<string>(nullable: true),
                    Direccion_Observacion = table.Column<string>(nullable: true),
                    Direccion_Compuesta = table.Column<string>(nullable: true),
                    Pais_Id = table.Column<int>(nullable: false),
                    Departamento_Id = table.Column<int>(nullable: false),
                    Ciudad_Id = table.Column<int>(nullable: false),
                    Municipio_Id = table.Column<int>(nullable: false),
                    Barrio_Id = table.Column<int>(nullable: false),
                    Latitud = table.Column<string>(nullable: true),
                    Longitud = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    Servicio_Domicilio = table.Column<bool>(nullable: false),
                    Estado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientesDirecciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(nullable: true),
                    Codigo = table.Column<string>(nullable: true),
                    Estado = table.Column<bool>(nullable: false),
                    Longitud = table.Column<string>(nullable: true),
                    Latitud = table.Column<string>(nullable: true),
                    Codigo_Postal = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    Correo = table.Column<string>(nullable: true),
                    Contrasena = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Tipo_Documento = table.Column<string>(nullable: true),
                    Documento = table.Column<string>(nullable: true),
                    Categoria_Id = table.Column<int>(nullable: false),
                    Fecha_Creacion = table.Column<DateTime>(nullable: false),
                    Estado = table.Column<bool>(nullable: false),
                    Correo = table.Column<string>(nullable: true),
                    CategoriasId = table.Column<int>(nullable: true),
                    ClientesDireccionesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clientes_Categorias_CategoriasId",
                        column: x => x.CategoriasId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clientes_ClientesDirecciones_ClientesDireccionesId",
                        column: x => x.ClientesDireccionesId,
                        principalTable: "ClientesDirecciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Pais_Id = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    Codigo = table.Column<string>(nullable: true),
                    Estado = table.Column<bool>(nullable: false),
                    Longitud = table.Column<string>(nullable: true),
                    Latitud = table.Column<string>(nullable: true),
                    Codigo_Postal = table.Column<string>(nullable: true),
                    PaisesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departamentos_Paises_PaisesId",
                        column: x => x.PaisesId,
                        principalTable: "Paises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Clientes2Direcciones",
                columns: table => new
                {
                    Cliente_Id = table.Column<int>(nullable: false),
                    Direccion_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes2Direcciones", x => new { x.Cliente_Id, x.Direccion_Id });
                    table.ForeignKey(
                        name: "FK_Clientes2Direcciones_Clientes_Cliente_Id",
                        column: x => x.Cliente_Id,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clientes2Direcciones_ClientesDirecciones_Direccion_Id",
                        column: x => x.Direccion_Id,
                        principalTable: "ClientesDirecciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ciudades",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Departamento_Id = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    Codigo = table.Column<string>(nullable: true),
                    Estado = table.Column<bool>(nullable: false),
                    Longitud = table.Column<string>(nullable: true),
                    Latitud = table.Column<string>(nullable: true),
                    Codigo_Postal = table.Column<string>(nullable: true),
                    DepartamentosId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ciudades_Departamentos_DepartamentosId",
                        column: x => x.DepartamentosId,
                        principalTable: "Departamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Paises2Departamentos",
                columns: table => new
                {
                    Pais_Id = table.Column<int>(nullable: false),
                    Departamento_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises2Departamentos", x => new { x.Pais_Id, x.Departamento_Id });
                    table.ForeignKey(
                        name: "FK_Paises2Departamentos_Departamentos_Departamento_Id",
                        column: x => x.Departamento_Id,
                        principalTable: "Departamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Paises2Departamentos_Paises_Pais_Id",
                        column: x => x.Pais_Id,
                        principalTable: "Paises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ciudades2Departamentos",
                columns: table => new
                {
                    Ciudad_Id = table.Column<int>(nullable: false),
                    Departamento_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudades2Departamentos", x => new { x.Ciudad_Id, x.Departamento_Id });
                    table.ForeignKey(
                        name: "FK_Ciudades2Departamentos_Ciudades_Ciudad_Id",
                        column: x => x.Ciudad_Id,
                        principalTable: "Ciudades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ciudades2Departamentos_Departamentos_Departamento_Id",
                        column: x => x.Departamento_Id,
                        principalTable: "Departamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Municipios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ciudad_Id = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    Codigo = table.Column<string>(nullable: true),
                    Estado = table.Column<bool>(nullable: false),
                    Longitud = table.Column<string>(nullable: true),
                    Latitud = table.Column<string>(nullable: true),
                    Codigo_Postal = table.Column<string>(nullable: true),
                    CiudadesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Municipios_Ciudades_CiudadesId",
                        column: x => x.CiudadesId,
                        principalTable: "Ciudades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Barrios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Municipio_Id = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    Codigo = table.Column<string>(nullable: true),
                    Estado = table.Column<bool>(nullable: false),
                    Longitud = table.Column<string>(nullable: true),
                    Latitud = table.Column<string>(nullable: true),
                    Codigo_Postal = table.Column<string>(nullable: true),
                    MunicipiosId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barrios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Barrios_Municipios_MunicipiosId",
                        column: x => x.MunicipiosId,
                        principalTable: "Municipios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Municipios2Ciudades",
                columns: table => new
                {
                    Muncipio_Id = table.Column<int>(nullable: false),
                    Ciudad_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipios2Ciudades", x => new { x.Ciudad_Id, x.Muncipio_Id });
                    table.ForeignKey(
                        name: "FK_Municipios2Ciudades_Ciudades_Ciudad_Id",
                        column: x => x.Ciudad_Id,
                        principalTable: "Ciudades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Municipios2Ciudades_Municipios_Muncipio_Id",
                        column: x => x.Muncipio_Id,
                        principalTable: "Municipios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Barrios2Municipios",
                columns: table => new
                {
                    Barrio_Id = table.Column<int>(nullable: false),
                    Municipio_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barrios2Municipios", x => new { x.Barrio_Id, x.Municipio_Id });
                    table.ForeignKey(
                        name: "FK_Barrios2Municipios_Barrios_Barrio_Id",
                        column: x => x.Barrio_Id,
                        principalTable: "Barrios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Barrios2Municipios_Municipios_Municipio_Id",
                        column: x => x.Municipio_Id,
                        principalTable: "Municipios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Barrios_MunicipiosId",
                table: "Barrios",
                column: "MunicipiosId");

            migrationBuilder.CreateIndex(
                name: "IX_Barrios2Municipios_Municipio_Id",
                table: "Barrios2Municipios",
                column: "Municipio_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Ciudades_DepartamentosId",
                table: "Ciudades",
                column: "DepartamentosId");

            migrationBuilder.CreateIndex(
                name: "IX_Ciudades2Departamentos_Departamento_Id",
                table: "Ciudades2Departamentos",
                column: "Departamento_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_CategoriasId",
                table: "Clientes",
                column: "CategoriasId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_ClientesDireccionesId",
                table: "Clientes",
                column: "ClientesDireccionesId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes2Direcciones_Direccion_Id",
                table: "Clientes2Direcciones",
                column: "Direccion_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Departamentos_PaisesId",
                table: "Departamentos",
                column: "PaisesId");

            migrationBuilder.CreateIndex(
                name: "IX_Municipios_CiudadesId",
                table: "Municipios",
                column: "CiudadesId");

            migrationBuilder.CreateIndex(
                name: "IX_Municipios2Ciudades_Muncipio_Id",
                table: "Municipios2Ciudades",
                column: "Muncipio_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Paises2Departamentos_Departamento_Id",
                table: "Paises2Departamentos",
                column: "Departamento_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Barrios2Municipios");

            migrationBuilder.DropTable(
                name: "Ciudades2Departamentos");

            migrationBuilder.DropTable(
                name: "Clientes2Direcciones");

            migrationBuilder.DropTable(
                name: "Municipios2Ciudades");

            migrationBuilder.DropTable(
                name: "Paises2Departamentos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Barrios");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Municipios");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "ClientesDirecciones");

            migrationBuilder.DropTable(
                name: "Ciudades");

            migrationBuilder.DropTable(
                name: "Departamentos");

            migrationBuilder.DropTable(
                name: "Paises");
        }
    }
}
