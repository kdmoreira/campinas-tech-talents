using System;

namespace salao_beleza_dominio
{
public class Turno
    {
        public DateTime EntradaManha
        {
            get { return Convert.ToDateTime("08:00"); }
        }

        public DateTime SaidaManha
        {
            get { return Convert.ToDateTime("17:00"); }
        }

        public DateTime EntradaTarde
        {
            get { return Convert.ToDateTime("11:00"); }
        }

        public DateTime SaidaTarde
        {
            get { return Convert.ToDateTime("20:00"); }
        }

        public DateTime EntradaSabado
        {
            get { return Convert.ToDateTime("08:00"); }
        }

        public DateTime SaidaSabado
        {
            get { return Convert.ToDateTime("18:00"); }
        }

        public TurnoFunc TurnoFuncionario { get; set; }

        public enum TurnoFunc
        {
            Manha,
            Tarde
        }
    }
}