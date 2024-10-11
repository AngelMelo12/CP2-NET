using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CP2.Domain.Entities
{
    [Table("tb_vendedor_entidade")]
    public class VendedorEntity
    {
        [Key]
        public int Id { get; set; }

        [Required] // Campo obrigatório
        [MaxLength(150)] // Nome com no máximo 150 caracteres
        public string Nome { get; set; }

        [Required] // Campo obrigatório
        [EmailAddress] // Validação de formato de email
        [MaxLength(100)] // Email com no máximo 100 caracteres
        public string Email { get; set; }

        [Required] // Campo obrigatório
        [MaxLength(15)] // Telefone com no máximo 15 caracteres
        public string Telefone { get; set; }

        [Required] // Campo obrigatório
        public DateTime DataNascimento { get; set; } // Data de nascimento do vendedor

        [Required] // Campo obrigatório
        [MaxLength(200)] // Endereço com no máximo 200 caracteres
        public string Endereco { get; set; }

        [Required] // Campo obrigatório
        public DateTime DataContratacao { get; set; } // Data de contratação do vendedor

        [Required] // Campo obrigatório
        [Range(0, 100)] // Percentual de comissão deve estar entre 0% e 100%
        public decimal ComissaoPercentual { get; set; }

        [Required] // Campo obrigatório
        [Range(0, double.MaxValue)] // Meta mensal não pode ser negativa
        public decimal MetaMensal { get; set; }

        [Required] // Campo obrigatório
        public DateTime CriadoEm { get; set; } // Data de criação do registro

    }
}
