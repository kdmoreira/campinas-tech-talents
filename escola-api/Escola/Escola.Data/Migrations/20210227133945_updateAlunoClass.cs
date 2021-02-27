using Microsoft.EntityFrameworkCore.Migrations;

namespace Escola.Data.Migrations
{
    public partial class updateAlunoClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TurmaID",
                table: "Aluno");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TurmaID",
                table: "Aluno",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
