using AutoMapper;
using CaioAugusto.DDDMVCTreinamento.App.Interfaces;
using CaioAugusto.DDDMVCTreinamento.App.ViewModels;
using CaioAugusto.DDDMVCTreinamento.Domain.Interfaces.Repository;
using CaioAugusto.DDDMVCTreinamento.Domain.Models;
using CaioAugusto.DDDMVCTreinamento.Infra.Data.Repository;
using System;
using System.Collections.Generic;

namespace CaioAugusto.DDDMVCTreinamento.App.Services
{
    public class ClienteAppService : IClienteAppService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteAppService()
        {
            _clienteRepository = new ClienteRepository();
        }

        public ClienteEnderecoViewModel Adicionar(ViewModels.ClienteEnderecoViewModel clienteEnderecoViewModel)
        {
            var cliente = Mapper.Map<Cliente>(clienteEnderecoViewModel.ClienteViewModel);
            var endereco = Mapper.Map<Endereco>(clienteEnderecoViewModel.EnderecoViewModel);

            cliente.Enderecos.Add(endereco);
            cliente.DataCadastro = DateTime.Now;
            cliente.Ativo = true;

            _clienteRepository.Adicionar(cliente);

            return clienteEnderecoViewModel;
        }

        public ClienteViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<ClienteViewModel>(_clienteRepository.ObterPorId(id));
        }

        public IEnumerable<ClienteViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<ClienteViewModel>>(_clienteRepository.ObterTodos());
        }

        public IEnumerable<ClienteViewModel> ObterAtivos()
        {
            return Mapper.Map<IEnumerable<ClienteViewModel>>(_clienteRepository.ObterAtivos());
        }

        public ClienteViewModel ObterPorCpf(string cpf)
        {
            return Mapper.Map<ClienteViewModel>(_clienteRepository.ObterPorCPF(cpf));
        }

        public ClienteViewModel ObterPorEmail(string email)
        {
            return Mapper.Map<ClienteViewModel>(_clienteRepository.ObterPorEmail(email));
        }

        public ClienteViewModel Atualizar(ClienteViewModel clienteViewModel)
        {
            var cliente = Mapper.Map<Cliente>(clienteViewModel);
            _clienteRepository.Atualizar(cliente);

            return clienteViewModel;
        }

        public void Remover(Guid id)
        {
            _clienteRepository.Remover(id);
        }

        public void Dispose()
        {
            _clienteRepository.Dispose();
        }
    }
}
