using System;
using System.Collections.Generic;
using System.Text;

namespace salao_beleza_dominio
{
    public class Usuario : IEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Perfil { get; set; }
        public string Senha { get; set; }
    }
}
