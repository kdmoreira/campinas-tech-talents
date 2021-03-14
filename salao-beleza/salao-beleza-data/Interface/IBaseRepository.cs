using salao_beleza_dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace salao_beleza_data.Interface
{
    public interface IBaseRepository<T> where T : class, IEntity
    {
        void Incluir(T entity);

        void Alterar(T entity);

        bool Encontrar(T entity);

        T Selecionar(int id);

        List<T> SelecionarTudo();

        void Excluir(int id);

        void Dispose();
    }
}
