using Microsoft.EntityFrameworkCore.Migrations;

namespace DirectorioV1.Api.DataAccess.Migrations
{
    public partial class clientesModelo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Municipio_Id",
                table: "ClientesDirecciones");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Municipio_Id",
                table: "ClientesDirecciones",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
