namespace salao_beleza_dominio
{
    public class Pagamento
    {
        /* Id para identificar a transação, com agendamento ao qual se refere,
        usado para buscar o funcionário prestador do serviço para que seja creditada a sua comissão (criei a propriedade ComissaoAReceber, na classe Funcionario) */
        public int Id { get; set; }
        public Agendamento AgendamentoRealizado { get; set; }
        public float ValorServico { get; set; }
        public float Comissao { get; set; }

        public void Incluir(int id, Agendamento agendamentoRealizado, Caixa caixa)
        {
            Id = id;
            AgendamentoRealizado = agendamentoRealizado;
            ValorServico = agendamentoRealizado.ServicoSolicitado.Servico.Preco;
            Comissao = ValorServico * (float)0.3;
            agendamentoRealizado.ServicoSolicitado.Funcionario.ComissaoAReceber += Comissao;
            caixa.AdicionarPagamento(this);
        }

        public override string ToString()
        {
            return "Pagamento " + Id + ": ref. agendamento " + AgendamentoRealizado.Id + ", valor: " + ValorServico + ", comissão: " + Comissao;
        }
    }
}