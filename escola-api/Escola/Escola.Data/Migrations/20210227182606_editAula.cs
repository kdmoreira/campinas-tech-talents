using Microsoft.EntityFrameworkCore.Migrations;

namespace Escola.Data.Migrations
{
    public partial class editAula : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Disciplina",
                table: "Aula");

            migrationBuilder.AddColumn<string>(
                name: "Assunto",
                table: "Aula",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Assunto",
                table: "Aula");

            migrationBuilder.AddColumn<string>(
                name: "Disciplina",
                table: "Aula",
                type: "varchar(30)",
                nullable: false,
                defaultValue: "");
        }
    }
}
