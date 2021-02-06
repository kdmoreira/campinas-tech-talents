using System.Collections.Generic;
using System.Linq;
using System;

namespace salao_beleza_dominio
{
    public class MinhaBaseClientes
    {
        public List<Cliente> Clientes { get; set; }

        public MinhaBaseClientes()
        {
            Clientes = new List<Cliente>();
        }

        public void Incluir(Cliente cliente)
        {
            Clientes.Add(cliente);
        }

        /* A diferença do método Incluir é que este adiciona dois,
         em vez de um, mas haveria uma forma de adicionar N funcionários
        como se fosse usar um "spread operator" que aceita todos os argumentos
        passados para o parâmetro? */
        public void IncluirLista(Cliente cliente1, Cliente cliente2)
        {
            List<Cliente> lst = new List<Cliente> { cliente1, cliente2 };
            Clientes.AddRange(lst);
        }

        /* Mesma consideração feita sobre métodos da BaseFuncionários (já
         * existe método de alteração na classe Cliente */
        public void AlterarUmCliente(int id, string nomeNovo, string telefoneNovo)
        {
            Cliente cliente = Clientes.FirstOrDefault(cli => cli.Id == id);
            if (cliente != null)
            {
                cliente.Alterar(nomeNovo, telefoneNovo);
            }
        }

        public void ExcluirUmCliente(int id)
        {
            Clientes.RemoveAll(cli => cli.Id == id);
        }

        /* Método para visualizar todos os clientes */
        public void Visualizar()
        {
            Console.WriteLine("Clientes:");
            foreach (Cliente cliente in Clientes)
            {
                Console.WriteLine(cliente);
            }
            Console.WriteLine();
        }
    }
}