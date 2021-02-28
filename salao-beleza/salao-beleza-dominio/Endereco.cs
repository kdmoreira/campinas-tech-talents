namespace salao_beleza_dominio
{
    public class Endereco : IEntity
    {
        public int Id { get; set; }
        public string Logradouro { get; set; }
        public string CEP { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }

        public void Incluir(int id, string logradouro, string cep, string bairro, string cidade,
            string uf, string numero, string compl)
        {
            Id = id;
            Logradouro = logradouro;
            CEP = cep;
            Bairro = bairro;
            Cidade = cidade;
            UF = uf;
            Numero = numero;
            Complemento = compl;
        }

        public void Alterar(string logradouro, string cep, string bairro, string cidade,
            string uf, string numero, string compl)
        {
            Logradouro = logradouro;
            CEP = cep;
            Bairro = bairro;
            Cidade = cidade;
            UF = uf;
            Numero = numero;
            Complemento = compl;
        }
    }
}