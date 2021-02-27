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
            DadosIniciais();
        }

        // Inclusão individual de funcionários
        public void Incluir(Funcionario funcionario)
        {
            int matricula = 0;
            if (Funcionarios.Any())
                matricula = Funcionarios.Last().Id + 1;
            else
                matricula++;
            funcionario.Id = matricula;
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

        public void AlterarFuncionario(int id, string nomeNovo, string telefoneNovo, Endereco enderecoNovo, CargoFunc cargoNovo)
        {
            Funcionarios.Find(func => func.Id == id)
                .Alterar(nomeNovo, telefoneNovo, enderecoNovo, cargoNovo);
        }

        public void IncluirServicoDeFuncionario(int id, Servico servico)
        {
            Funcionarios.Find(func => func.Id == id)
                .IncluirServico(servico);
        }

        public void ExcluirServicoDeFuncionario(int id, int idServ)
        {
            Funcionario func = Funcionarios.Find(funcionario => funcionario.Id == id);
            if (func != null)
            {
                func.Servicos.RemoveAll(serv => serv.Id == idServ);
            }
        }

        public void ExcluirFuncionario(int matricula)
        {
            Funcionarios.RemoveAll(func => func.Id.Equals(matricula));
        }

        public void Visualizar()
        {
            Console.WriteLine("FUNCIONÁRIOS: ");
            foreach (Funcionario funcionario in Funcionarios)
            {
                Console.WriteLine(funcionario);
            }
        }

        public Funcionario FuncionarioPorMatricula(int id)
        {
            return Funcionarios.FirstOrDefault(x => x.Id == id);
        }

        public void DadosIniciais()
        {
            Endereco end1 = new Endereco();
            end1.Incluir(2, "Rua Z", "1234-1",
                "Santa Maria", "São Paulo", "SP", "123", "1");

            Servico serv1 = new Servico();
            serv1.Incluir("Tingimento", 40, 70);
            Servico serv2 = new Servico();
            serv2.Incluir("Corte de Barba", 15, 25);

            Funcionario func1 = new Funcionario();
            func1.Incluir("Tânia", "3720-0000", end1, Funcionario.CargoFunc.Cabeleireiro);
            func1.IncluirServico(serv1);
            Funcionario func2 = new Funcionario();
            func2.Incluir("Marcos", "7376-9879", end1, Funcionario.CargoFunc.Barbeiro);
            func2.IncluirServico(serv2);

            this.Incluir(func1, func2);
        }
    }
}