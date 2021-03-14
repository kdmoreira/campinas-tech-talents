using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace salao_beleza_data.Migrations
{
    public partial class bancoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BalancoMensal",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mes = table.Column<int>(type: "int", nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    TotalMensal = table.Column<double>(type: "float", nullable: false),
                    ComissaoMensal = table.Column<double>(type: "float", nullable: false),
                    LucroMensal = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BalancoMensal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(150)", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(15)", nullable: false),
                    Cpf = table.Column<string>(type: "varchar(11)", nullable: false),
                    Endereco = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(150)", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(15)", nullable: false),
                    Endereco = table.Column<string>(type: "varchar(200)", nullable: false),
                    Cpf = table.Column<string>(type: "varchar(11)", nullable: false),
                    Cargo = table.Column<int>(type: "int", nullable: false),
                    HorarioEntrada = table.Column<DateTime>(type: "datetime", nullable: false),
                    HorarioSaida = table.Column<DateTime>(type: "datetime", nullable: false),
                    ComissaoAReceber = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Servico",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(30)", nullable: false),
                    MinutosParaExecucao = table.Column<int>(type: "int", nullable: false),
                    Preco = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servico", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Caixa",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime", nullable: false),
                    TotalDiario = table.Column<double>(type: "float", nullable: false),
                    ComissaoDiaria = table.Column<string>(type: "varchar(15)", nullable: false),
                    LucroDiario = table.Column<string>(type: "varchar(15)", nullable: false),
                    BalancoMensalId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caixa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Caixa_BalancoMensal_BalancoMensalId",
                        column: x => x.BalancoMensalId,
                        principalTable: "BalancoMensal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Gasto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<double>(type: "float", nullable: false),
                    Motivo = table.Column<string>(type: "varchar(50)", nullable: false),
                    BalancoMensalId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gasto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gasto_BalancoMensal_BalancoMensalId",
                        column: x => x.BalancoMensalId,
                        principalTable: "BalancoMensal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comissao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FuncionarioId = table.Column<int>(nullable: true),
                    Valor = table.Column<double>(type: "float", nullable: false),
                    BalancoMensalId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comissao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comissao_BalancoMensal_BalancoMensalId",
                        column: x => x.BalancoMensalId,
                        principalTable: "BalancoMensal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comissao_Funcionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FuncionarioServico",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FuncionarioId = table.Column<int>(nullable: false),
                    ServicoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuncionarioServico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FuncionarioServico_Funcionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FuncionarioServico_Servico_ServicoId",
                        column: x => x.ServicoId,
                        principalTable: "Servico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServicoSolicitado",
                columns: table => new
                {
                    FuncionarioId = table.Column<int>(nullable: false),
                    ServicoId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicoSolicitado", x => new { x.FuncionarioId, x.ServicoId });
                    table.ForeignKey(
                        name: "FK_ServicoSolicitado_Funcionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServicoSolicitado_Servico_ServicoId",
                        column: x => x.ServicoId,
                        principalTable: "Servico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pagamento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValorServico = table.Column<double>(type: "float", nullable: false),
                    Comissao = table.Column<double>(type: "float", nullable: false),
                    CaixaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pagamento_Caixa_CaixaId",
                        column: x => x.CaixaId,
                        principalTable: "Caixa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Agendamento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    ClienteId = table.Column<int>(nullable: true),
                    ServicoSolicitadoFuncionarioId = table.Column<int>(nullable: true),
                    ServicoSolicitadoServicoId = table.Column<int>(nullable: true),
                    DataAgendamento = table.Column<DateTime>(type: "datetime", nullable: false),
                    Anotacao = table.Column<string>(type: "varchar(100)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agendamento_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Agendamento_Pagamento_Id",
                        column: x => x.Id,
                        principalTable: "Pagamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agendamento_ServicoSolicitado_ServicoSolicitadoFuncionarioId_ServicoSolicitadoServicoId",
                        columns: x => new { x.ServicoSolicitadoFuncionarioId, x.ServicoSolicitadoServicoId },
                        principalTable: "ServicoSolicitado",
                        principalColumns: new[] { "FuncionarioId", "ServicoId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_ClienteId",
                table: "Agendamento",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_ServicoSolicitadoFuncionarioId_ServicoSolicitadoServicoId",
                table: "Agendamento",
                columns: new[] { "ServicoSolicitadoFuncionarioId", "ServicoSolicitadoServicoId" });

            migrationBuilder.CreateIndex(
                name: "IX_Caixa_BalancoMensalId",
                table: "Caixa",
                column: "BalancoMensalId");

            migrationBuilder.CreateIndex(
                name: "IX_Comissao_BalancoMensalId",
                table: "Comissao",
                column: "BalancoMensalId");

            migrationBuilder.CreateIndex(
                name: "IX_Comissao_FuncionarioId",
                table: "Comissao",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_FuncionarioServico_FuncionarioId",
                table: "FuncionarioServico",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_FuncionarioServico_ServicoId",
                table: "FuncionarioServico",
                column: "ServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Gasto_BalancoMensalId",
                table: "Gasto",
                column: "BalancoMensalId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamento_CaixaId",
                table: "Pagamento",
                column: "CaixaId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicoSolicitado_ServicoId",
                table: "ServicoSolicitado",
                column: "ServicoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agendamento");

            migrationBuilder.DropTable(
                name: "Comissao");

            migrationBuilder.DropTable(
                name: "FuncionarioServico");

            migrationBuilder.DropTable(
                name: "Gasto");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Pagamento");

            migrationBuilder.DropTable(
                name: "ServicoSolicitado");

            migrationBuilder.DropTable(
                name: "Caixa");

            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "Servico");

            migrationBuilder.DropTable(
                name: "BalancoMensal");
        }
    }
}
