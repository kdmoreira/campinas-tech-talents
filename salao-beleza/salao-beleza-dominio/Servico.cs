namespace salao_beleza_dominio
{
    public class Servico
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int MinutosParaExecucao { get; set; }
        public float Preco { get; set; }

        public void Incluir(int id, string nome, int minutosParaExecucao, float preco)
        {
            //Agendamento a = new Agendamento();
            Id = id;
            Nome = nome;
            MinutosParaExecucao = minutosParaExecucao;
            Preco = preco;
        }

        public void Alterar(string nome, int minutosParaExecucao, float preco)
        {
            Nome = nome;
            MinutosParaExecucao = minutosParaExecucao;
            Preco = preco;
        }

        public override string ToString()
        {
            return Nome + " (" + MinutosParaExecucao + "min)" + ", preço: " + Preco;
        }
    }
}