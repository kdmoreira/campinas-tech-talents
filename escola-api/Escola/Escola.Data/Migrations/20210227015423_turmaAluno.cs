using Microsoft.EntityFrameworkCore.Migrations;

namespace Escola.Data.Migrations
{
    public partial class turmaAluno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aluno_Turma_TurmaID",
                table: "Aluno");

            migrationBuilder.DropForeignKey(
                name: "FK_Aula_Professor_ProfessorID",
                table: "Aula");

            migrationBuilder.DropForeignKey(
                name: "FK_Aula_Turma_TurmaID",
                table: "Aula");

            migrationBuilder.DropForeignKey(
                name: "FK_Professor_Turma_TurmaId",
                table: "Professor");

            migrationBuilder.DropIndex(
                name: "IX_Professor_TurmaId",
                table: "Professor");

            migrationBuilder.DropIndex(
                name: "IX_Aluno_TurmaID",
                table: "Aluno");

            migrationBuilder.DropColumn(
                name: "Sala",
                table: "Turma");

            migrationBuilder.DropColumn(
                name: "TurmaId",
                table: "Professor");

            migrationBuilder.RenameColumn(
                name: "AnoEscolar",
                table: "Turma",
                newName: "Edicao");

            migrationBuilder.RenameColumn(
                name: "TurmaID",
                table: "Aula",
                newName: "TurmaId");

            migrationBuilder.RenameColumn(
                name: "ProfessorID",
                table: "Aula",
                newName: "ProfessorId");

            migrationBuilder.RenameIndex(
                name: "IX_Aula_TurmaID",
                table: "Aula",
                newName: "IX_Aula_TurmaId");

            migrationBuilder.RenameIndex(
                name: "IX_Aula_ProfessorID",
                table: "Aula",
                newName: "IX_Aula_ProfessorId");

            migrationBuilder.AddColumn<string>(
                name: "Curso",
                table: "Turma",
                type: "varchar(60)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "TurmaId",
                table: "Aula",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProfessorId",
                table: "Aula",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "TurmaAluno",
                columns: table => new
                {
                    IdAluno = table.Column<int>(type: "int", nullable: false),
                    IdTurma = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TurmaAluno", x => new { x.IdAluno, x.IdTurma });
                    table.ForeignKey(
                        name: "FK_TurmaAluno_Aluno_IdAluno",
                        column: x => x.IdAluno,
                        principalTable: "Aluno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TurmaAluno_Turma_IdTurma",
                        column: x => x.IdTurma,
                        principalTable: "Turma",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TurmaProfessor",
                columns: table => new
                {
                    IdProfessor = table.Column<int>(type: "int", nullable: false),
                    IdTurma = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TurmaProfessor", x => new { x.IdProfessor, x.IdTurma });
                    table.ForeignKey(
                        name: "FK_TurmaProfessor_Professor_IdProfessor",
                        column: x => x.IdProfessor,
                        principalTable: "Professor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TurmaProfessor_Turma_IdTurma",
                        column: x => x.IdTurma,
                        principalTable: "Turma",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TurmaAluno_IdTurma",
                table: "TurmaAluno",
                column: "IdTurma");

            migrationBuilder.CreateIndex(
                name: "IX_TurmaProfessor_IdTurma",
                table: "TurmaProfessor",
                column: "IdTurma");

            migrationBuilder.AddForeignKey(
                name: "FK_Aula_Professor_ProfessorId",
                table: "Aula",
                column: "ProfessorId",
                principalTable: "Professor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Aula_Turma_TurmaId",
                table: "Aula",
                column: "TurmaId",
                principalTable: "Turma",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aula_Professor_ProfessorId",
                table: "Aula");

            migrationBuilder.DropForeignKey(
                name: "FK_Aula_Turma_TurmaId",
                table: "Aula");

            migrationBuilder.DropTable(
                name: "TurmaAluno");

            migrationBuilder.DropTable(
                name: "TurmaProfessor");

            migrationBuilder.DropColumn(
                name: "Curso",
                table: "Turma");

            migrationBuilder.RenameColumn(
                name: "Edicao",
                table: "Turma",
                newName: "AnoEscolar");

            migrationBuilder.RenameColumn(
                name: "TurmaId",
                table: "Aula",
                newName: "TurmaID");

            migrationBuilder.RenameColumn(
                name: "ProfessorId",
                table: "Aula",
                newName: "ProfessorID");

            migrationBuilder.RenameIndex(
                name: "IX_Aula_TurmaId",
                table: "Aula",
                newName: "IX_Aula_TurmaID");

            migrationBuilder.RenameIndex(
                name: "IX_Aula_ProfessorId",
                table: "Aula",
                newName: "IX_Aula_ProfessorID");

            migrationBuilder.AddColumn<string>(
                name: "Sala",
                table: "Turma",
                type: "varchar(10)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TurmaId",
                table: "Professor",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TurmaID",
                table: "Aula",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProfessorID",
                table: "Aula",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Professor_TurmaId",
                table: "Professor",
                column: "TurmaId");

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_TurmaID",
                table: "Aluno",
                column: "TurmaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Aluno_Turma_TurmaID",
                table: "Aluno",
                column: "TurmaID",
                principalTable: "Turma",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Aula_Professor_ProfessorID",
                table: "Aula",
                column: "ProfessorID",
                principalTable: "Professor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Aula_Turma_TurmaID",
                table: "Aula",
                column: "TurmaID",
                principalTable: "Turma",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Professor_Turma_TurmaId",
                table: "Professor",
                column: "TurmaId",
                principalTable: "Turma",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
