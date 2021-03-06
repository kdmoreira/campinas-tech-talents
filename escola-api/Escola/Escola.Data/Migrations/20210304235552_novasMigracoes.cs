using Microsoft.EntityFrameworkCore.Migrations;

namespace Escola.Data.Migrations
{
    public partial class novasMigracoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "TurmaProfessor",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true,
                oldType: "int");
            //.OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "TurmaAluno",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true,
                oldType: "int");
                //.OldAnnotation("SqlServer:Identity", "1, 1");

            /* POSSÍVEIS EDIÇÕES PARA O ERRO: 

            migrationBuilder.AddColumn<int>(
                name: "Id2",
                table: "TurmaProfessor",
                type: "int",
                nullable: true);

            migrationBuilder.Sql("update TurmaProfessor set Id = Id2");

            migrationBuilder.AddColumn<int>(
                name: "Id2",
                table: "TurmaAluno",
                type: "int",
                nullable: true);

            migrationBuilder.Sql("update TurmaAluno set Id = Id2");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "TurmaProfessor");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "TurmaAluno");

            migrationBuilder.RenameColumn(
                name: "Id2",
                table: "TurmaProfessor",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Id2",
                table: "TurmaAluno",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "TurmaProfessor",
                nullable: false,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "TurmaAluno",
                nullable: false,
                oldNullable: true);
            */

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Senha = table.Column<string>(type: "varchar(20)", nullable: false),
                    Token = table.Column<string>(type: "varchar(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "TurmaProfessor",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
                //.Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "TurmaAluno",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
                //.Annotation("SqlServer:Identity", "1, 1");
        }
    }
}
