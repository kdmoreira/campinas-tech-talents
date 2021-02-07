using System;
using System.Collections.Generic;
using System.Text;

namespace salao_beleza_dominio
{
    public class Gasto
    {
        public int Id { get; set; }
        public float Valor { get; set; }
        public string Motivo { get; set; }

        public void Incluir(float valor, string motivo)
        {
            Valor = valor;
            Motivo = motivo;
        }

        public override string ToString()
        {
            return Motivo + ": " + Valor + "\n";
        }
    }
}
