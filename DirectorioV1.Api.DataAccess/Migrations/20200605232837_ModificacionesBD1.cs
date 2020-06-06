using Microsoft.EntityFrameworkCore.Migrations;

namespace DirectorioV1.Api.DataAccess.Migrations
{
    public partial class ModificacionesBD1 : Migration
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

            migrationBuilder.DropForeignKey(
                name: "FK_Departamentos_Paises_PaisId",
                table: "Departamentos");

            migrationBuilder.DropColumn(
                name: "PaisesId",
                table: "Departamentos");

            migrationBuilder.DropColumn(
                name: "ClientesId",
                table: "ClientesDirecciones");

            migrationBuilder.DropColumn(
                name: "DepartamentosId",
                table: "Ciudades");

            migrationBuilder.DropColumn(
                name: "CiudadesId",
                table: "Barrios");

            migrationBuilder.AlterColumn<int>(
                name: "PaisId",
                table: "Departamentos",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "ClientesDirecciones",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DepartamentoId",
                table: "Ciudades",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CiudadId",
                table: "Barrios",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Barrios_Ciudades_CiudadId",
                table: "Barrios",
                column: "CiudadId",
                principalTable: "Ciudades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ciudades_Departamentos_DepartamentoId",
                table: "Ciudades",
                column: "DepartamentoId",
                principalTable: "Departamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientesDirecciones_Clientes_ClienteId",
                table: "ClientesDirecciones",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Departamentos_Paises_PaisId",
                table: "Departamentos",
                column: "PaisId",
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
                name: "FK_Departamentos_Paises_PaisId",
                table: "Departamentos");

            migrationBuilder.AlterColumn<int>(
                name: "PaisId",
                table: "Departamentos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldMaxLength: 100);

            migrationBuilder.AddColumn<int>(
                name: "PaisesId",
                table: "Departamentos",
                type: "int",
                maxLength: 100,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "ClientesDirecciones",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ClientesId",
                table: "ClientesDirecciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "DepartamentoId",
                table: "Ciudades",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "DepartamentosId",
                table: "Ciudades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "CiudadId",
                table: "Barrios",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "CiudadesId",
                table: "Barrios",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
