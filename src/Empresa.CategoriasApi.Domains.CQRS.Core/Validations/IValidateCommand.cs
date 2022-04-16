using FluentValidation.Results;
using MediatR;

namespace Empresa.CategoriasApi.Domains.CQRS.Core.Validations
{
    public interface IValidateCommand : IRequest<Result>, ICommand
    {
        ValidationResult ValidationResult { get; set; }
    }
}
