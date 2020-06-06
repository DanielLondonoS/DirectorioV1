using Microsoft.EntityFrameworkCore.Migrations;

namespace DirectorioV1.Api.DataAccess.Migrations
{
    public partial class ModificacionesBD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropForeignKey(
                name: "FK_Departamentos_Paises_Pais_Id",
                table: "Departamentos");

            migrationBuilder.DropIndex(
                name: "IX_Departamentos_Pais_Id",
                table: "Departamentos");

            migrationBuilder.DropIndex(
                name: "IX_ClientesDirecciones_Cliente_Id",
                table: "ClientesDirecciones");

            migrationBuilder.DropIndex(
                name: "IX_Ciudades_Departamento_Id",
                table: "Ciudades");

            migrationBuilder.DropIndex(
                name: "IX_Barrios_Ciudad_Id",
                table: "Barrios");

            migrationBuilder.DropColumn(
                name: "Pais_Id",
                table: "Departamentos");

            migrationBuilder.DropColumn(
                name: "Cliente_Id",
                table: "ClientesDirecciones");

            migrationBuilder.DropColumn(
                name: "Departamento_Id",
                table: "Ciudades");

            migrationBuilder.DropColumn(
                name: "Ciudad_Id",
                table: "Barrios");

            migrationBuilder.AddColumn<int>(
                name: "PaisId",
                table: "Departamentos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaisesId",
                table: "Departamentos",
                maxLength: 100,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "ClientesDirecciones",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClientesId",
                table: "ClientesDirecciones",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartamentoId",
                table: "Ciudades",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartamentosId",
                table: "Ciudades",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CiudadId",
                table: "Barrios",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CiudadesId",
                table: "Barrios",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Departamentos_PaisId",
                table: "Departamentos",
                column: "PaisId");

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
                name: "FK_Departamentos_Paises_PaisId",
                table: "Departamentos",
                column: "PaisId",
                principalTable: "Paises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
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
                name: "FK_Departamentos_Paises_PaisId",
                table: "Departamentos");

            migrationBuilder.DropIndex(
                name: "IX_Departamentos_PaisId",
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
                name: "PaisId",
                table: "Departamentos");

            migrationBuilder.DropColumn(
                name: "PaisesId",
                table: "Departamentos");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "ClientesDirecciones");

            migrationBuilder.DropColumn(
                name: "ClientesId",
                table: "ClientesDirecciones");

            migrationBuilder.DropColumn(
                name: "DepartamentoId",
                table: "Ciudades");

            migrationBuilder.DropColumn(
                name: "DepartamentosId",
                table: "Ciudades");

            migrationBuilder.DropColumn(
                name: "CiudadId",
                table: "Barrios");

            migrationBuilder.DropColumn(
                name: "CiudadesId",
                table: "Barrios");

            migrationBuilder.AddColumn<int>(
                name: "Pais_Id",
                table: "Departamentos",
                type: "int",
                maxLength: 100,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Cliente_Id",
                table: "ClientesDirecciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Departamento_Id",
                table: "Ciudades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Ciudad_Id",
                table: "Barrios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Departamentos_Pais_Id",
                table: "Departamentos",
                column: "Pais_Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Departamentos_Paises_Pais_Id",
                table: "Departamentos",
                column: "Pais_Id",
                principalTable: "Paises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
