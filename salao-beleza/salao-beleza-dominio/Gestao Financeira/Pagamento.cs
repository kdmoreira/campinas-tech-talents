namespace salao_beleza_dominio
{
    public class Pagamento : IEntity
    {
        /* Pagamento tem um Id para identificar a transação, com agendamento ao qual se refere,
        usado para buscar o funcionário prestador do serviço para que seja creditada a sua comissão
        (criei a propriedade ComissaoAReceber, na classe Funcionario) */
        public int Id { get; set; }
        public Agendamento AgendamentoRealizado { get; set; }
        public float ValorServico { get; set; }
        public float Comissao { get; set; }

        /* No momento da inclusão, o método busca o valor do servico pelo
         agendamento referente ao pagamento, calcula a comissão e atualiza
        a propriedade "ComissãoAReceber", em Funcionario */
        public void Incluir(Agendamento agendamentoRealizado, Caixa caixa)
        {
            AgendamentoRealizado = agendamentoRealizado;
            ValorServico = agendamentoRealizado.ServicoSolicitado.Servico.Preco;
            Comissao = ValorServico * (float)0.3;
            agendamentoRealizado.ServicoSolicitado.Funcionario.ComissaoAReceber += Comissao;
            caixa.AdicionarPagamento(this);
        }

        public override string ToString()
        {
            return "Pagamento: ref. agendamento " + AgendamentoRealizado.Id +
                ", valor: " + ValorServico + ", comissão: " + Comissao + "\n";
        }
    }
}