using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Domain
{
    public interface ICalculoNota
    {
        decimal Calcular(decimal n1, decimal n2, decimal n3);
    }
}
