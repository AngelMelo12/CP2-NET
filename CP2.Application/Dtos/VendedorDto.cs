using CP2.Domain.Interfaces.Dtos;
using FluentValidation;
using System.Text.RegularExpressions;

namespace CP2.Application.Dtos
{
    public class VendedorDto : IVendedorDto
    {
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public string Endereco { get; set; } = string.Empty;
        public DateTime DataContratacao { get; set; }
        public decimal ComissaoPercentual { get; set; }
        public decimal MetaMensal { get; set; }
        public DateTime CriadoEm { get; set; }

        public void Validate()
        {
            var validateResult = new VendedorDtoValidation().Validate(this);

            if (!validateResult.IsValid)
                throw new Exception(string.Join(" e ", validateResult.Errors.Select(x => x.ErrorMessage)));
        }
    }

    internal class VendedorDtoValidation : AbstractValidator<VendedorDto>
    {
        public VendedorDtoValidation()
        {
            // Validação para o nome do vendedor
            RuleFor(v => v.Nome)
                .NotEmpty().WithMessage("O nome do vendedor é obrigatório.")
                .Length(2, 100).WithMessage("O nome deve ter entre 2 e 100 caracteres.");

            // Validação para o e-mail
            RuleFor(v => v.Email)
                .NotEmpty().WithMessage("O e-mail é obrigatório.")
                .EmailAddress().WithMessage("O e-mail informado não é válido.");

            // Validação para o telefone
            RuleFor(v => v.Telefone)
                .NotEmpty().WithMessage("O telefone é obrigatório.")
                .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("O telefone deve estar no formato E.164.");

            // Validação para a data de nascimento
            RuleFor(v => v.DataNascimento)
                .LessThanOrEqualTo(DateTime.Now.AddYears(-18)).WithMessage("O vendedor deve ter pelo menos 18 anos.");

            // Validação para o endereço
            RuleFor(v => v.Endereco)
                .NotEmpty().WithMessage("O endereço é obrigatório.");

            // Validação para a data de contratação
            RuleFor(v => v.DataContratacao)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("A data de contratação não pode ser no futuro.");

            // Validação para o percentual de comissão
            RuleFor(v => v.ComissaoPercentual)
                .InclusiveBetween(0, 100).WithMessage("O percentual de comissão deve estar entre 0% e 100%.");

            // Validação para a meta mensal
            RuleFor(v => v.MetaMensal)
                .GreaterThan(0).WithMessage("A meta mensal deve ser maior que zero.");

            // Validação para a data de criação
            RuleFor(v => v.CriadoEm)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("A data de criação não pode ser no futuro.");
        }
    }
}
