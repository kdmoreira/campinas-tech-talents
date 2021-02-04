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
                /* TESTANDO GESTÃO DE AGENDAMENTOS */
                BaseAgendamentos agenda = new BaseAgendamentos();
                BaseFuncionarios baseFuncionarios = new BaseFuncionarios();

                Endereco e2 = new Endereco();
                e2.Incluir(2, "Rua Z", "1234-1", "Santa Maria", "São Paulo", "SP", "123", "1");

                Funcionario f5 = new Funcionario();
                f5.Incluir("Tânia", "3720-0000", e2, Funcionario.CargoFunc.Cabelereira);

                baseFuncionarios.Incluir(f5);

                Cliente c3 = new Cliente();
                c3.Incluir(3, "Karina Moreira", "9999-9999", "321654");

                Servico s5 = new Servico();
                s5.Incluir(5, "Tingimento", 40, 70);

                Agendamento agKarina = new Agendamento();
                ServicoSolicitado ss1 = new ServicoSolicitado();
                ss1.Incluir(1, s5, f5, new DateTime(2021, 02, 03, 12, 15, 00));
                agKarina.IncluirAgendamento(1, c3, ss1, new DateTime(2021, 02, 01, 12, 15, 00), agenda, "");

                agenda.Agendar(agKarina);

                agenda.VisualizarData(new DateTime(2021, 01, 01));

                /* Tentando incluir agendamento em horário incompatível */
                Agendamento agKarina2 = new Agendamento();
                ServicoSolicitado ss2 = new ServicoSolicitado();
                ss2.Incluir(2, s5, f5, new DateTime(2021, 02, 03, 12, 30, 00));
                agKarina2.IncluirAgendamento(2, c3, ss2, new DateTime(2021, 02, 01, 12, 15, 00), agenda, "");

                /* Visualizando agenda */
                Console.WriteLine("Agendamentos: ");
                foreach (Agendamento ag in agenda.Agendamentos)
                {
                    Console.WriteLine(ag);
                }

                /* Editando status da agenda e do serviço */
                agKarina.EditarStatus(Agendamento.StatusAgenda.Reagendado, new DateTime(2021, 02, 03, 12, 30, 00));
                ss1.EditarStatus(ServicoSolicitado.StatusServico.Realizado);

                Console.WriteLine("Agendamentos: ");
                foreach (Agendamento ag in agenda.Agendamentos)
                {
                    Console.WriteLine(ag);
                }

                /* TESTANDO GESTÃO FINANCEIRA */
                BalancoMensal bm1 = new BalancoMensal();
                bm1.NovoBalanco(1, new DateTime(2021, 1, 30, 14, 29, 00, 00));

                Caixa cx1 = new Caixa();
                cx1.AbrirCaixa(1, new DateTime(2021, 1, 30, 14, 30, 00, 00));

                Pagamento p1 = new Pagamento();
                p1.Incluir(1, agKarina, cx1);

                Console.WriteLine(p1);

                /* Veja que o valor "a receber" foi atualizado
                para a funcionária */
                Console.WriteLine(f5);

                /* Testando valores atualizados do caixa */
                Console.WriteLine("Total diário: " + cx1.TotalDiario);
                Console.WriteLine("Comissão diária: " + cx1.ComissaoDiaria);
                Console.WriteLine("Lucro diário: " + cx1.LucroDiario);

                /* Após fechar o caixa passando o balanço mensal como
                argumento, os valores do balanço são atualizados */

                cx1.FecharCaixa(bm1);

                Console.WriteLine("Total mensal: " + bm1.TotalMensal);
                Console.WriteLine("Comissão mensal: " + bm1.ComissaoMensal);
                Console.WriteLine("Lucro mensal: " + bm1.LucroMensal);

                /* Pagar as comissões faz com que o valor "a receber"
                de cada funcionário seja zerado */
                bm1.PagarComissoes(baseFuncionarios);

                Console.WriteLine(f5);
            }
            catch (IOException)
            {
                Console.WriteLine("Ocorreu um erro. Tente novamente mais tarde. ");
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
            Console.WriteLine("Continuando...");
            Console.ReadLine();
        }
    }
}
