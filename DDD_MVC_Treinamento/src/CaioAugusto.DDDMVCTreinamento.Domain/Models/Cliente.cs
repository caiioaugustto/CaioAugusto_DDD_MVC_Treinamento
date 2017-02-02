using System;
using System.Collections.Generic;


namespace CaioAugusto.DDDMVCTreinamento.Domain.Models
{
    public class Cliente : Entity
    {
        public string Nome { get; set; }
        
        public string CPF { get; set; }
        
        public string Email { get; set; }
        
        public DateTime DataNascimento { get; set; }
        
        public DateTime DataCadastro { get; set; }
        
        public bool Ativo { get; set; }
        
        public bool Excluido { get; set; }
        
        public virtual ICollection<Endereco> Enderecos { get; set; }
    }
}
