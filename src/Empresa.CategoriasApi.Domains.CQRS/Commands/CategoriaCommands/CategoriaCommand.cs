using Empresa.CategoriasApi.Domains.CQRS.Core.Validations;
using Empresa.CategoriasApi.Domains.CQRS.Validations;
using Empresa.CategoriasApi.Domains.Entities;
using FluentValidation.Results;
using System;

namespace Empresa.CategoriasApi.Domains.CQRS.Commands.CategoriaCommands
{
    public abstract class CategoriaCommand : Categoria, IValidateCommand
    {
        protected CategoriaCommand(Guid id)
            : base(id) { }

        protected CategoriaCommand(string descricao)
            : base(descricao) { }

        protected CategoriaCommand(Guid id, string descricao)
            : base(id, descricao) { }

        public ValidationResult ValidationResult { get; set; }

        public virtual bool IsValid()
        {
            ValidationResult = new CategoriaCommandValidate()
                .Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
