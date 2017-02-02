﻿using CaioAugusto.DDDMVCTreinamento.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaioAugusto.DDDMVCTreinamento.App.Interfaces
{
    public interface IClienteAppService : IDisposable
    {
        ClienteEnderecoViewModel Adicionar(ClienteEnderecoViewModel clienteEnderecoViewModel);

        ClienteViewModel ObterPorId(Guid id);
        
        IEnumerable<ClienteViewModel> ObterTodos();
        
        IEnumerable<ClienteViewModel> ObterAtivos();
        
        ClienteViewModel ObterPorCpf(string cpf);
        
        ClienteViewModel ObterPorEmail(string email);
        
        ClienteViewModel Atualizar(ClienteViewModel clienteViewModel);
        
        void Remover(Guid id);
    }
}