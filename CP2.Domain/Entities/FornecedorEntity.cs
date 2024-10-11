using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CP2.Domain.Entities
{
    [Table("tb_fornecedor_entidade")]
    public class FornecedorEntity
    {
        [Key] // Define que a propriedade é a chave primária
        public int Id { get; set; }

        [Required] // Campo obrigatório
        [MaxLength(150)] // Tamanho máximo de caracteres permitido
        public string Nome { get; set; }

        [Required] // Campo obrigatório
        [MaxLength(14)] // CNPJ com no máximo 14 caracteres
        public string CNPJ { get; set; }

        [Required] // Campo obrigatório
        [MaxLength(200)] // Endereço com no máximo 200 caracteres
        public string Endereco { get; set; }

        [Required] // Campo obrigatório
        [MaxLength(15)] // Telefone com no máximo 15 caracteres
        public string Telefone { get; set; }

        [Required] // Campo obrigatório
        [EmailAddress] // Validação de formato de email
        [MaxLength(100)] // Email com no máximo 100 caracteres
        public string Email { get; set; }

        [Required] // Campo obrigatório
        public DateTime CriadoEm { get; set; } // Data de criação do registro

    }
}
