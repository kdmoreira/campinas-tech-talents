using Escola.Domain;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using Escola.Data.Interface;
using Microsoft.EntityFrameworkCore;

namespace Escola.Data.Repository
{
    public class AlunoRepository : BaseRepository<Aluno>, IAlunoRepository
    {
        private readonly Guid _guid;
        public AlunoRepository(Contexto contexto) : base(contexto)
        {
            _guid = Guid.NewGuid();
        }

        // Incluindo ordenação alfabética de nome
        public List<Aluno> SelecionarTudoCompleto()
        {
            return _contexto.Aluno
                .Include(x => x.TurmaAluno).OrderBy(x => x.Nome)
                .ToList();
        }
        public List<Aluno> SelecionarNome(string nome)
        {
            return _contexto.Aluno.Include(x => x.Nome == nome).ToList();
        }
        public List<Aluno> SelecionarEmail(string email)
        {
            return _contexto.Aluno
                .Include(x => x.Nome.Contains(email))
                .ToList();
        }

        public string IncluirAluno(Aluno aluno)
        {
            if (PermiteCadastro(aluno))
            {
                base.Incluir(aluno);
                return "Cadastro feito com sucesso!";
            }
            return "Aluno já cadastrado.";
        }

        public string AlterarAluno(Aluno aluno)
        {
            if (PermiteTurma(aluno))
            {
                base.Alterar(aluno);
                return "Alteração realizada.";
            }
            return "Aluno já frequenta um curso.";
        }

        public bool PermiteCadastro(Aluno aluno)
        {
            Aluno alunoQuery = _contexto.Aluno.FirstOrDefault(x => x.Cpf == aluno.Cpf);
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
