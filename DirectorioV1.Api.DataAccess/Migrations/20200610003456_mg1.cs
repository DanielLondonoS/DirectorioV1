using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DirectorioV1.Api.DataAccess.Migrations
{
    public partial class mg1 : Migration
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
                name: "UsuariosEntity",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 150, nullable: true),
                    Correo = table.Column<string>(maxLength: 100, nullable: true),
                    Tipo_Documento = table.Column<string>(nullable: true),
                    Documento = table.Column<string>(maxLength: 20, nullable: true),
                    Fecha_Creacion = table.Column<DateTime>(nullable: true),
                    Estado = table.Column<bool>(nullable: false),
                    CategoriaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clientes_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(nullable: true),
                    Codigo = table.Column<string>(nullable: true),
                    Estado = table.Column<bool>(nullable: false),
                    Longitud = table.Column<string>(nullable: true),
                    Latitud = table.Column<string>(nullable: true),
                    Codigo_Postal = table.Column<string>(nullable: true),
                    PaisId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departamentos_Paises_PaisId",
                        column: x => x.PaisId,
                        principalTable: "Paises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientesImagenes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    Estado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientesImagenes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientesImagenes_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ciudades",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(maxLength: 100, nullable: true),
                    Codigo = table.Column<string>(nullable: true),
                    Estado = table.Column<bool>(nullable: false),
                    Longitud = table.Column<string>(nullable: true),
                    Latitud = table.Column<string>(nullable: true),
                    Codigo_Postal = table.Column<string>(maxLength: 10, nullable: true),
                    DepartamentoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ciudades_Departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Barrios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(maxLength: 100, nullable: true),
                    Codigo = table.Column<string>(maxLength: 10, nullable: true),
                    Estado = table.Column<bool>(nullable: false),
                    Longitud = table.Column<string>(nullable: true),
                    Latitud = table.Column<string>(nullable: true),
                    Codigo_Postal = table.Column<string>(maxLength: 10, nullable: true),
                    CiudadId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barrios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Barrios_Ciudades_CiudadId",
                        column: x => x.CiudadId,
                        principalTable: "Ciudades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientesDirecciones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Direccion_Tipo_A = table.Column<string>(nullable: true),
                    Direccion_A = table.Column<string>(nullable: true),
                    Direccion_Tipo_B = table.Column<string>(nullable: true),
                    Direccion_B = table.Column<string>(nullable: true),
                    Direccion_Observacion = table.Column<string>(maxLength: 250, nullable: true),
                    Direccion_Compuesta = table.Column<string>(maxLength: 400, nullable: true),
                    Latitud = table.Column<string>(nullable: true),
                    Longitud = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    Servicio_Domicilio = table.Column<bool>(nullable: false),
                    Estado = table.Column<bool>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false),
                    PaisId = table.Column<int>(nullable: true),
                    CiudadId = table.Column<int>(nullable: true),
                    DepartamentoId = table.Column<int>(nullable: true),
                    BarrioId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientesDirecciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientesDirecciones_Barrios_BarrioId",
                        column: x => x.BarrioId,
                        principalTable: "Barrios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientesDirecciones_Ciudades_CiudadId",
                        column: x => x.CiudadId,
                        principalTable: "Ciudades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientesDirecciones_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientesDirecciones_Departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientesDirecciones_Paises_PaisId",
                        column: x => x.PaisId,
                        principalTable: "Paises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Barrios_CiudadId",
                table: "Barrios",
                column: "CiudadId");

            migrationBuilder.CreateIndex(
                name: "IX_Ciudades_DepartamentoId",
                table: "Ciudades",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_CategoriaId",
                table: "Clientes",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientesDirecciones_BarrioId",
                table: "ClientesDirecciones",
                column: "BarrioId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientesDirecciones_CiudadId",
                table: "ClientesDirecciones",
                column: "CiudadId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientesDirecciones_ClienteId",
                table: "ClientesDirecciones",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientesDirecciones_DepartamentoId",
                table: "ClientesDirecciones",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientesDirecciones_PaisId",
                table: "ClientesDirecciones",
                column: "PaisId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientesImagenes_ClienteId",
                table: "ClientesImagenes",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Departamentos_PaisId",
                table: "Departamentos",
                column: "PaisId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientesDirecciones");

            migrationBuilder.DropTable(
                name: "ClientesImagenes");

            migrationBuilder.DropTable(
                name: "UsuariosEntity");

            migrationBuilder.DropTable(
                name: "Barrios");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Ciudades");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Departamentos");

            migrationBuilder.DropTable(
                name: "Paises");
        }
    }
}
