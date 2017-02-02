using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaioAugusto.DDDMVCTreinamento.App.AutoMapper
{
    public class AutoMapperConfig
    {
        //Ativar o AutoMapper no Global.asax
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
                {
                    x.AddProfile<DomainToViewModelMappingProfile>();
                    //Caso o .ReverseMap() de DomainToViewModelMappingProfile não estivesse
                    //x.AddProfile<ViewModelToDomainMappingProfile>();
                });
        }
    }
}
