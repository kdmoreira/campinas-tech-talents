using System.Collections.Generic;
using System.Linq;
using System;

namespace salao_beleza_dominio
{
    public class BaseClientes
    {
        public List<Cliente> Clientes { get; set; }

        public BaseClientes()
        {
            Clientes = new List<Cliente>();
        }

        // Inclusão individual
        public void Incluir(Cliente cliente)
        {
            int id = 0;
            if (Clientes.Any())
                id = Clientes.Last().Id + 1;
            else
                id++;
            cliente.Id = id;
            Clientes.Add(cliente);
        }

        // Inclusão de vários clientes
        public void Incluir(params Cliente[] clientes)
        {
            foreach (Cliente cliente in clientes)
            {
                this.Incluir(cliente);
            }
        }

        public void AlterarCliente(int id, string nomeNovo, string telefoneNovo, 
            Endereco enderecoNovo)
        {
            Cliente cliente = Clientes.FirstOrDefault(cli => cli.Id == id);
            if (cliente != null)
            {
                cliente.Alterar(nomeNovo, telefoneNovo, enderecoNovo);
            }
        }

        public void ExcluirUmCliente(int id)
        {
            Clientes.RemoveAll(cli => cli.Id == id);
        }

        public void Visualizar()
        {
            Console.WriteLine("CLIENTES:");
            foreach (Cliente cliente in Clientes)
            {
                Console.WriteLine(cliente);
            }
            Console.WriteLine();
        }
    }
}