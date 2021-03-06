using Microsoft.EntityFrameworkCore.Migrations;

namespace Escola.Data.Migrations
{
    public partial class usuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Token",
                table: "Usuario");

            migrationBuilder.AddColumn<string>(
                name: "Perfil",
                table: "Usuario",
                type: "varchar(100)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Perfil",
                table: "Usuario");

            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "Usuario",
                type: "varchar(MAX)",
                nullable: true);
        }
    }
}
