using Empresa.CategoriasApi.Domains.CQRS.Commands.CategoriaCommands;
using FluentValidation;

namespace Empresa.CategoriasApi.Domains.CQRS.Validations
{
    class CategoriaValidate : AbstractValidator<CategoriaCommand>
    {
        internal void ValidarId() =>
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("O {PropertyName} não pode estar vazio!");

        internal void ValidarDescricao() =>
            RuleFor(p => p.Descricao)
                .NotEmpty().WithMessage("A {PropertyName} não pode estar vazia!")
                .Length(3, 80).WithMessage("A {PropertyName} deve ter entre {MinLength} e {MaxLength} caracteres!");
    }
}
