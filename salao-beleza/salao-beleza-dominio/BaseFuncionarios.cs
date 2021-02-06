using System.Collections.Generic;
using System.Linq;
using System;
using static salao_beleza_dominio.Funcionario;

namespace salao_beleza_dominio
{
    public class BaseFuncionarios
    {
        public List<Funcionario> Funcionarios { get; set; }

        public BaseFuncionarios()
        {
            Funcionarios = new List<Funcionario>();
        }


        /* Por consistência, gerar número de Ids de clientes,
        serviços, agendamentos, etc, da mesma forma que foi gerado
        o número da matrícula de funcionários automaticamente? */
        public void Incluir(Funcionario func)
        {
            int matricula = 0;
            if (Funcionarios.Any())
                matricula = Funcionarios.Last().Matricula + 1;
            else
                matricula++;
            func.Matricula = matricula;
            Funcionarios.Add(func);
        }

        /* Método redundante? Já existe um na classe Funcionário, é necessário
         ter um método similar na base? Porque assim que um objeto Funcionário
        fosse modificado, ele seria alterado na base por ser uma referência, ñ?*/
        public void AlterarFuncionario(int matricula, string nomeNovo, string telefoneNovo, Endereco enderecoNovo, CargoFunc cargoNovo)
        {
            Funcionarios.Find(func => func.Matricula == matricula)
                .Alterar(nomeNovo, telefoneNovo, enderecoNovo, cargoNovo);
        }

        /* Mesma consideração acima: já existe um método parecido em Funcionario*/
        public void IncluirServicoDeFuncionario(int matricula, Servico servico)
        {
            Funcionarios.Find(func => func.Matricula == matricula)
                .IncluirServico(servico);
        }

        /* Ver acima */
        public void ExcluirServicoDeFuncionario(int matricula, int idServ)
        {
            Funcionario func = Funcionarios.Find(funcionario => funcionario.Matricula == matricula);
            if (func != null)
            {
                func.Servicos.RemoveAll(serv => serv.Id == idServ);
            }
        }

        public void ExcluirFuncionario(int matricula)
        {
            Funcionarios.RemoveAll(func => func.Matricula.Equals(matricula));
        }

        // Método para visualizar todos os funcionários
        public void Visualizar()
        {
            Console.WriteLine("Funcionários: ");
            foreach (Funcionario funcionario in Funcionarios)
            {
                Console.WriteLine(funcionario);
            }
        }
    }
}