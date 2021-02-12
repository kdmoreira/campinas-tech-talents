namespace salao_beleza_dominio
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome
        {
            get;
            set; 
        }
        public string Telefone { get; set; }
        public string CPF { get; set; }
        public Endereco Endereco { get; set; }

        public void Incluir(string nome, string telefone, string cpf, Endereco endereco)
        {
            Nome = nome;
            Telefone = telefone;
            CPF = cpf;
            Endereco = endereco;
        }

        public void Alterar(string nome, string telefone, Endereco endereco)
        {
            Nome = string.IsNullOrEmpty(nome) ? Nome : nome;
            Telefone = string.IsNullOrEmpty(telefone) ? Telefone : telefone;
            Endereco = endereco;
        }

        public override string ToString()
        {
            return Id + ": " + Nome + ", Tel: " + Telefone + ", CPF: " + CPF;
        }
    }
}
