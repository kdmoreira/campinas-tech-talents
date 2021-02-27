using Escola.Domain;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Data.Repository
{
    public class AlunoRepository
    {
        private readonly Contexto contexto;
        public AlunoRepository()
        {
            contexto = new Contexto();
        }
        public string Incluir(Aluno aluno)
        {
            if (PermiteCadastro(aluno))
            {
                contexto.Aluno.Add(aluno);
                contexto.SaveChanges();
                return "Cadastro feito com sucesso!";
            }
            return "Aluno já cadastrado.";
        }

        public Aluno Selecionar(int id)
        {
            return contexto.Aluno.FirstOrDefault(x => x.Id == id);
        }

        public List<Aluno> SelecionarTudo()
        {
            return contexto.Aluno.ToList();
        }

        public string Alterar(Aluno aluno)
        {
            if (PermiteTurma(aluno))
            {
                contexto.Aluno.Update(aluno);
                contexto.SaveChanges();
                return "Alteração realizada.";
            }
            return "Aluno já frequenta um curso.";
        }

        public void Excluir(int id)
        {
            var aluno = Selecionar(id);
            contexto.Aluno.Remove(aluno);
            contexto.SaveChanges();
        }

        public bool PermiteCadastro(Aluno aluno)
        {
            Aluno alunoQuery = contexto.Aluno.FirstOrDefault(x => x.Cpf == aluno.Cpf);
            if (alunoQuery == null)
            {
                return true;
            }
            return false;
        }

        public bool PermiteTurma(Aluno aluno)
        {
            if (aluno.Ativo)
            {
                return false;
            }
            return true;
        }
    }
}
