using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Solucao.Domain.Models
{
    [Table("Clientes")]
    public class Cliente : Base
    {
        [Required]
        public string Nome { get; set; }
        
        
        public string Sobrenome { get; set; }
        
        
        public string Email { get; set; }
        
        
        public DateTime DataCadastro { get; set; }
        
        
        public bool Ativo { get; set; }
    }
}
