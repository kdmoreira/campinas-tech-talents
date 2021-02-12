using System;
using System.IO;
using salao_beleza_dominio;

namespace salao_beleza
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // TESTANDO GESTÃO DE AGENDAMENTOS
                BaseAgendamentos agenda = new BaseAgendamentos();
                BaseFuncionarios baseFuncionarios = new BaseFuncionarios();
                BaseClientes baseClientes = new BaseClientes();
                BaseServicos baseServicos = new BaseServicos();

                Endereco end1 = new Endereco();
                end1.Incluir(1, "Rua Z", "12734-188", "Santa Maria", "São Paulo", "SP", "123", "1");
                Endereco end2 = new Endereco();
                end2.Incluir(2, "Rua Sem Fim", "14405-870", "Centro", "São Paulo", "SP", "321", "2");

                Servico serv1 = new Servico();
                serv1.Incluir("Tingimento", 40, 70);
                Servico serv2 = new Servico();
                serv2.Incluir("Corte de Barba", 15, 25);

                baseServicos.Incluir(serv1, serv2);

                Funcionario func1 = new Funcionario();
                func1.Incluir("Tânia", "3720-0000", end1, Funcionario.CargoFunc.Cabeleireiro);
                func1.IncluirServico(serv1);
                Funcionario func2 = new Funcionario();
                func2.Incluir("Marcos", "7376-9879", end1, Funcionario.CargoFunc.Barbeiro);
                func1.IncluirServico(serv2);

                baseFuncionarios.Incluir(func1, func2);

                Cliente cli1 = new Cliente();
                cli1.Incluir("Karina Moreira", "9999-9999", "3216546-76", end2);
                Cliente cli2 = new Cliente();
                cli2.Incluir("Pedro Andrade", "7799-8888", "1234567-90", end2);

                baseClientes.Incluir(cli1, cli2);

                baseClientes.Visualizar();

                Agendamento agKarina1 = new Agendamento();
                ServicoSolicitado ss1 = new ServicoSolicitado();
                ss1.Incluir(1, serv1, func1);
                agKarina1.IncluirAgendamento(cli1, ss1, new DateTime(2021, 02, 01, 12, 15, 00), agenda, "");
                agenda.Agendar(agKarina1);

                // Agendamento no horário de outro já existente, mas com outro funcionário,
                // é feito com sucesso
                Console.WriteLine("Agendando Pedro (mesmo dia e horário, mas outro funcionário):");
                ServicoSolicitado ss2 = new ServicoSolicitado();
                ss2.Incluir(3, serv2, func2);
                Agendamento agPedro1 = new Agendamento();
                agPedro1.IncluirAgendamento(cli2, ss2, new DateTime(2021, 02, 01, 12, 20, 00), agenda, "");
                agenda.Agendar(agPedro1);

                // Tentando incluir agendamento com mesmo funcionário e horário próximo
                // (Karina já tem um agendamento)
                Agendamento agPedro2 = new Agendamento();
                agPedro2.IncluirAgendamento(cli2, ss1, new DateTime(2021, 02, 01, 12, 20, 00), agenda, "");

                // Visualizando agenda
                agenda.Visualizar();

                // Editando status da agenda e do serviço
                agKarina1.EditarStatus(Agendamento.StatusAgenda.Reagendado, 
                    new DateTime(2021, 02, 01, 12, 20, 00), agenda);

                // Visualizando por data
                agenda.VisualizarData(new DateTime(2021, 02, 01, 12, 20, 00));

                
                // TESTANDO GESTÃO FINANCEIRA
                BalancoMensal bm1 = new BalancoMensal();
                bm1.NovoBalanco(1, new DateTime(2021, 1, 30, 14, 29, 00, 00));

                Caixa cx1 = new Caixa();
                cx1.AbrirCaixa(new DateTime(2021, 1, 30, 14, 30, 00, 00));

                Console.WriteLine(cx1);

                Pagamento p1 = new Pagamento();
                p1.Incluir(agKarina1, cx1);

                Console.WriteLine(p1);

                // Veja que o valor "a receber" foi atualizado para a funcionária
                Console.WriteLine(func1 + "\n");

                // Testando valores atualizados do caixa
                Console.WriteLine(cx1);

                // Após fechar o caixa passando o balanço mensal como
                //argumento, os valores do balanço são atualizados
                cx1.FecharCaixa(bm1);

                Console.WriteLine(bm1);

                // Pagar as comissões faz com que o valor "a receber"
                //de cada funcionário seja zerado
                bm1.PagarComissoes(baseFuncionarios);

                Console.WriteLine(func1 + "\n");

                // Os gastos do salão são debitados do Balanço Mensal
                Gasto g1 = new Gasto();
                g1.Incluir(20, "equipamentos");

                bm1.DebitarGasto(g1);

                // O valor do lucro mensal é atualizado
                Console.WriteLine(bm1);

            }
            catch (IOException)
            {
                Console.WriteLine("Ocorreu um erro. Tente novamente mais tarde.");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Aqui caiu a Null Reference!");
                throw;
            }
            catch (Exception)
            {
                Console.WriteLine("Deu ruim!!!");
            }
            Console.WriteLine("Tudo OK...");
            Console.ReadLine();
        }
    }
}
