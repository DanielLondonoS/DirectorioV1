using Microsoft.EntityFrameworkCore.Migrations;

namespace DirectorioV1.Api.DataAccess.Migrations
{
    public partial class Migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ciudad_Id",
                table: "Municipios");

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
                name: "Municipio_Id",
                table: "Barrios");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Ciudad_Id",
                table: "Municipios",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Pais_Id",
                table: "Departamentos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Cliente_Id",
                table: "ClientesDirecciones",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Departamento_Id",
                table: "Ciudades",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Municipio_Id",
                table: "Barrios",
                nullable: true);
        }
    }
}
