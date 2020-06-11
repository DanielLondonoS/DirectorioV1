using Microsoft.EntityFrameworkCore.Migrations;

namespace DirectorioV1.Api.DataAccess.Migrations
{
    public partial class webpublish : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientesDirecciones_Barrios_BarrioId",
                table: "ClientesDirecciones");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientesDirecciones_Ciudades_CiudadId",
                table: "ClientesDirecciones");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientesDirecciones_Departamentos_DepartamentoId",
                table: "ClientesDirecciones");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientesDirecciones_Paises_PaisId",
                table: "ClientesDirecciones");

            migrationBuilder.DropIndex(
                name: "IX_ClientesDirecciones_BarrioId",
                table: "ClientesDirecciones");

            migrationBuilder.DropIndex(
                name: "IX_ClientesDirecciones_CiudadId",
                table: "ClientesDirecciones");

            migrationBuilder.DropIndex(
                name: "IX_ClientesDirecciones_DepartamentoId",
                table: "ClientesDirecciones");

            migrationBuilder.DropIndex(
                name: "IX_ClientesDirecciones_PaisId",
                table: "ClientesDirecciones");

            migrationBuilder.AlterColumn<int>(
                name: "PaisId",
                table: "ClientesDirecciones",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DepartamentoId",
                table: "ClientesDirecciones",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CiudadId",
                table: "ClientesDirecciones",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BarrioId",
                table: "ClientesDirecciones",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PaisId",
                table: "ClientesDirecciones",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "DepartamentoId",
                table: "ClientesDirecciones",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CiudadId",
                table: "ClientesDirecciones",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "BarrioId",
                table: "ClientesDirecciones",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_ClientesDirecciones_BarrioId",
                table: "ClientesDirecciones",
                column: "BarrioId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientesDirecciones_CiudadId",
                table: "ClientesDirecciones",
                column: "CiudadId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientesDirecciones_DepartamentoId",
                table: "ClientesDirecciones",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientesDirecciones_PaisId",
                table: "ClientesDirecciones",
                column: "PaisId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientesDirecciones_Barrios_BarrioId",
                table: "ClientesDirecciones",
                column: "BarrioId",
                principalTable: "Barrios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientesDirecciones_Ciudades_CiudadId",
                table: "ClientesDirecciones",
                column: "CiudadId",
                principalTable: "Ciudades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientesDirecciones_Departamentos_DepartamentoId",
                table: "ClientesDirecciones",
                column: "DepartamentoId",
                principalTable: "Departamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientesDirecciones_Paises_PaisId",
                table: "ClientesDirecciones",
                column: "PaisId",
                principalTable: "Paises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
