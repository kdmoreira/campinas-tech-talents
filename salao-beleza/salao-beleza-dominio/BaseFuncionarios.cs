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

        // Inclusão individual de funcionários
        public void Incluir(Funcionario funcionario)
        {
            int matricula = 0;
            if (Funcionarios.Any())
                matricula = Funcionarios.Last().Matricula + 1;
            else
                matricula++;
            funcionario.Matricula = matricula;
            Funcionarios.Add(funcionario);
        }

        // Inclusão de vários funcionários
        public void Incluir(params Funcionario[] funcionarios)
        {
            foreach (Funcionario funcionario in funcionarios)
            {
                this.Incluir(funcionario);
            }
        }

        public void AlterarFuncionario(int matricula, string nomeNovo, string telefoneNovo, Endereco enderecoNovo, CargoFunc cargoNovo)
        {
            Funcionarios.Find(func => func.Matricula == matricula)
                .Alterar(nomeNovo, telefoneNovo, enderecoNovo, cargoNovo);
        }

        public void IncluirServicoDeFuncionario(int matricula, Servico servico)
        {
            Funcionarios.Find(func => func.Matricula == matricula)
                .IncluirServico(servico);
        }

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

        public void Visualizar()
        {
            Console.WriteLine("FUNCIONÁRIOS: ");
            foreach (Funcionario funcionario in Funcionarios)
            {
                Console.WriteLine(funcionario);
            }
        }
    }
}