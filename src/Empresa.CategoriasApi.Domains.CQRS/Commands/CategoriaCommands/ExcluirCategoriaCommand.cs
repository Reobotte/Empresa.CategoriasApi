using Empresa.CategoriasApi.Domains.CQRS.Validations;
using System;

namespace Empresa.CategoriasApi.Domains.CQRS.Commands.CategoriaCommands
{
    public class ExcluirCategoriaCommand : CategoriaCommand
    {
        public ExcluirCategoriaCommand(Guid id)
            : base(id) { }

        public override bool IsValid()
        {
            var validacao = new CategoriaValidate();
            validacao.ValidarId();

            ValidationResult = validacao.Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
