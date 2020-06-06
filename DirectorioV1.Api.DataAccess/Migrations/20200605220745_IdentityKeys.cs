using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DirectorioV1.Api.DataAccess.Migrations
{
    public partial class IdentityKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Barrios_Ciudades_CiudadId",
                table: "Barrios");

            migrationBuilder.DropForeignKey(
                name: "FK_Ciudades_Departamentos_DepartamentoId",
                table: "Ciudades");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientesDirecciones_Clientes_ClienteId",
                table: "ClientesDirecciones");

            migrationBuilder.DropIndex(
                name: "IX_ClientesDirecciones_ClienteId",
                table: "ClientesDirecciones");

            migrationBuilder.DropIndex(
                name: "IX_Ciudades_DepartamentoId",
                table: "Ciudades");

            migrationBuilder.DropIndex(
                name: "IX_Barrios_CiudadId",
                table: "Barrios");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "ClientesDirecciones");

            migrationBuilder.DropColumn(
                name: "DepartamentoId",
                table: "Ciudades");

            migrationBuilder.DropColumn(
                name: "CiudadId",
                table: "Barrios");

            migrationBuilder.AlterColumn<int>(
                name: "Ciudad_Id",
                table: "Barrios",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_ClientesDirecciones_Cliente_Id",
                table: "ClientesDirecciones",
                column: "Cliente_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Ciudades_Departamento_Id",
                table: "Ciudades",
                column: "Departamento_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Barrios_Ciudad_Id",
                table: "Barrios",
                column: "Ciudad_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Barrios_Ciudades_Ciudad_Id",
                table: "Barrios",
                column: "Ciudad_Id",
                principalTable: "Ciudades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ciudades_Departamentos_Departamento_Id",
                table: "Ciudades",
                column: "Departamento_Id",
                principalTable: "Departamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientesDirecciones_Clientes_Cliente_Id",
                table: "ClientesDirecciones",
                column: "Cliente_Id",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Barrios_Ciudades_Ciudad_Id",
                table: "Barrios");

            migrationBuilder.DropForeignKey(
                name: "FK_Ciudades_Departamentos_Departamento_Id",
                table: "Ciudades");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientesDirecciones_Clientes_Cliente_Id",
                table: "ClientesDirecciones");

            migrationBuilder.DropTable(
                name: "UsuariosEntity");

            migrationBuilder.DropIndex(
                name: "IX_ClientesDirecciones_Cliente_Id",
                table: "ClientesDirecciones");

            migrationBuilder.DropIndex(
                name: "IX_Ciudades_Departamento_Id",
                table: "Ciudades");

            migrationBuilder.DropIndex(
                name: "IX_Barrios_Ciudad_Id",
                table: "Barrios");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "ClientesDirecciones",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartamentoId",
                table: "Ciudades",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Ciudad_Id",
                table: "Barrios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "CiudadId",
                table: "Barrios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientesDirecciones_ClienteId",
                table: "ClientesDirecciones",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Ciudades_DepartamentoId",
                table: "Ciudades",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Barrios_CiudadId",
                table: "Barrios",
                column: "CiudadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Barrios_Ciudades_CiudadId",
                table: "Barrios",
                column: "CiudadId",
                principalTable: "Ciudades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ciudades_Departamentos_DepartamentoId",
                table: "Ciudades",
                column: "DepartamentoId",
                principalTable: "Departamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientesDirecciones_Clientes_ClienteId",
                table: "ClientesDirecciones",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
