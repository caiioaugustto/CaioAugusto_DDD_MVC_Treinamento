using AutoMapper;
using CaioAugusto.DDDMVCTreinamento.App.ViewModels;
using CaioAugusto.DDDMVCTreinamento.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaioAugusto.DDDMVCTreinamento.App.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
            CreateMap<Cliente, ClienteEnderecoViewModel>().ReverseMap();
            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
            CreateMap<Endereco, ClienteEnderecoViewModel>().ReverseMap();
        }
    }
}
