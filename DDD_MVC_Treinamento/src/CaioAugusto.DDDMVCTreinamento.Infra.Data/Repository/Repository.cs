using CaioAugusto.DDDMVCTreinamento.Domain.Interfaces.Repository;
using CaioAugusto.DDDMVCTreinamento.Domain.Models;
using CaioAugusto.DDDMVCTreinamento.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace CaioAugusto.DDDMVCTreinamento.Infra.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected DDDMVCTreinamentoContext Db;
        protected DbSet<TEntity> DbSet;

        protected Repository()
        {
            Db = new DDDMVCTreinamentoContext();
            DbSet = Db.Set<TEntity>();
        }

        public virtual TEntity Adicionar(TEntity obj)
        {
            var objAdd = DbSet.Add(obj);
            SaveChanges();
            return objAdd;
        }

        public virtual TEntity ObterPorId(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> ObterTodos()
        {
            return DbSet.ToList();
        }

        public virtual TEntity Atualizar(TEntity obj)
        {
            var entry = Db.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;
            SaveChanges();

            return obj;
        }

        public virtual void Remover(Guid id)
        {
            var obj = new TEntity() { Id = id };
            DbSet.Remove(obj);
            SaveChanges();
        }

        public virtual IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
