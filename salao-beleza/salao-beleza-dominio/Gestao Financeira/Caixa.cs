using System.Collections.Generic;
using System;

namespace salao_beleza_dominio
{
public class Caixa
    {
        /* Criação de um CaixaDiario por dia, para controle de tudo o que
        foi pago ao salão, devendo ser incluído no BalancoMensal ao final do dia. O caixa registra o total de comissão do dia, o 
        lucro diário e todos os pagamentos feitos ao salão no dia */
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public float TotalDiario { get; set; }
        public float ComissaoDiaria { get; set; }
        public float LucroDiario { get; set; }
        public List<Pagamento> Pagamentos { get; set; }

        public void AbrirCaixa(int id, DateTime data)
        {
            Id = id;
            Pagamentos = new List<Pagamento>();
            Data = data;
        }

        public void FecharCaixa(BalancoMensal balancoMensal)
        {
            balancoMensal.TotalMensal += this.TotalDiario;
            balancoMensal.ComissaoMensal += this.ComissaoDiaria;
            balancoMensal.LucroMensal = balancoMensal.TotalMensal - balancoMensal.ComissaoMensal;
            balancoMensal.Caixas.Add(this);
        }

        public void AdicionarPagamento(Pagamento pagamento)
        {
            TotalDiario += pagamento.ValorServico;
            ComissaoDiaria += pagamento.Comissao;
            LucroDiario = TotalDiario - ComissaoDiaria;
            Pagamentos.Add(pagamento);
        }
    }
}