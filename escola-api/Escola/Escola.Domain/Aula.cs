﻿using System;
using System.Collections.Generic;

namespace Escola.Domain
{
    public class Aula
    {
        public int Id { get; set; }
        public string Disciplina { get; set; }
        public Professor Professor { get; set; }
        public Turma Turma { get; set; }

    }
}