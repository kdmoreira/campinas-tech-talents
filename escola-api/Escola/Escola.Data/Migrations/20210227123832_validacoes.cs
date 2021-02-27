using Microsoft.EntityFrameworkCore.Migrations;

namespace Escola.Data.Migrations
{
    public partial class validacoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "Aluno",
                type: "varchar(10)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "Aluno");
        }
    }
}
