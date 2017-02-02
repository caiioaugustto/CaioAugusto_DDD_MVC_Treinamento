using CaioAugusto.DDDMVCTreinamento.Domain.Interfaces.Repository;
using CaioAugusto.DDDMVCTreinamento.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;

namespace CaioAugusto.DDDMVCTreinamento.Infra.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {

        public Cliente ObterPorCPF(string cpf)
        {
            return Buscar(c => c.CPF == cpf).FirstOrDefault();
        }

        public Cliente ObterPorEmail(string email)
        {
            return Buscar(c => c.Email == email).FirstOrDefault();
        }

        public IEnumerable<Cliente> ObterAtivos()
        {
            var sql = "SELECT c.Id as 'Id', c.* FROM Clientes c where Ativo = 1";
            return Db.Database.Connection.Query<Cliente>(sql);
        }

        public override void Remover(Guid id)
        {
            var cliente = ObterPorId(id);
            cliente.Excluido = true;
            Atualizar(cliente);
        }
    }
}
