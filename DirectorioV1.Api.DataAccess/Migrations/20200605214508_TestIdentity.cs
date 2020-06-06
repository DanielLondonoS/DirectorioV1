using Microsoft.EntityFrameworkCore.Migrations;

namespace DirectorioV1.Api.DataAccess.Migrations
{
    public partial class TestIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Barrios_Ciudades_CiudadesEntityId",
                table: "Barrios");

            migrationBuilder.DropForeignKey(
                name: "FK_Ciudades_Departamentos_DepartamentosEntityId",
                table: "Ciudades");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientesDirecciones_Clientes_ClientesEntityId",
                table: "ClientesDirecciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Departamentos_Paises_PaisesEntityId",
                table: "Departamentos");

            migrationBuilder.DropIndex(
                name: "IX_Departamentos_PaisesEntityId",
                table: "Departamentos");

            migrationBuilder.DropIndex(
                name: "IX_ClientesDirecciones_ClientesEntityId",
                table: "ClientesDirecciones");

            migrationBuilder.DropIndex(
                name: "IX_Ciudades_DepartamentosEntityId",
                table: "Ciudades");

            migrationBuilder.DropIndex(
                name: "IX_Barrios_CiudadesEntityId",
                table: "Barrios");

            migrationBuilder.DropColumn(
                name: "PaisesEntityId",
                table: "Departamentos");

            migrationBuilder.DropColumn(
                name: "ClientesEntityId",
                table: "ClientesDirecciones");

            migrationBuilder.DropColumn(
                name: "DepartamentosEntityId",
                table: "Ciudades");

            migrationBuilder.DropColumn(
                name: "CiudadesEntityId",
                table: "Barrios");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "ClientesDirecciones",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartamentoId",
                table: "Ciudades",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CiudadId",
                table: "Barrios",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departamentos_Pais_Id",
                table: "Departamentos",
                column: "Pais_Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Departamentos_Paises_Pais_Id",
                table: "Departamentos",
                column: "Pais_Id",
                principalTable: "Paises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropForeignKey(
                name: "FK_Departamentos_Paises_Pais_Id",
                table: "Departamentos");

            migrationBuilder.DropIndex(
                name: "IX_Departamentos_Pais_Id",
                table: "Departamentos");

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

            migrationBuilder.AddColumn<int>(
                name: "PaisesEntityId",
                table: "Departamentos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClientesEntityId",
                table: "ClientesDirecciones",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartamentosEntityId",
                table: "Ciudades",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CiudadesEntityId",
                table: "Barrios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departamentos_PaisesEntityId",
                table: "Departamentos",
                column: "PaisesEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientesDirecciones_ClientesEntityId",
                table: "ClientesDirecciones",
                column: "ClientesEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Ciudades_DepartamentosEntityId",
                table: "Ciudades",
                column: "DepartamentosEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Barrios_CiudadesEntityId",
                table: "Barrios",
                column: "CiudadesEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Barrios_Ciudades_CiudadesEntityId",
                table: "Barrios",
                column: "CiudadesEntityId",
                principalTable: "Ciudades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ciudades_Departamentos_DepartamentosEntityId",
                table: "Ciudades",
                column: "DepartamentosEntityId",
                principalTable: "Departamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientesDirecciones_Clientes_ClientesEntityId",
                table: "ClientesDirecciones",
                column: "ClientesEntityId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Departamentos_Paises_PaisesEntityId",
                table: "Departamentos",
                column: "PaisesEntityId",
                principalTable: "Paises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
