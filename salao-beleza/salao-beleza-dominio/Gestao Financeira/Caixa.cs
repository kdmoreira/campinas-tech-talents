using System.Collections.Generic;
using System.Linq;
using System;
using System.Globalization;

namespace salao_beleza_dominio
{
    public class Caixa : IEntity
    {
        /* Criação de um Caixa por dia, para controle de tudo o que
        foi pago ao salão, devendo ser incluído no BalancoMensal ao final do dia. O caixa registra o total de comissão do dia, o 
        lucro diário e todos os pagamentos feitos ao salão no dia */
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public float TotalDiario { get; set; }
        public float ComissaoDiaria { get; set; }
        public float LucroDiario { get; set; }
        public List<Pagamento> Pagamentos { get; set; }
        public BalancoMensal BalancoMensal { get; set; }

        /* public void AbrirCaixa(DateTime data)
        {
            Pagamentos = new List<Pagamento>();
            Data = data;
        }

        // O id do pagamento é gerado assim que ele é adicionado ao caixa,
        // o valor do pagamento passa a compor o total, a comissão e o lucro
        public void AdicionarPagamento(Pagamento pagamento)
        {
            int id = 0;
            if (this.Pagamentos.Any())
                id = Pagamentos.Last().Id + 1;
            else
                id++;
            pagamento.Id = id;
            Pagamentos.Add(pagamento);
            TotalDiario += pagamento.ValorServico;
            ComissaoDiaria += pagamento.Comissao;
            LucroDiario = TotalDiario - ComissaoDiaria;
        }

        // Ao ser fechado, os valores do Caixa passam a integrar o BalancoMensal
        public void FecharCaixa(BalancoMensal balancoMensal)
        {
            int id = 0;
            if (balancoMensal.Caixas.Any())
                id = balancoMensal.Caixas.Last().Id + 1;
            else
                id++;
            this.Id = id;
            balancoMensal.Caixas.Add(this);
            balancoMensal.TotalMensal += this.TotalDiario;
            balancoMensal.ComissaoMensal += this.ComissaoDiaria;
            balancoMensal.LucroMensal = balancoMensal.TotalMensal - balancoMensal.ComissaoMensal;
        }

        public override string ToString()
        {
            return "Caixa: " + Data + "\n" + "Total diário: " + TotalDiario +
                "\nComissão diária: " + ComissaoDiaria + "\nLucro diário: " +
                LucroDiario + "\n";
        } */
    }
}