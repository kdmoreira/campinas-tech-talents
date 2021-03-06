﻿using Escola.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Data.Interface
{
    public interface ITurmaAlunoRepository : IBaseRepository<TurmaAluno>
    {
        List<TurmaAluno> SelecionarTudoCompleto();
    }
}
