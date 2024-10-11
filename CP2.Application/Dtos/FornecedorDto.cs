using CP2.Domain.Interfaces.Dtos;
using FluentValidation;
using System.Text.RegularExpressions;

namespace CP2.Application.Dtos
{
    public class FornecedorDto : IFornecedorDto
    {
        public DateTime CriadoEm { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string CNPJ { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public void Validate()
        {
            var validateResult = new FornecedorDtoValidation().Validate(this);

            if (!validateResult.IsValid)
                throw new Exception(string.Join(" e ", validateResult.Errors.Select(x => x.ErrorMessage)));
        }
    }

    internal class FornecedorDtoValidation : AbstractValidator<FornecedorDto>
    {
        public FornecedorDtoValidation()
        {
            // Validação para o nome do fornecedor
            RuleFor(f => f.Nome)
                .NotEmpty().WithMessage("O nome do fornecedor é obrigatório.")
                .Length(2, 100).WithMessage("O nome deve ter entre 2 e 100 caracteres.");

            // Validação para o CNPJ
            RuleFor(f => f.CNPJ)
                .NotEmpty().WithMessage("O CNPJ é obrigatório.")
                .Must(IsValidCNPJ).WithMessage("O CNPJ informado não é válido.");

            // Validação para o endereço
            RuleFor(f => f.Endereco)
                .NotEmpty().WithMessage("O endereço é obrigatório.");

            // Validação para o telefone
            RuleFor(f => f.Telefone)
                .NotEmpty().WithMessage("O telefone é obrigatório.")
                .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("O telefone deve estar no formato E.164.");

            // Validação para o email
            RuleFor(f => f.Email)
                .NotEmpty().WithMessage("O e-mail é obrigatório.")
                .EmailAddress().WithMessage("O e-mail informado não é válido.");

            // Validação para a data de criação
            RuleFor(f => f.CriadoEm)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("A data de criação não pode ser no futuro.");
        }

        // Método auxiliar para validar o CNPJ
        private bool IsValidCNPJ(string cnpj)
        {
            // Implementação simples para validação de CNPJ (pode ser substituída por uma validação mais robusta)
            return Regex.IsMatch(cnpj, @"^\d{2}\.\d{3}\.\d{3}/\d{4}-\d{2}$");
        }
    }
}
