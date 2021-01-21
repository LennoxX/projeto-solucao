using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Solucao.Domain.Models
{
    [Table("Clientes")]
    public class Cliente : Base
    {
        [Required(ErrorMessage = "Campo 'NOME' obrigatório")]
        public string Nome { get; set; }        
        
        public string Sobrenome { get; set; }
        
        [Required(ErrorMessage = "Campo 'EMAIL' obrigatório")]
        public string Email { get; set; }
        
        [JsonIgnore]
        public DateTime DataCadastro { get; set; }        
        
        public bool Ativo { get; set; }
    }
}
