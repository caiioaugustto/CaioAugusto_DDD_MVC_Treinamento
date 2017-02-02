using CaioAugusto.DDDMVCTreinamento.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CaioAugusto.DDDMVCTreinamento.Domain.Interfaces.Repository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        TEntity Adicionar (TEntity obj);

        TEntity ObterPorId(Guid id);

        IEnumerable<TEntity> ObterTodos();

        TEntity Atualizar(TEntity obj);

        void Remover(Guid id);

        IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate);

        int SaveChanges();
    }
}
