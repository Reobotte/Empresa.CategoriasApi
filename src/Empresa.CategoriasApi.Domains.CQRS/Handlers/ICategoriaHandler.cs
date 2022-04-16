using Empresa.CategoriasApi.Domains.CQRS.Commands.CategoriaCommands;
using Empresa.CategoriasApi.Domains.CQRS.Core.Validations;
using MediatR;

namespace Empresa.CategoriasApi.Domains.CQRS.Handlers
{
    interface ICategoriaHandler :
        IRequestHandler<IncluirCategoriaCommand, Result>,
        IRequestHandler<AlterarCategoriaCommand, Result>,
        IRequestHandler<ExcluirCategoriaCommand, Result> { }
}
