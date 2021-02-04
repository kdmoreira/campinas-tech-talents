using System.Collections.Generic;
using System;

namespace salao_beleza_dominio
{
public class BalancoMensal
    {
        /*Criação de um BalancoMensal no início mês, no qual deverão
        ser incluídos os caixas (classe Caixa) */
        public int Id { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
        public float TotalMensal { get; set; }
        public float ComissaoMensal { get; set; }
        public float LucroMensal { get; set; }
        public List<Caixa> Caixas { get; set; }
        public Dictionary<Funcionario, float> ComissoesPagas { get; set; }

        public void NovoBalanco(int id, DateTime data)
        {
            Id = Id;
            Mes = data.Month;
            Ano = data.Year;
            Caixas = new List<Caixa>();
            ComissoesPagas = new Dictionary<Funcionario, float>();
        }

        /* O método abaixo equivale a pagar todas as comissões de uma
        vez, zerando a propriedade ComissaoAReceber de cada funcionário
        do salão, e registrando no dicionário ComissoesPagas o quanto
        cada funcionário recebeu naquele mês */
        public void PagarComissoes(BaseFuncionarios baseFuncionarios)
        {
            foreach (Funcionario funcionario in baseFuncionarios.Funcionarios)
            {
                ComissoesPagas.Add(funcionario, funcionario.ComissaoAReceber);
                funcionario.ComissaoAReceber = 0;
            }
        }
    }
}