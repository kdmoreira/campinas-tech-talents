using Microsoft.EntityFrameworkCore.Migrations;

namespace Escola.Data.Migrations
{
    public partial class fixAlunoCpfSize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Aluno",
                type: "varchar(11)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(10)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Aluno",
                type: "varchar(10)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(11)");
        }
    }
}
